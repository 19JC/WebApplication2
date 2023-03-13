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
    public class booksController : Controller
    {
        private BiblioEntities db = new BiblioEntities();

        // GET: books
        public ActionResult Index()
        {
            var books = db.books.Include(b => b.authors_has_books).Include(b => b.editorials);
            return View(books.ToList());
        }

        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: books/Create
        public ActionResult Create()
        {
            ViewBag.ISBN_INT = new SelectList(db.authors_has_books, "books_ISBN_INT", "books_ISBN_INT");
            ViewBag.editorials_id = new SelectList(db.editorials, "id", "name");
            return View();
        }

        // POST: books/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN_INT,editorials_id,title,synopsis,n_pages")] books books)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ISBN_INT = new SelectList(db.authors_has_books, "books_ISBN_INT", "books_ISBN_INT", books.ISBN_INT);
            ViewBag.editorials_id = new SelectList(db.editorials, "id", "name", books.editorials_id);
            return View(books);
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.ISBN_INT = new SelectList(db.authors_has_books, "books_ISBN_INT", "books_ISBN_INT", books.ISBN_INT);
            ViewBag.editorials_id = new SelectList(db.editorials, "id", "name", books.editorials_id);
            return View(books);
        }

        // POST: books/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN_INT,editorials_id,title,synopsis,n_pages")] books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ISBN_INT = new SelectList(db.authors_has_books, "books_ISBN_INT", "books_ISBN_INT", books.ISBN_INT);
            ViewBag.editorials_id = new SelectList(db.editorials, "id", "name", books.editorials_id);
            return View(books);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            books books = db.books.Find(id);
            db.books.Remove(books);
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
