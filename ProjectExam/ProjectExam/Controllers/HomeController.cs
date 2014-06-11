using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace ProjectExam.Controllers
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

        public ActionResult PageExam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetTextMatch(string subText)
        {

            var matchString = new MatchStrings();
            var data = matchString.ProcessInput(subText);
            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}