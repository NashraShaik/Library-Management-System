using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace librarymanagementsystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminlogin(Models.admin objlogin)
        {
            using (Models.librarymanagementsystemContext context = new Models.librarymanagementsystemContext())
            {
                var obj = context.admins.Where(a => a.adminid == objlogin.adminid && a.adminpassword == objlogin.adminpassword).FirstOrDefault(); ;
                if (obj != null)
                {
                    
                    return View("form1");
                }
                else
                    return View(objlogin);

            }
        }
        public ActionResult studentlogin()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult studentlogin(Models.student objlogin1)
        {
                using (Models.librarymanagementsystemContext context = new Models.librarymanagementsystemContext())
                {
                    
                    var obj1 = context.students.Where(a => a.studentid == objlogin1.studentid && a.studentpassword == objlogin1.studentpassword).First();
                    if (obj1 != null)
                    {
                        ViewBag.xyz = objlogin1.studentid;

                        Session["loginname"] = objlogin1.studentid;
                        return RedirectToAction("Details","students",new{ id=objlogin1.studentid});       
                    }
                    else
                        return View(objlogin1);
                }
        }
        

                    

       
        public ActionResult Logout()
        {
            return RedirectToAction("../Home");
        }
       




       
    }
}