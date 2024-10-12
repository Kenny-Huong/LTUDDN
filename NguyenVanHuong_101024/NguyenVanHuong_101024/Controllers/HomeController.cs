using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenVanHuong_101024.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //5. Code lại  và tìm hiểu từng hàm trong phần code mẫu sau(nhớ tạo action cho view này)

        //Html.BeginForm("Browse", "Home"): Tạo một form HTML bắt đầu với action là phương thức Browse trong controller Home.
        //Khi form này được submit, nó sẽ gửi dữ liệu đến hành động Browse trong controller Home.
        public ActionResult Brown()
        {
            return View();
        }
    }
}