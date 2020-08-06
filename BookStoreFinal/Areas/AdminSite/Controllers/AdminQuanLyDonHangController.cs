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
    public class AdminQuanLyDonHangController : Controller
    {
        private context db = new context();
        // GET: AdminSite/AdminQuanLyDonHang
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var DonHang = db.ORDER.ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(DonHang.ToPagedList(pageNumber, pageSize));

        }
        [HasCredentialAtribute(Quyen = 1)]
        public JsonResult ChiTietDonHang(int MaDonHang)
        {
            List<ORDERDETAIL> ChiTiet = db.ORDERDETAIL.Where(x => x.ORDER_ID == MaDonHang).ToList();
            List<ChiTietDonHang> data = new List<ChiTietDonHang>();
            foreach (ORDERDETAIL ct in ChiTiet)
            {
                ChiTietDonHang DonHang = new ChiTietDonHang();
                DonHang.ChitietgiohangID = ct.ID;
                DonHang.GiohangkhID = ct.ORDER_ID;
                DonHang.Masach = ct.ID;
                DonHang.Soluong = ct.QUANTITY;
                DonHang.Thanhtien = ct.AMOUNT;
                DonHang.TenSach = ct.BOOKS.TITLE;
                DonHang.DonGia = ct.BOOKS.PRICE;
                data.Add(DonHang);
            }
            return Json(data);
        }

    }

    public class ChiTietDonHang
    {
        public int ChitietgiohangID { get; set; }

        public int? GiohangkhID { get; set; }

        public int? Masach { get; set; }

        public int? Soluong { get; set; }
        public decimal? DonGia { get; set; }

        public decimal? Thanhtien { get; set; }

        public string TenSach { get; set; }

    }
}
