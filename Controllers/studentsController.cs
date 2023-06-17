
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using librarymanagementsystem.Models;
using System.Threading.Tasks;

namespace librarymanagementsystem.Controllers
{
    public class studentsController : Controller
    {
        private librarymanagementsystemContext db = new librarymanagementsystemContext();

        // GET: /students/
        public ActionResult Index(string searchName)
        {

            var students = from st in db.students select st;

            if (!String.IsNullOrEmpty(searchName))
            {
                students = students.Where(c => c.studentid.Contains(searchName));
            }

            return View(students);
        }

        // GET: /students/Details/5
      /*  public async Task<ActionResult> Details(string studentid)
        {
            if (studentid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string query = "select * from students where studentid=@p0";
            student stdetails = await db.students.SqlQuery(query, studentid).SingleOrDefaultAsync();
            if (stdetails == null)
            {
                return HttpNotFound();
            }
            return View(stdetails);
        }*/
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.SingleOrDefault(s => (s.studentid == id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="studentid,studentname,studentpassword,studentphno,studentemail")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="studentid,studentname,studentpassword,studentphno,studentemail")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /students/Delete/5
        public ActionResult Delete(string  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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
        public ActionResult Student()
        {
            return RedirectToAction("../students");
        }
        public ActionResult Back()
        {
            return View("../Home/form1");
        }
       
       
    }
}
