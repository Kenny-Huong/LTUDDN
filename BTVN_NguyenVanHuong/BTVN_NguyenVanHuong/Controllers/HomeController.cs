using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTVN_NguyenVanHuong.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Thông tin cá nhân.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Phần liên hệ.";

            return View();
        }
    }
}