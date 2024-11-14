using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenVanHuong_BTTL_141124.Models;

namespace NguyenVanHuong_BTTL_141124.Controllers
{
    public class DiemsController : Controller
    {
        private QLSVDataContext db = new QLSVDataContext();

        // GET: Diems
        public ActionResult Index()
        {
            var diems = db.Diems.Include(d => d.SinhVien);
            return View(diems.ToList());
        }

        // GET: Diems/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Diem diem = db.Diems.Find(id, id2);
            Diem diem = db.Diems.FirstOrDefault(d=>d.maSV==id && d.maMonHoc==id2);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diems/Create
        public ActionResult Create()
        {
            ViewBag.maSV = new SelectList(db.SinhViens, "maSV", "hoTen");
            return View();
        }

        // POST: Diems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSV,maMonHoc,diemTBM")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maSV = new SelectList(db.SinhViens, "maSV", "hoTen", diem.maSV);
            return View(diem);
        }

        // GET: Diems/Edit/5
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, id2);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.maSV = new SelectList(db.SinhViens, "maSV", "hoTen", diem.maSV);
            return View(diem);
        }

        // POST: Diems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSV,maMonHoc,diemTBM")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maSV = new SelectList(db.SinhViens, "maSV", "hoTen", diem.maSV);
            return View(diem);
        }

        // GET: Diems/Delete/5
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null ||id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, id2);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            Diem diem = db.Diems.Find(id, id2);
            db.Diems.Remove(diem);
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
