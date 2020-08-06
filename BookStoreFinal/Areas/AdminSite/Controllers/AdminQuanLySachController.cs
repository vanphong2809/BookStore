using BookStoreFinal.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Remoting.Messaging;
using BookStoreFinal.Models.common;

namespace BookStoreFinal.Areas.AdminSite.Controllers
{
    public class AdminQuanLySachController : Controller
    {
        private context db = new context();
        // GET: AdminSite/AdminQuanLySach
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult TatCaSach(int? page)
        {
            if (page == null) page = 1;
            var TatCaSach = db.BOOKS.ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(TatCaSach.ToPagedList(pageNumber, pageSize));
        }

        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult ThemSach()
        {
            var TatCaChuDe = db.GENRE.ToList();
            var TatCaTacGia = db.AUTHOR.ToList();
            var TatCaNXB = db.PUBLISHER.ToList();
            ViewBag.TatCaChuDe = TatCaChuDe;
            ViewBag.TatCaTacGia = TatCaTacGia;
            ViewBag.TatCaNXB = TatCaNXB;
            return View();
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult Save(BOOKS sach, HttpPostedFileBase Hinhminhhoa)
        {
            if (ModelState.IsValid)
            {
                //sach.Donvitinh = "VND";
                if (Hinhminhhoa != null && Hinhminhhoa.ContentLength > 0)
                {
                    var TenAnh = Path.GetFileName(Hinhminhhoa.FileName);
                    var DuongDan = Path.Combine(Server.MapPath("~/Content/images/books/"), TenAnh);
                    sach.BOOK_URL = TenAnh;
                    Hinhminhhoa.SaveAs(DuongDan);
                }
                else
                {
                    sach.BOOK_URL = "400x400.PNG";
                }
                //sach.Ngaycapnhat = DateTime.Now;
                db.BOOKS.Add(sach);
                db.SaveChanges();
                return RedirectToAction("TatCaSach");


            }
            else
            {
                ViewBag.TatCaChuDe = db.GENRE.ToList();
                ViewBag.TatCaTacGia = db.AUTHOR.ToList();
                ViewBag.TatCaNXB = db.PUBLISHER.ToList();
                return View(sach);
            }
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult SuaSach(int MaSach)
        {

            var TatCaChuDe = db.GENRE.ToList();
            var TatCaTacGia = db.AUTHOR.ToList();
            var TatCaNXB = db.PUBLISHER.ToList();
            ViewBag.TatCaChuDe = TatCaChuDe;
            ViewBag.TatCaTacGia = TatCaTacGia;
            ViewBag.TatCaNXB = TatCaNXB;
            BOOKS sach = db.BOOKS.Find(MaSach);
            sach.PRICE = sach.PRICE != null ? sach.PRICE : 0;
            //sach.Giakm = sach.Dongia != null ? sach.Giakm : 0;
            sach.DESCRIPTION = sach.DESCRIPTION != null ? sach.DESCRIPTION : "Khong co mo ta";
            sach.EXCERPT = sach.EXCERPT != null ? sach.EXCERPT : "khong co mo ta";
            return View(sach);
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult Sua(BOOKS sach, HttpPostedFileBase Hinhminhhoa)
        {
            var a = sach;
            if (Hinhminhhoa != null && Hinhminhhoa.ContentLength > 0)
            {
                var TenAnh = Path.GetFileName(Hinhminhhoa.FileName);
                var DuongDan = Path.Combine(Server.MapPath("~/Content/images/books/"), TenAnh);
                sach.BOOK_URL = TenAnh;
                Hinhminhhoa.SaveAs(DuongDan);

            }
            //sach.Donvitinh = "VND";
            //sach.Ngaycapnhat = DateTime.Now;
            var sachcu = db.BOOKS.Find(sach.ID);
            db.Entry(sachcu).CurrentValues.SetValues(sach);
            db.SaveChanges();
            return RedirectToAction("TatCaSach");

        }
        [HasCredentialAtribute(Quyen = 1)]
        public JsonResult XoaSach(int MaSach)
        {
            try
            {
                BOOKS sach = db.BOOKS.Find(MaSach);
                var ct = db.ORDERDETAIL.Where(x => x.BOOKS.ID == sach.ID);
                db.BOOKS.Remove(sach);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult TimKiem(string TenSach, int? page)
        {
            ViewBag.CurrentFilter = TenSach;
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<BOOKS> lstSach = db.BOOKS.Where(x => x.TITLE.Contains(TenSach)).ToList();
            return View(lstSach.ToPagedList(pageNumber, pageSize));
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult ThemTacGia(String tenTG)
        {
            AUTHOR tg = new AUTHOR();
            tg.NAME = tenTG;
            db.AUTHOR.Add(tg);
            db.SaveChanges();
            return RedirectToAction("ThemSach");
        }
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult ThemChuDe(string TenChuDe)
        {
            GENRE cd = new GENRE();
            cd.NAME = TenChuDe;
            db.GENRE.Add(cd);
            db.SaveChanges();
            return RedirectToAction("ThemSach");
        }
    }
}