using BTVN_Tuan4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTVN_Tuan4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout(DangNhap model)
        {
            string msg = "";
            if (model.username == "admin" && model.password == "admin")
            {
                msg += "Đăng nhập thành công ! Chào mừng admin";
            }
            else
            {
                msg += "Sai tài khoản hoặc mật khẩu";
            }
            ViewBag.msg = msg;
            return View();
        }
    }
}