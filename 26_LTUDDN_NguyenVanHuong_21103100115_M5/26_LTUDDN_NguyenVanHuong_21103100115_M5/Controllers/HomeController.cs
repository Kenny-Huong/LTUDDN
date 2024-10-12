using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_LTUDDN_NguyenVanHuong_21103100115_M5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Nguyễn Văn Hướng _ DHTI15A5HN.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nguyễn Văn Hướng _ DHTI15A5HN.";

            return View();
        }
    }
}