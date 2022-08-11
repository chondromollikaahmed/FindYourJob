using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FindYourJob.Models;

namespace FindYourJob.Controllers
{
    public class JobPostsController : Controller
    {
        private FindYourJobEntities db = new FindYourJobEntities();

        // GET: JobPosts
        public ActionResult Index()
        {
            var jobPosts = db.JobPosts.Include(j => j.Company).Include(j => j.JobCategory).Include(j => j.Job).Include(j => j.JobStatu).Include(j => j.User);
            return View(jobPosts.ToList());
        }

        // GET: JobPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: JobPosts/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            ViewBag.JobCategoryID = new SelectList(db.JobCategories, "JobCategoryID", "CategoryName");
            ViewBag.JobID = new SelectList(db.Jobs, "JobsID", "JobTitle");
            ViewBag.JobStatusID = new SelectList(db.JobStatus, "JobStatusID", "JobStatus");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobPostsID,UserID,CompanyID,JobID,JobCategoryID,RequiredPerson,Qualification,MinimumExperience,AgeLimit,MarritalStatus,StartDate,EndDate,ShortlistDate,InterviewDate,JobStatusID,Description")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.JobPosts.Add(jobPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", jobPost.CompanyID);
            ViewBag.JobCategoryID = new SelectList(db.JobCategories, "JobCategoryID", "CategoryName", jobPost.JobCategoryID);
            ViewBag.JobID = new SelectList(db.Jobs, "JobsID", "JobTitle", jobPost.JobID);
            ViewBag.JobStatusID = new SelectList(db.JobStatus, "JobStatusID", "JobStatus", jobPost.JobStatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", jobPost.UserID);
            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", jobPost.CompanyID);
            ViewBag.JobCategoryID = new SelectList(db.JobCategories, "JobCategoryID", "CategoryName", jobPost.JobCategoryID);
            ViewBag.JobID = new SelectList(db.Jobs, "JobsID", "JobTitle", jobPost.JobID);
            ViewBag.JobStatusID = new SelectList(db.JobStatus, "JobStatusID", "JobStatus", jobPost.JobStatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", jobPost.UserID);
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobPostsID,UserID,CompanyID,JobID,JobCategoryID,RequiredPerson,Qualification,MinimumExperience,AgeLimit,MarritalStatus,StartDate,EndDate,ShortlistDate,InterviewDate,JobStatusID,Description")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", jobPost.CompanyID);
            ViewBag.JobCategoryID = new SelectList(db.JobCategories, "JobCategoryID", "CategoryName", jobPost.JobCategoryID);
            ViewBag.JobID = new SelectList(db.Jobs, "JobsID", "JobTitle", jobPost.JobID);
            ViewBag.JobStatusID = new SelectList(db.JobStatus, "JobStatusID", "JobStatus", jobPost.JobStatusID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", jobPost.UserID);
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
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
    }
}
