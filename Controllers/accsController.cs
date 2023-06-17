using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using librarymanagementsystem.Models;

namespace librarymanagementsystem.Controllers
{
    public class accsController : Controller
    {
        private librarymanagementsystemContext db = new librarymanagementsystemContext();

        // GET: /accs/
        public ActionResult Index()
        {
            var accs = db.accs.Include(a => a.book);
            return View(accs.ToList());
        }

        // GET: /accs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acc acc = db.accs.Find(id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            return View(acc);
        }

        // GET: /accs/Create
        public ActionResult Create()
        {
            ViewBag.bookid = new SelectList(db.books, "bookid", "booktitle");
            return View();
        }

        // POST: /accs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="accno,bookid")] acc acc)
        {
            if (ModelState.IsValid)
            {
                db.accs.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookid = new SelectList(db.books, "bookid", "booktitle", acc.bookid);
            return View(acc);
        }

        // GET: /accs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acc acc = db.accs.Find(id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookid = new SelectList(db.books, "bookid", "booktitle", acc.bookid);
            return View(acc);
        }

        // POST: /accs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="accno,bookid")] acc acc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookid = new SelectList(db.books, "bookid", "booktitle", acc.bookid);
            return View(acc);
        }

        // GET: /accs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acc acc = db.accs.Find(id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            return View(acc);
        }

        // POST: /accs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acc acc = db.accs.Find(id);
            db.accs.Remove(acc);
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
        
        public ActionResult Acc()
        {
            return Redirect("../accs");
        }
        public ActionResult Back()
        {
            return View("../Home/form1");
        }
    }
}
