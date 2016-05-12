using System.Web.Mvc;
using VetsJobFinder.Models;

namespace VetsJobFinder.Controllers
{
    public class DashboardController : Controller
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
    }
}