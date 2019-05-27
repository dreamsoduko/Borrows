﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Borrows.Models;
using System.Web;
using GridMvc;

namespace Borrows.Controllers
{
    public class BorrowDbsController : Controller
    {
        private readonly KDTH_BorrowContext _context = new KDTH_BorrowContext();
        private Astea_TH_1401Context astea_context = new Astea_TH_1401Context();

        
        public BorrowDb borrowdb = new BorrowDb();

        public BorrowDbsController()
        {
            //var students = astea_context.serviceDetail.FromSql("dbo.sp_GetServiceDetails 'SV1905033242'").ToList();
        }

        // GET: BorrowDbs
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.BorrowDb.ToListAsync());
        }

        // GET: BorrowDbs/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: BorrowDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        //// GET: BorrowDbs/Create/SV
        //public IActionResult Create(string servicecode)
        //{
        //    var students = astea_context.serviceDetail.FromSql("dbo.sp_GetServiceDetails '{servicecode}'").ToList();
        //    return View();
        //}

        // POST: BorrowDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceCode,CustomerName,ProductId,SerialNo,EntryName,EntryDate,RequestName,RequestDate,BorrowStatus,HeadApproverId,HeadApproverDate,ManagerApproverId,ManagerApproverDate,LogisticApproverId,LogisticApproverDate,BorrowItems")] BorrowDb borrowDb,string SV)
        {
            if (astea_context.serviceDetail.FromSql("dbo.sp_GetServiceDetails '" + SV + "'").ToList().Count > 0)
            {
                ServiceDetails students = astea_context.serviceDetail.FromSql("dbo.sp_GetServiceDetails " + SV).FirstOrDefault();
                ViewBag.SV = students.RequestID;
                ViewBag.Customer = students.CustomerName;
                ViewBag.Product = students.ItemName;
                ViewBag.Serial = students.SerialNO;
                return View(borrowDb);
            }

            if (ModelState.IsValid)
            {
                _context.BorrowDb.Add(borrowDb);
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.borrow_db ON");
                await _context.SaveChangesAsync();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.borrow_db OFF");
                return RedirectToAction(nameof(Index));
            }
            return View(borrowDb);
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
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,ServiceCode,CustomerName,ProductId,SerialNo,EntryName,EntryDate,RequestName,RequestDate,BorrowStatus,HeadApproverId,HeadApproverDate,ManagerApproverId,ManagerApproverDate,LogisticApproverId,LogisticApproverDate")] BorrowDb borrowDb)
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
                    _context.Update(borrowDb);
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
            _context.BorrowDb.Remove(borrowDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowDbExists(int id)
        {
            return _context.BorrowDb.Any(e => e.BorrowId == id);
        }
    }
}