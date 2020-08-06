using BookStoreFinal.Models;
using BookStoreFinal.Models.common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreFinal.Areas.AdminSite.Controllers
{
    public class AdminQuanLyKhachHangController : Controller
    {
        private context db = new context();
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult TatCaKhachHang(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var TatCaKhachHang = db.CUSTOMERS
                                 .OrderByDescending(kh => kh.NAME)
                                 .ToList();
            return View(TatCaKhachHang.ToPagedList(pageNumber, pageSize));
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult ThemKhachHang()
        {
            return View();
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult SuaKhachHang()
        {
            return View();
        }
    }
}