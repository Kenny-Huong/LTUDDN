using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTVN_Tuan6_NguyenVanHuong_21103100115.Models;

namespace BTVN_Tuan6_NguyenVanHuong_21103100115.Controllers
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
    }
}
