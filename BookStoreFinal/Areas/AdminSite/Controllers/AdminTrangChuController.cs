using BookStoreFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreFinal.Models.common;
namespace BookStoreFinal.Areas.AdminSite.Controllers
{
    public class AdminTrangChuController : Controller
    {
        private context context = new context();
        [HasCredentialAtribute(Quyen = 1)]
        public ActionResult Index()
        {

            return View();
        }

        [HasCredentialAtribute(Quyen = 1)]
        [HttpPost]
        public JsonResult ThongKe()
        {
            //List<ThongKe> DuLieu = new List<ThongKe>();
            //for (int i = 1; i <= 12; i++)
            //{
            //    ThongKe DL = new ThongKe();
            //    DL.Thang = i;
            //    DL.TongTien = 0;
            //    DuLieu.Add(DL);
            //}
            List<ThongKe> DuLieu = context.Database.SqlQuery<ThongKe>("SELECT sum(TOTALAMOUNT) as TongTien, MONTH(CREATED_DATE) as Thang from [ORDER] where YEAR(CREATED_DATE) = YEAR(GETDATE()) group by MONTH(CREATED_DATE) order by MONTH(CREATED_DATE)").ToList();
            decimal[] Tien = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //for (int i = 0; i < DuLieu.Count; i++)
            //{
            //    if(DuLieu[i].Thang == i)
            //    {
            //        Tien[i] = DuLieu[i].TongTien;
            //    }
            //}
            foreach (ThongKe t in DuLieu)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (t.Thang == i)
                    {
                        Tien[i] = t.TongTien;
                    }
                }
            }
            return Json(Tien);
        }
    }
    public class ThongKe
    {
        public int Thang { get; set; }
        public int TongTien { get; set; }

    }
}