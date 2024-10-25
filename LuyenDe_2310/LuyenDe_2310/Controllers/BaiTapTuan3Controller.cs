using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuyenDe_2310.Controllers
{
    public class BaiTapTuan3Controller : Controller
    {
        // GET: BaiTapTuan3
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Address()
        {
            return View();
        }


        public ActionResult SoHoanHao(int? n)
        {
            List<int> SHHlist = new List<int>();

            for(int i = 1; i < n; i++)
            {
                if (laSoHoanHao(i))
                {
                    SHHlist.Add(i);
                }
            }
            ViewBag.SHHlist = SHHlist;
            ViewBag.n = n;
            return View();
        }

        private bool laSoHoanHao(int number)
        {
            int sum = 0;
            for(int i = 1; i < number; i++)
            {
                if(number % i == 0)
                {
                    sum += i;
                }
            }
            return sum == number;
        }

        public ActionResult SoChinhPhuong(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return View();
            }
            //Tách chuỗi -> số 
            string[] numArray = numbers.Split(',');
            List<int> soCPList = new List<int>();

            foreach(var item in numArray)
            {
                if(int.TryParse(item.Trim(), out int value))
                {
                    if (laSoCP(value))
                    {
                        soCPList.Add(value);
                    }
                }
            }
            ViewBag.numbers = numbers;
            ViewBag.soCPList = soCPList;
            return View();

        }
        
        private bool laSoCP(int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            return sqrt * sqrt == number;
        }
    }
}