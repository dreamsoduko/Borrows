using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Borrows.Models;

namespace Borrows.Controllers
{
    public class NmhmempController : Controller
    {
        kyocera_dbContext _context = new kyocera_dbContext();
        // GET: Nmhmemp
        public ActionResult Index()
        {
            return View(_context.Nmhmemp.ToList());
        }

        // GET: Nmhmemp/Details/5
        public ActionResult Details(string id)
        {
            var nm = _context.Nmhmemp.FirstOrDefault(m => m.EmpId == id);
            return View();
        }

        // GET: Nmhmemp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nmhmemp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Nmhmemp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nmhmemp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Nmhmemp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nmhmemp/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}