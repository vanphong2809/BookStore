using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreFinal.Models;
namespace BookStoreFinal.Controllers
{
    public class UserController : Controller
    {
        private context context = new context();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CUSTOMERS cus)
        {
            var account = context.CUSTOMERS.SingleOrDefault(x => x.EMAIL.Equals(cus.EMAIL));
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(cus.PASSWORD, account.PASSWORD))
                {
                    Session.Add("USER_SESSION", account);
                    Session["FullName"] = account.NAME;
                    Session["Email"] = account.EMAIL;
                    Session["Address"] = account.ADDRESS;
                    Session["Phone"] = account.PHONE;
                    Session["Id"] = account.ID;
                    Session["UserName"] = account.USERNAME;
                    if (Session["CartSession"] != null)
                    {
                        return RedirectToAction("Index", "Cart");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }                
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng. Xin kiểm tra lại!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng. Xin kiểm tra lại!");
            }
            if (Session["CartSession"] != null)
            {
                return RedirectToAction("Index", "Cart");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("USER_SESSION");
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public JsonResult CheckRegister(string email)
        {
            var check = context.CUSTOMERS.FirstOrDefault(s => s.EMAIL == email);
            if (check != null)
            {
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = true }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CUSTOMERS cus)
        {
            if (ModelState.IsValid)
            {
                var pass = BCrypt.Net.BCrypt.HashPassword(cus.PASSWORD);
                cus.PASSWORD = pass;
                cus.ROLE = 0;
                context.CUSTOMERS.Add(cus);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}