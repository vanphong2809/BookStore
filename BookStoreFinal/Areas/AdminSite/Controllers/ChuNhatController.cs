using BookStoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreFinal.Areas.AdminSite.Controllers
{
    public class ChuNhatController : Controller
    {
        private context db = new context();
        // GET: AdminSite/ChuNhat
        public ActionResult Index()
        {
            var book = db.BOOKS.Where(x => x.TITLE != null).ToList();
            return View(book);
        }
    }
}