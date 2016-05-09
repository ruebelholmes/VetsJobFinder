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
    public class ResumesTempController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resumes
        public ActionResult Index()
        {
            return View(db.Resumes.ToList());
        }

        // GET: Resumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // GET: Resumes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resumes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateResumeVM newResume)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                var currentUser = db.Users.Find(userid);

                var resume = new Resume
                {
                   Description = newResume.Description, 
                    Title = newResume.Title,
                    PostedOn = DateTime.Now,
                   // Veteran = currentUser
                };

                db.Resumes.Add(resume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newResume);
        }

        // GET: Resumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }

            var model = new EditResumeVM();
            model.Description = resume.Description;
            model.Title = resume.Title;

            return View(model);
        }

        // POST: Resumes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EditResumeVM editResume)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                var currentUser = db.Users.Find(userid);

                var resume = new Resume
                {
                    Description = editResume.Description,
                    Title = editResume.Title
                };


                db.Resumes.Add(resume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Resumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // POST: Resumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resume resume = db.Resumes.Find(id);
            db.Resumes.Remove(resume);
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
