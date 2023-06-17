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
    public class issuesController : Controller
    {
        private librarymanagementsystemContext db = new librarymanagementsystemContext();

        // GET: /issues/
        public ActionResult Index(string searchName)
        {
            var issues = from pr in db.issues select pr;

            if (!String.IsNullOrEmpty(searchName))
            {
                issues = issues.Where(c => c.studentid.Contains(searchName));
            }

            return View(issues);
           
        }

        // GET: /issues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issue issue = db.issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }
        public ActionResult bookissuedetails()
        {
            List<issue> isue = db.issues.ToList();
            List<issue> x=new List<issue>();
            string rollno = Session["loginname"].ToString();
            foreach(issue i in isue)
            {
                if(rollno == i.studentid)
                {
                    x.Add(db.issues.Find(i.bookissueid));
                }
            }
            return View(x);
        }

        // GET: /issues/Create
        public ActionResult Create()
        {
            ViewBag.accno = new SelectList(db.accs, "accno", "accno");
            ViewBag.adminid = new SelectList(db.admins, "adminid", "adminpassword");
            ViewBag.studentid = new SelectList(db.students, "studentid", "studentname");
            return View();
        }

        // POST: /issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="bookissueid,adminid,studentid,accno,bookissuedate,bookduedate,bookreturndate,fine")] issue issue)
        {
            if (ModelState.IsValid)
            {
                db.issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accno = new SelectList(db.accs, "accno", "accno", issue.accno);
            ViewBag.adminid = new SelectList(db.admins, "adminid", "adminpassword", issue.adminid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "studentname", issue.studentid);
            return View(issue);
        }

        // GET: /issues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issue issue = db.issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.accno = new SelectList(db.accs, "accno", "accno", issue.accno);
            ViewBag.adminid = new SelectList(db.admins, "adminid", "adminpassword", issue.adminid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "studentname", issue.studentid);
            return View(issue);
        }

        // POST: /issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="bookissueid,adminid,studentid,accno,bookissuedate,bookduedate,bookreturndate,fine")] issue issue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accno = new SelectList(db.accs, "accno", "accno", issue.accno);
            ViewBag.adminid = new SelectList(db.admins, "adminid", "adminpassword", issue.adminid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "studentname", issue.studentid);
            return View(issue);
        }

        // GET: /issues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issue issue = db.issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        // POST: /issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            issue issue = db.issues.Find(id);
            db.issues.Remove(issue);
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
        public ActionResult Issue()
        {
            return RedirectToAction("../issues");
        }
        public ActionResult Back()
        {
            return View("../Home/form1");
        }
        public ActionResult Logout()
        {
            return RedirectToAction("../Home/studentlogin");
        }
        
    }
}
