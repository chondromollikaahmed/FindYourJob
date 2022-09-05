using FindYourJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindYourJob.Controllers
{
    public class UserController : Controller
    {



        private FindYourJobEntities db = new FindYourJobEntities();
        // GET: User
        public ActionResult NewUser()
        {


                int usertypeid = 0;
                if (!string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
                {
                    int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);

                 return RedirectToAction("Index","home");
                }

            ViewBag.userTypeId = new SelectList(db.UserTypes.ToList(), "UserTypeID", "UserType", " 0");
            return View(new UserMD());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUser(UserMD userMD)
        {

            ViewBag.userTypeId = new SelectList(db.UserTypes.ToList(), "UserTypeID", "UserType", userMD.UserTypeID);

            if (ModelState.IsValid)
            {
                var checkuser =
                    db.Users.Where(x => x.EmailAddress == userMD.EmailAddress).FirstOrDefault();

                if (checkuser != null)
                {
                    ModelState.AddModelError("EmailAddress", "Email Is Already Registared");

                    return View(userMD);
                }


                checkuser =
                   db.Users.Where(x => x.UserName == userMD.UserName).FirstOrDefault();

                if (checkuser != null)
                {
                    ModelState.AddModelError("UserName", "UserName Is Already Registared");

                    return View(userMD);
                }



                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var user = new User();

                        user.UserName = userMD.UserName;
                        user.EmailAddress = userMD.EmailAddress;
                        user.Password = userMD.Password;
                        user.ContactNo = userMD.ContactNo;
                        user.UserTypeID = 2;
                        user.AccountStatusID = 3;

                        db.Users.Add(user);

                        db.SaveChanges();

                        trans.Commit();
                        return RedirectToAction("Login");
                    }

                    catch (Exception e)
                    {

                        ModelState.AddModelError(String.Empty, e);
                        trans.Rollback();
                        throw;
                    }


                }



            }

            return View(userMD);


        }


        public ActionResult Login()
        {


            int usertypeid = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserTypeID"])))
            {
                int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);

                return RedirectToAction("Index", "home");
            }


            return View(new LoginMD());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginMD loginMD)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(x => x.UserName == loginMD.UserName && x.Password == loginMD.Password).FirstOrDefault();

                if (user != null)
                {
                    Session["UserID"] = user.UserID;
                    Session["UserName"] = user.UserName;
                    Session["UserTypeID"] = user.UserTypeID;
                    Session["AccountStatusID"] = user.AccountStatusID;

                    if (user.UserTypeID == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (user.UserTypeID == 2)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (user.UserTypeID == 3)
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    else if (user.UserTypeID == 4)
                    {
                        return RedirectToAction("Index", "Company");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "Invalid Email or Password");
                }
            }

            return View(loginMD);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }

    }
}
