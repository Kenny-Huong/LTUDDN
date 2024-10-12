using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenVanHuong_101024.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        //Dùng layer mặc định khai báo trong view start
        public ActionResult Index()
        {
            //return View("KhongDungLayout");
            return View("~/Views/Home/About.cshtml");
        }

        public ActionResult KhongDungLayout()
        {
            return View();
        }

        public ActionResult DungLayoutChiDinhRieng()
        {
            return View();
        }
        //Truyền dữ liệu từ Controler -> View
        public ActionResult TruyenDuLieu()
        {
            ViewBag.hoTen = "Nguyễn Văn Hướng";
            ViewData["QueQuan"] = "Bắc Ninh";

            TempData["Tuoi"] = 21;
            //return View();

            return RedirectToAction("DungLayoutChiDinhRieng");
        }

        public ActionResult giaiPTB1(decimal a, decimal b)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            return View();
        }

        public ActionResult tongLe(decimal n)
        {
            ViewBag.n = n;
            return View();
        }

        public ActionResult tongLeManga(string arr)
        {
            //Tách chuỗi truy vấn thành một mảng số nguyên
            string[] arrStr = arr.Split(',');
            int[] a = Array.ConvertAll(arrStr, int.Parse);

            //Lọc các số lẻ và tính tổng 
            List<int> soLeList = new List<int>();
            int tongLe = 0;

            foreach (int num in a)
            {
                if(num % 2 != 0)
                {
                    soLeList.Add(num);
                    tongLe += num;
                }
            }

            ViewBag.SoLeList = soLeList;
            ViewBag.TongLe = tongLe;
            return View();
        }

        public ActionResult PTB2(decimal a, decimal b, decimal c)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            return View();
        }

        public ActionResult USCLN(decimal a, decimal b)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            return View();
        }

        public ActionResult SoNgayTrongThang(decimal month, decimal year)
        {
            ViewBag.month = month;
            ViewBag.year = year;
            return View();
        }

        private bool KiemTraSoNguyenTo(int n)
        {
            if(n < 2) return false;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0) return false;
            }
            return true;
        }
        public ActionResult TongMangSNT(string arr)
        {
            string[] arrStr = arr.Split(',');
            int[] a = Array.ConvertAll(arrStr, int.Parse);

            List<int> soNguyenToList = new List<int>();
            int tongSoNguyenTo = 0;

            foreach(int num in a)
            {
                if (KiemTraSoNguyenTo(num))
                {
                    soNguyenToList.Add(num);
                    tongSoNguyenTo += num;
                }
            }

            ViewBag.SoNguyenToList = soNguyenToList;
            ViewBag.TongSoNguyenTo = tongSoNguyenTo;


            return View();
        }
    }
}