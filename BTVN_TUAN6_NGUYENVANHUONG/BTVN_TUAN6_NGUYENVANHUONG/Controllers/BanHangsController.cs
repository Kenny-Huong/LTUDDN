using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTVN_TUAN6_NGUYENVANHUONG.Models;

namespace BTVN_TUAN6_NGUYENVANHUONG.Controllers
{
    public class BanHangsController : Controller
    {
        private QLBHDataContext db = new QLBHDataContext();

        // GET: BanHangs
        public ActionResult Index()
        {
            var banHangs = db.banHangs.Include(b => b.NhanVien).Include(b => b.SanPham);
            return View(banHangs.ToList());
        }

        // GET: BanHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanHang banHang = db.banHangs.Find(id);
            if (banHang == null)
            {
                return HttpNotFound();
            }
            return View(banHang);
        }

        // GET: BanHangs/Create
        public ActionResult Create()
        {
            ViewBag.maNV = new SelectList(db.nhanViens, "maNV", "tenQuay");
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "tenSP");
            return View();
        }

        // POST: BanHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,maNV,maSP,dinhMuc,soLuongBan")] BanHang banHang)
        {
            if (ModelState.IsValid)
            {
                db.banHangs.Add(banHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maNV = new SelectList(db.nhanViens, "maNV", "tenQuay", banHang.maNV);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "tenSP", banHang.maSP);
            return View(banHang);
        }

        // GET: BanHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanHang banHang = db.banHangs.Find(id);
            if (banHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNV = new SelectList(db.nhanViens, "maNV", "tenQuay", banHang.maNV);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "tenSP", banHang.maSP);
            return View(banHang);
        }

        // POST: BanHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,maNV,maSP,dinhMuc,soLuongBan")] BanHang banHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNV = new SelectList(db.nhanViens, "maNV", "tenQuay", banHang.maNV);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "tenSP", banHang.maSP);
            return View(banHang);
        }

        // GET: BanHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanHang banHang = db.banHangs.Find(id);
            if (banHang == null)
            {
                return HttpNotFound();
            }
            return View(banHang);
        }

        // POST: BanHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BanHang banHang = db.banHangs.Find(id);
            db.banHangs.Remove(banHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //Cho biết thông tin chi tiết bán hàng của sản phẩm được nhập trên TextBox tìm kiếm
        public ActionResult SearchProduct(string masp)
        {
            if (string.IsNullOrEmpty(masp))
            {
                ViewBag.Message = "Vui lòng nhập mã sản phảm";
                return View();
            }
            var orders = db.banHangs.Include(o=>o.SanPham)
                                    .Where(o=>o.SanPham.maSP.Contains(masp))
                                    .ToList();

            if(orders.Count == 0)
            {
                ViewBag.Message = "Không có sản phẩm nào với mã sản phẩm bạn đã nhập";
            }

            return View(orders.ToList());
        }
        //Cho biết  tổng số lượng bán của từng nhân viên. Thông tin bao gồm: họ tên, tổng số lượng bán
        public ActionResult GetTotalSalesByEmployee()
        {
            //Nhóm các đơn hàng theo nhân viên và tính tổng số lượng bán
            var totalSalesByEmployee = db.banHangs
                    .GroupBy(b=>b.NhanVien)
                    .Select(g=> new EmployeeSalesViewModel
                    {
                        HoTen = g.Key.hoTen,
                        TotalQuantitySold = g.Sum(b=>b.soLuongBan)
                    })
                    .ToList();

            return View(totalSalesByEmployee);
        }
        //Cho biết danh sách chi tiết bán hàng vượt định mức, sắp xếp theo chiều giảm dần.(số lượng bán > định mức)
        public ActionResult GetSalesAboveLimit()
        {
            //Lọc các bản ghi có số lượng bán > định mức và sắp xếp theo số lượng bán giảm dần
            var salesAboveLimit = db.banHangs
                .Where(b=>b.soLuongBan>b.dinhMuc)
                .OrderByDescending(b=>b.soLuongBan)
                .Include(b=>b.SanPham)
                .Include(b=>b.NhanVien)
                .ToList();

            return View(salesAboveLimit);
        }


        //cho biết mặt hàng nào bán với tổng số lượng nhiều nhất, thông tin bao gồm tên sản phẩm, tổng số lượng nhiều nhất.
        public ActionResult GetBestSellingProduct()
        {
            //Nhóm các bản ghi theo sản phẩm và tính tổng số lượng bán cho mỗi sản phẩm
            var bestSellingProduct = db.banHangs
                .GroupBy(b=>b.SanPham)
                .Select(g => new EmployeeBestSellingViewModel
                {
                    TenSanPham = g.Key.tenSP, //Lấy tên sản phẩm
                    TotalQuantitySold = g.Sum(b=>b.soLuongBan) //tính tổng số lượng bán
                })
                .OrderByDescending(g=>g.TotalQuantitySold) //Sắp xếp theo tổng số lượng bán 
                .FirstOrDefault(); // lấy sản phẩm có số lượng bán cao nhất 

              return View(bestSellingProduct);
        }
    }
}
