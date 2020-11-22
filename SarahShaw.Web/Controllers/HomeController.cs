using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SarahShaw.DAL;

namespace SarahShaw.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            JobsRepository jobsIO = new JobsRepository();
            return View(jobsIO.GetAllJobs());
        }
    }
}