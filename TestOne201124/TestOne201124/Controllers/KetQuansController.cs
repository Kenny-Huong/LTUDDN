using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestOne201124.Models;

namespace TestOne201124.Controllers
{
    public class KetQuansController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: KetQuans
        public ActionResult Index()
        {
            var ketQuans = db.KetQuans.Include(k => k.NhanVien);
            return View(ketQuans.ToList());
        }

        // GET: KetQuans/Details/5
        public ActionResult Details(int? id, string tenSP)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQuan ketQuan = db.KetQuans.Find(id, tenSP);
            if (ketQuan == null)
            {
                return HttpNotFound();
            }
            return View(ketQuan);
        }

        // GET: KetQuans/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV");
            return View();
        }

        // POST: KetQuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenSP,DonGia,SoLuong")] KetQuan ketQuan)
        {
            if (ModelState.IsValid)
            {
                db.KetQuans.Add(ketQuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", ketQuan.MaNV);
            return View(ketQuan);
        }

        // GET: KetQuans/Edit/5
        public ActionResult Edit(int? id, string tenSP)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQuan ketQuan = db.KetQuans.Find(id, tenSP);
            if (ketQuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", ketQuan.MaNV);
            return View(ketQuan);
        }

        // POST: KetQuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenSP,DonGia,SoLuong")] KetQuan ketQuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketQuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", ketQuan.MaNV);
            return View(ketQuan);
        }

        // GET: KetQuans/Delete/5
        public ActionResult Delete(int? id, string tenSP)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQuan ketQuan = db.KetQuans.Find(id, tenSP);
            if (ketQuan == null)
            {
                return HttpNotFound();
            }
            return View(ketQuan);
        }

        // POST: KetQuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string tenSP)
        {
            KetQuan ketQuan = db.KetQuans.Find(id, tenSP);
            db.KetQuans.Remove(ketQuan);
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
    }
}
