using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AthleteAddaProject.Service;
using AthleteAddaProject.Models;

namespace AthleteAddaProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNews()
        {
            ViewBag.Message = "Your application description page.";
            if (User.IsInRole("Publisher") || User.IsInRole("SuperAdmin"))
            {
                return View();
            }
            else
                return View("Index");
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
    }
}