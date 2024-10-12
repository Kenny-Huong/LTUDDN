using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_LTUDDN_NguyenVanHuong_21103100115_M5.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public string Index()
        {
            return "Tôi là view Index";
        }

        public string Welcome(string name, int id = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + " , Numtimes is = " + id);
        }

        public string giaiptbac2(decimal a, decimal b, decimal c)
        {
            string kq = $"Phương trình {a}x^2 + {b}x + {c} = 0\n\n";
            decimal delta = b * b - 4 * a * c;

            if (a == 0)
            {
                // Phương trình trở thành phương trình bậc nhất
                if (b != 0)
                {
                    decimal x = -c / b;
                    kq += $"Phương trình có nghiệm bậc nhất x = {x}";
                }
                else
                {
                    kq += "Phương trình vô nghiệm";
                }
            }
            else
            {
                if (delta > 0)
                {
                    double sqrtDelta = Math.Sqrt((double)delta);
                    decimal x1 = (-b + (decimal)sqrtDelta) / (2 * a);
                    decimal x2 = (-b - (decimal)sqrtDelta) / (2 * a);
                    kq += $"Phương trình có 2 nghiệm phân biệt: x1 = {x1} và x2 = {x2}";
                }
                else if (delta == 0)
                {
                    decimal x = -b / (2 * a);
                    kq += $"Phương trình có nghiệm kép: x = {x}";
                }
                else
                {
                    kq += "Phương trình vô nghiệm (vì delta < 0)";
                }
            }

            return kq;
        }
    }
}
