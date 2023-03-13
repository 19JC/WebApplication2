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
    public class editorialsController : Controller
    {
        private BiblioEntities db = new BiblioEntities();

        // GET: editorials
        public ActionResult Index()
        {
            return View(db.editorials.ToList());
        }

        // GET: editorials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            editorials editorials = db.editorials.Find(id);
            if (editorials == null)
            {
                return HttpNotFound();
            }
            return View(editorials);
        }

        // GET: editorials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: editorials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,headquarters")] editorials editorials)
        {
            if (ModelState.IsValid)
            {
                db.editorials.Add(editorials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editorials);
        }

        // GET: editorials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            editorials editorials = db.editorials.Find(id);
            if (editorials == null)
            {
                return HttpNotFound();
            }
            return View(editorials);
        }

        // POST: editorials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,headquarters")] editorials editorials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editorials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editorials);
        }

        // GET: editorials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            editorials editorials = db.editorials.Find(id);
            if (editorials == null)
            {
                return HttpNotFound();
            }
            return View(editorials);
        }

        // POST: editorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            editorials editorials = db.editorials.Find(id);
            db.editorials.Remove(editorials);
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
