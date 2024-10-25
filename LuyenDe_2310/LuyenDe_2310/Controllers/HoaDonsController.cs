using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuyenDe_2310.Models;

namespace LuyenDe_2310.Controllers
{
    public class HoaDonsController : Controller
    {
        // GET: HoaDons
        public ActionResult Index()
        {
            return View();
        }

        public static List<HoaDon> hoaDons = new List<HoaDon>
        {
            new HoaDon{SoHD="01", Ten="Báo tuổi trẻ", NgayDat="08/09/2003", SoLuong=5, DonGia=25000, MaKH="01"},
            new HoaDon{SoHD="02", Ten="Báo mua sắm", NgayDat="12/06/2024", SoLuong=10, DonGia=30000, MaKH="01"},
            new HoaDon{SoHD="03", Ten="Báo tuổi trẻ", NgayDat="09/08/2024", SoLuong=50, DonGia=25000, MaKH="02"}
        };
    }
}