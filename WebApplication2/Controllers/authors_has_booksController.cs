using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class authors_has_booksController : Controller
    {
        private BiblioEntities db = new BiblioEntities();

        // GET: authors_has_books
        public ActionResult Index()
        {
            var authors_has_books = db.authors_has_books.Include(a => a.authors).Include(a => a.books);
            return View(authors_has_books.ToList());
        }

        // GET: authors_has_books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authors_has_books authors_has_books = db.authors_has_books.Find(id);
            if (authors_has_books == null)
            {
                return HttpNotFound();
            }
            return View(authors_has_books);
        }

        // GET: authors_has_books/Create
        public ActionResult Create()
        {
            ViewBag.authors_id = new SelectList(db.authors, "id", "name");
            ViewBag.books_ISBN_INT = new SelectList(db.books, "ISBN_INT", "title");
            return View();
        }

        // POST: authors_has_books/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "authors_id,books_ISBN_INT")] authors_has_books authors_has_books)
        {
            if (ModelState.IsValid)
            {
                db.authors_has_books.Add(authors_has_books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authors_id = new SelectList(db.authors, "id", "name", authors_has_books.authors_id);
            ViewBag.books_ISBN_INT = new SelectList(db.books, "ISBN_INT", "title", authors_has_books.books_ISBN_INT);
            return View(authors_has_books);
        }

        // GET: authors_has_books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authors_has_books authors_has_books = db.authors_has_books.Find(id);
            if (authors_has_books == null)
            {
                return HttpNotFound();
            }
            ViewBag.authors_id = new SelectList(db.authors, "id", "name", authors_has_books.authors_id);
            ViewBag.books_ISBN_INT = new SelectList(db.books, "ISBN_INT", "title", authors_has_books.books_ISBN_INT);
            return View(authors_has_books);
        }

        // POST: authors_has_books/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "authors_id,books_ISBN_INT")] authors_has_books authors_has_books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authors_has_books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authors_id = new SelectList(db.authors, "id", "name", authors_has_books.authors_id);
            ViewBag.books_ISBN_INT = new SelectList(db.books, "ISBN_INT", "title", authors_has_books.books_ISBN_INT);
            return View(authors_has_books);
        }

        // GET: authors_has_books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authors_has_books authors_has_books = db.authors_has_books.Find(id);
            if (authors_has_books == null)
            {
                return HttpNotFound();
            }
            return View(authors_has_books);
        }

        // POST: authors_has_books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            authors_has_books authors_has_books = db.authors_has_books.Find(id);
            db.authors_has_books.Remove(authors_has_books);
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
