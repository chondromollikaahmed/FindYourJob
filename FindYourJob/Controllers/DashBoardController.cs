using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourJob.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult PostJob()
        {
            return View();
        }

        

        public ActionResult ManageJobs()
        {
            return View();
        }


    }
}