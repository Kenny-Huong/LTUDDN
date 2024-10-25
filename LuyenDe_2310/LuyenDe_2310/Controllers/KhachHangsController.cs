using LuyenDe_2310.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LuyenDe_2310.Models;

namespace LuyenDe_2310.Controllers
{
    public class KhachHangsController : Controller
    {
        // GET: KhachHangs
        public ActionResult Index()
        {
            return View(khachHangs);
        }

        private static List<KhachHang> khachHangs = new List<KhachHang>
        {
            new KhachHang{MaKH="01", Ten="Nguyễn Văn Hướng", DT="0328869196", Email="nguyenvanhuong892003@gmail.com", GioiTinh="Nam", DiaChi="Bắc Ninh"},
            new KhachHang{MaKH="02", Ten="Nguyễn Tuấn Đạt", DT="0328869222", Email="okeok@GMAIL.COM", GioiTinh="Nam", DiaChi="Bắc Ninh"}
        };

       
    }
}