using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourJob.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Index2()
        {
            return View();
        }


        public ActionResult Login()
        {
            return PartialView();
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

        public ActionResult Search()
        {
            return File("~/Files/B2G1_Project_Proposal.pdf", "application/pdf");
        }



        //redirect result to facebook.com
        
        public ActionResult Red ()
        {
            return Redirect("http://www.facebook.com/chondromollika.ahmed.9");
        }
      
    }
}