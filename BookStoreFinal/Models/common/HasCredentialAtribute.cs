using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BookStoreFinal.Models.common
{
    public class HasCredentialAtribute : AuthorizeAttribute
    {
        public int Quyen { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (CUSTOMERS)HttpContext.Current.Session["ADMIN_SESSION"];
            if (session != null && session.ROLE == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/AdminSite/Views/AdminDangNhap/Index.cshtml"
            };
        }
    }
}