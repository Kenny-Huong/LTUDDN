using QuanLyNguoiDung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNguoiDung.Controllers
{
    public class UsersController : Controller
    {
        public static List<Users> users = new List<Users>
        {
            new Users{Id=1, Name="Hướng", Address="Bắc Ninh", Email="kenny892003@gmail.com", Password="2003", ReEnterPassword="2003", Age=21, Gender=true, Date=DateTime.Parse("08/09/2003")},
            new Users{Id=2, Name="Khiêm", Address="Bắc Ninh", Email="kenny@gmail.com", Password="2003",ReEnterPassword="2003", Age=21, Gender=true,Date=DateTime.Parse("09/09/2003")},
            new Users{Id=3, Name="Ngọc", Address="Bắc Ninh", Email="huong@gmail.com", Password="2003",ReEnterPassword="2003", Age=21, Gender=false,Date=DateTime.Parse("11/09/2003")}
        };
        // GET: Users
        public ActionResult Index()
        {
          
            return View(users);
        }
        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age -= 1;

            return age;
        }


        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            List<SelectListItem> addressList = new List<SelectListItem>
            {
                new SelectListItem{Text="Hà Giang", Value="Hà Giang"},
                new SelectListItem{Text="Hà Nội", Value="Hà Nội"},
                new SelectListItem{Text="Bắc Ninh", Value="Bắc Ninh"},
                new SelectListItem{Text="Nam Định", Value="Nam Định"},
            };
            ViewBag.addressList = new SelectList(addressList, "Value", "Text");

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Users newUser)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    newUser.Id = users.Max(u=>u.Id) + 1;
                    newUser.Age = CalculateAge(newUser.Date);
                    users.Add(newUser);
                    return RedirectToAction("Index");
                }
                return View(newUser);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> addressList = new List<SelectListItem>
            {
                new SelectListItem{Text="Hà Giang", Value="Hà Giang"},
                new SelectListItem{Text="Hà Nội", Value="Hà Nội"},
                new SelectListItem{Text="Bắc Ninh", Value="Bắc Ninh"},
                new SelectListItem{Text="Nam Định", Value="Nam Định"},
            };
            ViewBag.addressList = new SelectList(addressList, "Value", "Text");
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Users updateUser)
        {
            try
            {
                // TODO: Add update logic here
                var user = users.FirstOrDefault(u=>u.Id == id);
                if (user == null)
                {
                    return HttpNotFound();
                }else if (ModelState.IsValid)
                {
                    user.Name = updateUser.Name;
                    user.Address = updateUser.Address;
                    user.Email = updateUser.Email;
                    user.Gender = updateUser.Gender;
                    user.Password = updateUser.Password;
                    user.ReEnterPassword = updateUser.ReEnterPassword;
                    user.Date = updateUser.Date;

                    // Tính lại tuổi dựa trên ngày sinh mới
                    user.Age = CalculateAge(updateUser.Date);

                    return RedirectToAction("Index");

                }
                return View(updateUser);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var user = users.FirstOrDefault(u=>u.Id==id);
                if(user != null)
                {
                    users.Remove(user);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
