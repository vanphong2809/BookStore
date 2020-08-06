using BookStoreFinal.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreFinal.Controllers
{
    public class BookController : Controller
    {
        private context context = new context();
        private const string CartSession = "CART_SESSION";
        // GET: Book

       
        public ActionResult Index(int? id, int? page)
        {
            if (id == null)
            {
                var sach = context.BOOKS.OrderByDescending(x => x.PRICE).ToPagedList(page ?? 1, 4);

                return View(sach);
            }
            else
            {
                var sach = context.BOOKS.OrderByDescending(x=>x.PRICE).ToPagedList(page ?? 1, 4);
                return View(sach);
            }



        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var BookDetail = context.BOOKS.Where(x => x.ID == id).FirstOrDefault();
            return View(BookDetail);
        }
        [HttpGet]
        public JsonResult Review(int id)
        {
            var BookReview = context.BOOKS.Where(x => x.ID == id).FirstOrDefault();
            return Json(new { bookReview=BookReview});
        }
        public ActionResult GetProductTag(int? id)
        {
 //           ViewBag.book = GetBookByChude(id);
            var genre = from cd in context.GENRE select cd;
            return PartialView(genre);
        }
        public ActionResult ProductCategory()
        {
            var items = context.GENRE.ToList();
            var arr = new int[items.Count()];
            var j = 0;
            foreach (var it in items)
            {
                arr[j] = context.GENRE.Where(i => i.ID == it.ID).Count();
                j++;
            }
            ViewBag.countBook = arr;
            ViewBag.category = context.GENRE.Where(i => i.NAME != null).ToList();
            return PartialView();
        }
        //public ActionResult Search(string query)
        //{
        //    var book = context.BOOKS.ToList();
        //    var result=from b in book where  b.TITLE==query and query== 
        //    return View();
        //}
    }
}
