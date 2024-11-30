using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookTruyVanLinq_NVH.Models;

namespace BookTruyVanLinq_NVH.Controllers
{
    public class BooksController : Controller
    {
        private BookDataContext db = new BookDataContext();

        // GET: Books
        public ActionResult Index(string searchString)
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim().ToLower();
                books = books.Where(b => b.Title.Trim().ToLower().Contains(searchString)
                    || b.Description.Contains(searchString));
            }
            return View(books.ToList());
        }
        public ActionResult GroupedBookByCategory()
        {
            var gbooks = db.Books.GroupBy(b=>b.Category.CategoryName)
                .Select(g=>new BookByCategoryViewModel{CategoryName= g.Key,BookCount= g.Count()}).ToList();
            return View(gbooks);
        }
        public ActionResult YC1(String searchString)
        {
            var result = db.Books
    .GroupBy(b => b.Author.AuthorName)
    .Select(g => new BookByAuthorViewModel
    {
        AuthorName = g.Key,
        TotalPrice = g.Sum(b => b.Price) ?? 0 // Trả về 0 nếu tổng là null

    })
    .ToList();
            return View(result);
        }
            public ActionResult SachLon20k()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            books = books.Where(b => b.Price > 20000);
            return View(books.ToList());
        }
        public ActionResult SelectTitlePrice() //Phép chiếu
        {
            var books = db.Books.Select(b => new BookViewModel { Title = b.Title, Price = b.Price });
            return View(books.ToList());
        }
        public ActionResult HaiSachGiaMax() 
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            books = books.OrderByDescending(b => b.Price)
            .Skip(1) // bỏ quan phần tử đầu tiên
            .Take(2); // lấy 2 phần tử tiếp theo
            return View(books.ToList()); // sách có giá cao thứ tự 2 3
        }
        public ActionResult cheapBook()
        {
            var books = db.Books.OrderBy(b=>b.Price).ToList();
            var cheapBook = books.TakeWhile(b => b.Price < 20000);

            return View(cheapBook.ToList());
        }
        public ActionResult expensiveBook()
        {
            var books = db.Books.OrderBy(b => b.Price).ToList();
            var expensiveBook = books.SkipWhile(b => b.Price < 20000);

            return View(expensiveBook.ToList());
        }
        public ActionResult SumMaxMinAvegare() 
        {
            var sumPrice = db.Books.Sum(b => b.Price);
            var maxPrice = db.Books.Max(b => b.Price);
            var minPrice = db.Books.Min(b => b.Price);
            var avgPrice = db.Books.Average(b => b.Price);

            var booksMax = db.Books.Where(b => b.Price == maxPrice);

            ViewBag.SumPrice = sumPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.MinPrice = minPrice;
            ViewBag.AvgPrice = avgPrice;

            //string message;
            //var check = db.Books.Any(b => b.Price > 200000);
            //if (check == true) message = "Có cuốn sách giá  > 200000";
            //else message =  "Không có cuốn nào giá > 200000";
            //ViewBag.Message = message;

            string message;
            var check = db.Books.All(b => b.Price > 200000);
            if (check == true) message = "Tất cả sách có giá  > 200000";
            else message = "Tất cả sách không phải có  giá > 200000";
            ViewBag.Message = message;

            var bookCount = db.Books.Count();
            var sosachcuagtAnh = db.Books.Count(b => b.Author.AuthorName.Contains("Anh"));
            ViewBag.sosachcuagtAnh = sosachcuagtAnh;


            return View(booksMax.ToList());
        }
        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
