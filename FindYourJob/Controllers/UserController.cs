﻿using FindYourJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourJob.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult NewUser()
        {
            return View(new UserMD());
        }
    }
}