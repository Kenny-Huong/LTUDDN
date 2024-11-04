using BTVN_Tuan4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTVN_Tuan4.Controllers
{
    
    public class NhanVienController : Controller
    {
        public static List<NhanVien> nhanViens = new List<NhanVien>
        {
            new NhanVien{maNV=1, hoTen="Nguyễn Văn Hướng", ngaySinh=DateTime.Parse("08/09/2003"), gioiTinh=true, dienThoai="0328869196", HSL=2, Luong=10000, tenPhong="Giám đốc" },
            new NhanVien{maNV=2, hoTen="Nguyễn Trọng Bằng", ngaySinh=DateTime.Parse("11/05/2003"), gioiTinh=true, dienThoai="0328888888", HSL=1, Luong=20000, tenPhong="Sale" },
            new NhanVien{maNV=3, hoTen="Nguyễn Việt Cường", ngaySinh=DateTime.Parse("11/11/2003"), gioiTinh=true, dienThoai="0328888888", HSL=3, Luong=40000, tenPhong="Marketing" },
            new NhanVien{maNV=4, hoTen="Nguyễn Hương Mai", ngaySinh=DateTime.Parse("02/03/2003"), gioiTinh=false, dienThoai="0321312312", HSL=3, Luong=40000, tenPhong="Marketing" },
            new NhanVien{maNV=5, hoTen="Nguyễn Lan Anh", ngaySinh=DateTime.Parse("12/12/2003"), gioiTinh=false, dienThoai="032132112312", HSL=3, Luong=40000, tenPhong="Sale" }
        }; 
        // GET: NhanVien
        public ActionResult Index()
        {
            return View(nhanViens);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int id)
        {
            var nhanvien = nhanViens.FirstOrDefault(u=>u.maNV==id);
            if(nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {

            ViewBag.tenPhong = new SelectList(new List<string> { "Giám đốc", "Sale", "Marketing" });
            return View();

        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien newNV)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    newNV.maNV = nhanViens.Max(u=>u.maNV) + 1;
                    nhanViens.Add(newNV);
                return RedirectToAction("Index");

                }
                return View(newNV);
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var nhanvien = nhanViens.FirstOrDefault(u=>u.maNV == id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.tenPhong = new SelectList(new List<string> { "Giám đốc", "Sale", "Marketing" });
            return View(nhanvien);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NhanVien updateNV)
        {
            try
            {
                // TODO: Add update logic here
                var nhanvien = nhanViens.FirstOrDefault(u=>u.maNV == id);
                if (nhanvien == null)
                {
                    return HttpNotFound();
               
                }else if (ModelState.IsValid)
                {
                    nhanvien.hoTen = updateNV.hoTen;
                    nhanvien.ngaySinh = updateNV.ngaySinh;
                    nhanvien.gioiTinh = updateNV.gioiTinh;
                    nhanvien.dienThoai  = updateNV.dienThoai;
                    nhanvien.HSL = updateNV.HSL;
                    nhanvien.Luong = updateNV.Luong;
                    nhanvien.tenPhong=updateNV.tenPhong;

                    return RedirectToAction("Index");

                }
                return View(updateNV);
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            var nhanvien = nhanViens.FirstOrDefault(u => u.maNV == id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.tenPhong = new SelectList(new List<string> { "Giám đốc", "Sale", "Marketing" });
            return View(nhanvien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var nhanvien = nhanViens.FirstOrDefault(u => u.maNV == id);
                if (nhanvien != null)
                {
                    nhanViens.Remove(nhanvien);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FindGirl()
        {
            var girlNV = nhanViens.Where(u=>u.gioiTinh==false).ToList();
            return View(girlNV);
        }
        [HttpGet]
        public ActionResult TotalSalary()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TotalSalary(string tenPhong)
        {
            if (string.IsNullOrEmpty(tenPhong))
            {
                ModelState.AddModelError("", "Tên phòng không được để trống.");
                return View();
            }

            var totalSalary = nhanViens
                .Where(u => u.tenPhong.Equals(tenPhong, StringComparison.OrdinalIgnoreCase))
                .Sum(u => u.Luong);

            ViewBag.TotalSalary = totalSalary;

            return View();
        }

        // GET: NhanVien/FindByDepartment
        public ActionResult FindByDepartment()
        {
            return View();
        }

        // POST: NhanVien/FindByDepartment
        [HttpPost]
        public ActionResult FindByDepartment(string tenPhong)
        {
            if (string.IsNullOrEmpty(tenPhong))
            {
                ModelState.AddModelError("", "Tên phòng không được để trống.");
                return View();
            }

            var nhanVienList = nhanViens
                .Where(u => u.tenPhong.Equals(tenPhong, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!nhanVienList.Any())
            {
                ViewBag.Message = "Không có nhân viên nào trong phòng này.";
            }

            ViewBag.NhanVienList = nhanVienList;

            return View();
        }
    }
}
