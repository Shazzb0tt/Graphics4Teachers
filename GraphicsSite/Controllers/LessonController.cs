using GraphicsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraphicsSite.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        // GET: FreeLessons
        public ActionResult FreeLessons()
        {
            return View();
        }

        // GET: LessonSelection
        public ActionResult LessonSelection()
        {
            return View();
        }

        // GET: Lesson
        public ActionResult Lesson()
        {
            return View();
        }
    }
}