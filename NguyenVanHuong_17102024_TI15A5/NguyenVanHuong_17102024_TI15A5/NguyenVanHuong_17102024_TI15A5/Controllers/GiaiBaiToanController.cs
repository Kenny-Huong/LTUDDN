using NguyenVanHuong_17102024_TI15A5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenVanHuong_17102024_TI15A5.Controllers
{
    public class GiaiBaiToanController : Controller
    {
        // GET: GiaiBaiToan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhapDLBT_UCLN()
        {
            return View();
        }
        public ActionResult NhanDL(Users u)
        {
            string msg = $"{u.Id}<br/>{u.Name}<br/>{u.Address}<br/>{u.Email}<br/>{u.Gender}<br/>{u.Password}<br/>";
            return Content(msg);
        }

        public ActionResult TimUCLN(int? a, int? b)
        {
            string msg = $"UCLN của {a} và  {b} : ";
            while (a != b)
            {
                if (a > b) a = a - b; else b = b - a;
            }
            msg += $"{a}";
            ViewBag.msg = msg ;
            //return Content(msg);
            return View();
        }

        public ActionResult TruyenDoiTuong()
        {
            var user = new Users
            {
                Id = 1,
                Name = "Hướng",
                Address = "Bắc Ninh",
                Email = "Kenny@gmail.com",
                Gender = true,
                Password = "123"
            };
            //ViewBag.user = user;

            return View(user); //truyền đối tượng qua hàm view
        }
        public ActionResult TruyenTapDoiTuong()
        {
            var users = new List<Users>{
                new Users
                {
                    Id = 2,
                    Name = "Cường",
                    Address = "Bắc Ninh",
                    Email = "Kenny@gmail.com",
                    Gender = true,
                    Password = "123"
                },

                new Users
                {
                    Id = 3,
                    Name = "Bằng",
                    Address = "Bắc Ninh",
                    Email = "Kenny@gmail.com",
                    Gender = true,
                    Password = "123"
                },

                new Users
                {
                    Id = 4,
                    Name = "Đạt",
                    Address = "Bắc Ninh",
                    Email = "Kenny@gmail.com",
                    Gender = true,
                    Password = "123"
                }   
            };
            //ViewBag.users = users;

            return View(users);
        }
    }
}