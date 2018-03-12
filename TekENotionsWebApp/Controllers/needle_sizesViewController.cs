using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TekENotionsWebApp.Models;

namespace TekENotionsWebApp.Controllers
{
    public class needle_sizesViewController : Controller
    {
        private TekENotionsEntities db = new TekENotionsEntities();

        // GET: needle_sizesView
        public ActionResult Index()
        {
            return View(db.needle_sizes.ToList());
        }

        // GET: needle_sizesView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            needle_sizes needle_sizes = db.needle_sizes.Find(id);
            if (needle_sizes == null)
            {
                return HttpNotFound();
            }
            return View(needle_sizes);
        }

        // GET: needle_sizesView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: needle_sizesView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "metric,id,us,hook")] needle_sizes needle_sizes)
        {
            if (ModelState.IsValid)
            {
                db.needle_sizes.Add(needle_sizes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(needle_sizes);
        }

        // GET: needle_sizesView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            needle_sizes needle_sizes = db.needle_sizes.Find(id);
            if (needle_sizes == null)
            {
                return HttpNotFound();
            }
            return View(needle_sizes);
        }

        // POST: needle_sizesView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "metric,id,us,hook")] needle_sizes needle_sizes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(needle_sizes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(needle_sizes);
        }

        // GET: needle_sizesView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            needle_sizes needle_sizes = db.needle_sizes.Find(id);
            if (needle_sizes == null)
            {
                return HttpNotFound();
            }
            return View(needle_sizes);
        }

        // POST: needle_sizesView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            needle_sizes needle_sizes = db.needle_sizes.Find(id);
            db.needle_sizes.Remove(needle_sizes);
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
