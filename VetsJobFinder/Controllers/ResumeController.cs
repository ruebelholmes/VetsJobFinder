    using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VetsJobFinder.Models;
using VetsJobFinder.Models.ViewModels;

namespace VetsJobFinder.Controllers
{
    [Authorize]
    public class ResumeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resumes
        public ActionResult Index()
        {
            return View(db.Resumes.ToList());
        }

        // Resume Details
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

        // Create Resume
        public ActionResult Create()
        {
            return View();
        }

        
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

        // Edit Resume
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditResumeVM editResume)
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

        // Delete Resume
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