using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NguyenVanHuong_BTVN_Tuan3.Models;

namespace NguyenVanHuong_BTVN_Tuan3.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        //Bài 1 : 1. Dùng DropDownListFor Sửa view sao cho nhập dữ liệu Address nhập trên một danh sách chọn
        //gồm 1 ds gồm Hà Nội, Nam Định, Hải Dương, Hà Giang

        public ActionResult Address()
        {
            return View();
        }
        //Bài 2 : 2.  Tìm số hoàn hảo trong phạm vi n, với n nhập trên form giao diện
        //. Sau đó kích nút submit sẽ tiến hành giải và hiển thị kết quả ra web
        public ActionResult SoHoanHao(int? n)
        {
            List<int> perfectNumbers = new List<int>();

            // Tìm các số hoàn hảo trong khoảng từ 1 đến n
            for (int i = 1; i <= n; i++)
            {
                if (IsPerfectNumber(i))
                {
                    perfectNumbers.Add(i);
                }
            }

            ViewBag.PerfectNumbers = perfectNumbers;
            ViewBag.n = n;
            return View();
        }
        // Hàm kiểm tra số hoàn hảo
        private bool IsPerfectNumber(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum == number;
        }


        //Bài 3 :3.  Tìm số chính phương của một mảng với các phần tử nhập trên form giao diện.
        //Sau đó kích nút submit sẽ tiến hành giải và hiển thị kết quả ra web.

        public ActionResult SoChinhPhuong(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                ViewBag.Error = "Vui lòng nhập các số.";
                return View();
            }

            //Tách chuỗi thành các mảng số 
            string[] numArray = numbers.Split(',');
            List<int> soChinhPhuongList = new List<int>();

            //Duyệt qua và kiểm tra xem có phải SCP không
            foreach (var numStr in numArray)
            {
                if(int.TryParse(numStr.Trim(), out int num))
                {
                    //Kiểm tra số chính phương
                    if (laSoChinhPhuong(num))
                    {
                       soChinhPhuongList.Add(num);
                    }
                }
            }
            ViewBag.SoChinhPhuongList = soChinhPhuongList;
            ViewBag.Numbers = numbers;
            return View();
        }

        private bool laSoChinhPhuong(int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            return sqrt * sqrt == number;
        }
        public ActionResult GiaiPTB2()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult GiaiPTB2(PhuongTrinhBacHai model)
        {
            
            double delta = model.B * model.B - 4 * model.A * model.C;
            string ketQua;
            if(delta < 0)
            {
                ketQua = "Phương trình vô nghiệm";
            }else if(delta == 0)
            {
                double x = -model.B / (2 * model.A);
                ketQua = $"Phương trình có nghiệm kép : x1 = x2 = {x}";
            }
            else
            {
                double x1 = (-model.B + System.Math.Sqrt(delta)) / (2 * model.A);
                double x2 = (-model.B - System.Math.Sqrt(delta)) / (2 * model.A);
                ketQua = $"Phương trình có hai nghiệm phân biệt : x1= {x1}, x2= {x2}";
            }
            ViewBag.KetQua = ketQua;
            return View();
        }
       
        
        public ActionResult TruyenSinhVien()
        {
            var sinhVien = new List<SinhVien>()
            {
                new SinhVien { MaSinhVien = "SV01", HoTen = "Nguyễn Văn Hướng", NgaySinh = "08/09/2003", GioiTinh = "Nam", QueQuan = "Bắc Ninh", LopHoc = "CNTT5" },
                new SinhVien { MaSinhVien = "SV02", HoTen = "Nguyễn Việt Cường", NgaySinh = "20/11/2003", GioiTinh = "Nữ", QueQuan = "Bắc Ninh", LopHoc = "CNTT3" },
                new SinhVien { MaSinhVien = "SV03", HoTen = "Nguyễn Trọng Bằng", NgaySinh = "21/11/2003", GioiTinh = "Nam", QueQuan = "Bắc Ninh", LopHoc = "CNTT23" }
            };
            ViewBag.sinhVien = sinhVien;
            return View();
        }
    }
}