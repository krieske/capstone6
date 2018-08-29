using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capstone6.Models;

namespace capstone6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            capstone6Entities ORM = new capstone6Entities();


            ViewBag.Task = ORM.tasklists.ToList();

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

        public ActionResult ChangeStatus(int taskID)
        {
            capstone6Entities ORM = new capstone6Entities();

            tasklist task = ORM.tasklists.Find(taskID);
            task.status = true;

            ORM.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteTask(int taskID)
        {
            capstone6Entities ORM = new capstone6Entities();

            tasklist ItemToDelete = ORM.tasklists.Find(taskID);

            // remove
            ORM.tasklists.Remove(ItemToDelete);

            ORM.SaveChanges(); // To Do: use try catch

            return RedirectToAction("Index");

        }
    }
}