using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Borrows.Models;

namespace Borrows.Controllers
{
    public class HomeController : Controller
    {
        public KDTH_BorrowContext _context = new KDTH_BorrowContext();
        public kyocera_dbContext menu_context = new kyocera_dbContext();

        public IEnumerable<BorrowDb> borrowdb;
        public IEnumerable<MenuL1> menul1;
        public IEnumerable<MenuL2> menul2;
        public IEnumerable<MenuL3> menul3;
        public IEnumerable<MenuL4> menul4;


        public IActionResult Index()
        {
            borrowdb = _context.BorrowDb.ToList();
            menul1 = menu_context.MenuL1.ToList();
            menul2 = menu_context.MenuL2.ToList();
            menul3 = menu_context.MenuL3.ToList();
            menul4 = menu_context.MenuL4.ToList();
            return View(this);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
