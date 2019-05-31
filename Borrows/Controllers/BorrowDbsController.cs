using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Borrows.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Borrows.Controllers
{
    public class BorrowDbsController : Controller
    {
        public KDTH_BorrowContext _context = new KDTH_BorrowContext();
        public Astea_TH_1401Context astea_context = new Astea_TH_1401Context();
        public kyocera_dbContext kyocera_context = new kyocera_dbContext();
    
        public BorrowDb borrowdb = new BorrowDb();
        public BorrowItem borrowitem = new BorrowItem();


        public BorrowDbsController()
        {
            //var students = astea_context.serviceDetail.FromSql("dbo.sp_GetServiceDetails 'SV1905033242'").ToList();
           
        }

        // GET: BorrowDbs
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("user", "00164");
            HttpContext.Session.SetInt32("role", 1);
            
            if (!HttpContext.Session.IsAvailable)
            {
                //HttpContext.Session.Set("User",Encoding.UTF8.GetBytes("Test"));
                var test = HttpContext.Session.GetString("user");
                Response.Redirect("Index");
            }

            //return View(await _context.BorrowDb.ToListAsync());
            return View(this);
        }

        // GET: BorrowDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            borrowdb = await _context.BorrowDb
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            var items = await _context.BorrowItem.Where(a => a.BorrowId == id).ToListAsync();
            if (borrowdb == null)
            {
                return NotFound();
            }

            return View(this);
        }

        public async Task<IActionResult> Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            borrowdb = await _context.BorrowDb
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            var items = await _context.BorrowItem.Where(a => a.BorrowId == id).ToListAsync();
            if (borrowdb == null)
            {
                return NotFound();
            }

            return View(this);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int id,string approver, [Bind("BorrowId,ServiceCode,CustomerName,ProductId,SerialNo,EntryName,EntryDate,RequestName,RequestDate,BorrowStatus,HeadApproverId,HeadApproverDate,ManagerApproverId,ManagerApproverDate,LogisticApproverId,LogisticApproverDate,BorrowItem")] BorrowDb borrowDb)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    borrowdb.BorrowStatus = "Approved";
                    _context.BorrowDb.Update(borrowDb);
                    //_context.BorrowItem.UpdateRange(borrowDb.BorrowItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowDbExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(borrowDb);
            //var borrow = _context.BorrowDb
            //    .FirstOrDefaultAsync(m => m.BorrowId == id);



            return View(this);
        }

        // GET: BorrowDbs/Create
        public IActionResult Create()
        {
            var user = kyocera_context.Nmhmemp.Where(a => a.EmpCode == HttpContext.Session.GetString("user")).FirstOrDefault();
            ViewBag.GroupList = kyocera_context.Nmhmemp.Where(a => a.OrgUnitCode == user.OrgUnitCode).ToList();

            ViewBag.User = "["+user.EmpCode+"]"+user.FirstName+" "+user.LastName;

            return View(this);
        }

        public ActionResult AddItem()
        {
            var newItem = new BorrowItem();

            return PartialView("~/Views/Shared/_itemEditor.cshtml", newItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string SV,string CustName,string ProdId,string SerialNo,string Entryname, [Bind("ServiceCode,CustomerName,ProductId,SerialNo,EntryName,EntryDate,RequestName,RequestDate,BorrowStatus,HeadApproverId,HeadApproverDate,ManagerApproverId,ManagerApproverDate,LogisticApproverId,LogisticApproverDate,BorrowItem")] BorrowDb borrowDb)
        {
           

            var user = kyocera_context.Nmhmemp.Where(a => a.EmpCode == HttpContext.Session.GetString("user")).FirstOrDefault();
            ViewBag.GroupList = kyocera_context.Nmhmemp.Where(a => a.OrgUnitCode == user.OrgUnitCode).ToList();

            ViewBag.User = "[" + user.EmpCode + "]" + user.FirstName + " " + user.LastName;

            if (borrowDb.RequestDate == null)
            {
                if (astea_context.serviceDetail.FromSql("dbo.sp_GetServiceDetails '" + SV + "'").ToList().Count > 0)
                {
                    ServiceDetails students = astea_context.serviceDetail.FromSql("dbo.sp_GetServiceDetails " + SV).FirstOrDefault();
                    ViewBag.SV = students.RequestID;
                    ViewBag.Customer = students.CustomerName;
                    ViewBag.Product = students.ItemName;
                    ViewBag.Serial = students.SerialNO;
                    return View(this);
                }
            }
            else
            {
                // Import data to DB
                //BorrowDb borrowDb = new BorrowDb();
                borrowDb.ServiceCode = SV;
                borrowDb.CustomerName = CustName;
                borrowDb.ProductId = ProdId;
                borrowDb.SerialNo = SerialNo;
                borrowDb.EntryName = Entryname;
                borrowDb.HeadApproverDate = DateTime.Now;
                borrowDb.HeadApproverId = "";
                borrowDb.LogisticApproverDate = DateTime.Now;
                borrowDb.LogisticApproverId = "";
                borrowDb.ManagerApproverDate = DateTime.Now;
                borrowDb.ManagerApproverId = "";

                if (ModelState.IsValid)
                {
                    _context.BorrowDb.Add(borrowDb);
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.borrow_db ON");
                    await _context.SaveChangesAsync();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.borrow_db OFF");
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(this);
        }

        // GET: BorrowDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowDb = await _context.BorrowDb.FindAsync(id);
            var borrowitem = await _context.BorrowItem.Where(a=>a.BorrowId == id).ToListAsync();
            if (borrowDb == null)
            {
                return NotFound();
            }
            return View(borrowDb);
        }

        // POST: BorrowDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,ServiceCode,CustomerName,ProductId,SerialNo,EntryName,EntryDate,RequestName,RequestDate,BorrowStatus,HeadApproverId,HeadApproverDate,ManagerApproverId,ManagerApproverDate,LogisticApproverId,LogisticApproverDate,BorrowItem")] BorrowDb borrowDb)
        {
            //if (id != borrowDb.BorrowId)
            //{
            //    return NotFound();
            //}

            borrowDb.BorrowId = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.BorrowDb.Update(borrowDb);
                    //_context.BorrowItem.UpdateRange(borrowDb.BorrowItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowDbExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(borrowDb);
        }

        // GET: BorrowDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowDb = await _context.BorrowDb
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrowDb == null)
            {
                return NotFound();
            }

            return View(borrowDb);
        }

        // POST: BorrowDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var borrowDb = await _context.BorrowDb.FindAsync(id);
            var items = await _context.BorrowItem.Where(a => a.BorrowId == id).ToListAsync();
            _context.BorrowDb.Remove(borrowDb);
            _context.BorrowItem.RemoveRange(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowDbExists(int id)
        {
            return _context.BorrowDb.Any(e => e.BorrowId == id);
        }

        
    }
}
