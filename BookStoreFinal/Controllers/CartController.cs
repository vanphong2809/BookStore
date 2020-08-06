using BookStoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreFinal.Controllers
{
    public class CartController : Controller
    {
        private context context = new context();
        // GET: Cart
        public ActionResult Index()
        {
            var cart = (Cart)Session["CartSession"];
            if (cart == null)
            {
                cart = new Cart();
            }

            return View(cart);
        }
        public JsonResult AddCart(int id, int quantity)
        {
            var book = context.BOOKS.Find(id);
            var cart = (Cart)Session["CartSession"];
            var cartItem = new CartItem();
            if (cart != null)
            {
                cart.AddItem(book, quantity);
                Session["CartSession"] = cart;
            }
            else
            {
                cart = new Cart();
                cart.AddItem(book, quantity);
                Session["CartSession"] = cart;
            }
            return Json(new{status=true},JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateCart(int[] bookId,int[] quantity)
        {
            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                for (int i=0;i<bookId.Count();i++)
                {
                    var book = context.BOOKS.Find(bookId[i]);
                    cart.UpdateCart(book, quantity[i]);
                }
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveLine(int id)
        {
            var book = context.BOOKS.Find(id);
            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                cart.RemoveLine(book);
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");
        }
        public JsonResult ConfirmCart(int[] listCheckId,int[] quantity)
        {
            var cart = (Cart)Session["ConfirmCart"];
            if (cart != null)
            {
                for(int i = 0; i < listCheckId.Count(); i++)
                {
                    var book = context.BOOKS.Find(listCheckId[i]);
                    cart.UpdateCart(book, quantity[i]);
                }
                Session["ConfirmCart"] = cart;
            }
            return Json(new { status = true });
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = (Cart)Session["CartSession"];
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Login","User");
            }
            if (cart == null)
            {
                cart = new Cart();
            }
            return View(cart);
        }
        [HttpPost]
        public JsonResult Payment(ORDER model)
        {
            Cart c = new Cart();
            model.CREATED_DATE = DateTime.Now;
            try
            {
                Cart cart = (Cart)Session["CartSession"];
                model.ADDRESS = Session["Address"].ToString();
                model.EMAIL = Session["Email"].ToString();
                model.PHONE = Session["Phone"].ToString();
                model.STATUS = true;
                model.PAYMENTMETHOD = 1;
                model.CUSTOMER_ID = (int)Session["Id"];
                model.TOTALAMOUNT = cart.ComputeTotalValue();
                context.ORDER.Add(model);
                int? totalAmmount = 0;
                foreach (var item in cart.Lines)
                {
                    ORDERDETAIL od = new ORDERDETAIL();
                    od.BOOK_ID = item.Book.ID;
                    od.ORDER_ID = model.ID;
                    od.PRICE = item.Book.PRICE;
                    od.QUANTITY = item.Quantity;
                    od.AMOUNT = od.PRICE * od.QUANTITY;
                    totalAmmount += od.AMOUNT;
                    context.ORDERDETAIL.Add(od);
                    context.SaveChanges();
                }
                
                
                context.SaveChanges();
                cart.Clear();
                Session["CartSession"] = cart;
            }catch(Exception ex)
            {
                return Json(new { status = false });
            }
            return Json(new { status = true });
        }
    }
}