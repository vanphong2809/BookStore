using BookStoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreFinal.Controllers
{
    public class ChunhatController : Controller
    {
        private context db = new context();
        // GET: Chunhat
        public ActionResult Index()
        {
            var book = db.BOOKS.Where(x => x.TITLE != null).ToList();
            return View(book);
        }
    }
}