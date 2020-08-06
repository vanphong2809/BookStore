using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreFinal.Models;
namespace BookStoreFinal.Areas.AdminSite.Controllers
{
    public class AdminDangNhapController : Controller
    {
        private context context = new context();
        // GET: AdminSite/AdminDangNhap
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public ActionResult Login(CUSTOMERS user, string returnUrl)
        {
            {
                if (ModelState.IsValid)
                {
                    CUSTOMERS cus = context.CUSTOMERS.SingleOrDefault(kh => kh.USERNAME == user.USERNAME);
                    if (cus != null && cus.ROLE == 1)
                    {
                        if (BCrypt.Net.BCrypt.Verify(user.PASSWORD, cus.PASSWORD))
                        {
                            Session.Add("ADMIN_SESSION", cus);
                            return RedirectToAction("TatCaSach", "AdminQuanLySach");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Mật khẩu sai");
                        }
                            
                    }
                    else
                    {
                        ModelState.AddModelError("","Tài khoản không tồn tại");
                    }
                }
                return View("Index");
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("ADMIN_SESSION");
            return RedirectToAction("Index");

        }
    }
}