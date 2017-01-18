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
            NewsFeedService newsFeedService = new NewsFeedService();
            List<NewsfeedModel> newsfeeds = newsFeedService.GetAllNewsFeeds();
            //todo:show data on page

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
    }
}