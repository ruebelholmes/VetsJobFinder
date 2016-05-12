using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VetsJobFinder.Models;
using VetsJobFinder.Models.ViewModels;

namespace VetsJobFinder.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();

        }

        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // Create Jobs
        public ActionResult Create()
        {
            return View();

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJobVM newJob)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                var currentUser = db.Users.Find(userid);

                var job = new Job
                {
                    Description = newJob.Description,
                    Title = newJob.Title,
                    EndApplicationDate = newJob.AppEnd,
                    StartApplicationDate = newJob.AppStart,
                    Employer = currentUser,
                    PostedOn = DateTime.Now
                };

                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newJob);
        }

        //Edit Jobs
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }

            var model = new EditJobVM();
            model.AppEnd = job.StartApplicationDate;
            model.AppStart = job.EndApplicationDate;
            model.Description = job.Description;
            model.Title = job.Title;
            return View(model);
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditJobVM editJob)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                var currentUser = db.Users.Find(userid);

                var job = new Job
                {
                    Description = editJob.Description,
                    Title = editJob.Title,
                    EndApplicationDate = editJob.AppEnd,
                    StartApplicationDate = editJob.AppStart,
                    Employer = currentUser,
                    PostedOn = DateTime.Now
                };

                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editJob);
        }

        // Delete Jobs
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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