using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _26_LTUDDND_NguyenVanHuong_21103100115_DHTI15A5HN.Models;

namespace _26_LTUDDND_NguyenVanHuong_21103100115_DHTI15A5HN.Controllers
{
    public class HoaDonController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: HoaDon
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.MonAn);
            return View(hoaDons.ToList());
        }

        // GET: HoaDon/Details/5
        public ActionResult Details(int? id, int? maMon)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id, maMon);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon");
            return View();
        }
        public ActionResult FindTenMon()
        {
            return View();
        }

        // POST: HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoHD,MaMon,NgayLapHD,SoLuong")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDon.MaMon);
            return View(hoaDon);
        }

        // GET: HoaDon/Edit/5
        public ActionResult Edit(int? id, int? maMon)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id, maMon);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDon.MaMon);
            return View(hoaDon);
        }

        // POST: HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoHD,MaMon,NgayLapHD,SoLuong")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMon = new SelectList(db.MonAns, "MaMon", "TenMon", hoaDon.MaMon);
            return View(hoaDon);
        }

        // GET: HoaDon/Delete/5
        public ActionResult Delete(int? id, int? maMon)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id, maMon);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int maMon)
        {
            HoaDon hoaDon = db.HoaDons.Find(id, maMon);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchProduct(string tenMon)
        {
            if (string.IsNullOrEmpty(tenMon))
            {
                ViewBag.Message = "Vui lòng nhập tên món";
                return View();
            }
            var orders = db.HoaDons.Where(o=>o.MonAn.TenMon.Contains(tenMon)).ToList();    

            if (orders.Count == 0)
            {
                ViewBag.Message = "Không có món bạn nhập";
            }

            return View(orders.ToList());
        }
        public ActionResult XapXep()
        {
            var sapXep = db.HoaDons
                .OrderBy(b=>b.SoLuong)
                .ToList();
            return View(sapXep);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
