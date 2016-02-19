using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GraphicsSite.Models;
using System.IO;

namespace GraphicsSite.Controllers
{
    [Authorize]
    public class VideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Videos
        public ActionResult Index()
        {
            return View(db.Videos.ToList());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = null;

            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Video video)
        {
            string pathToSave = "";
            string x = Request.Files[0].ToString();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files[i].ContentLength == 0) continue;
                string filename = Path.GetFileName(Request.Files[i].FileName);
                if (Request.Files.GetKey(i) == "uploadPowerPoint")
                {
                    pathToSave = Server.MapPath("~/Content/OtherContent");
                    video.PPPath = Path.Combine(pathToSave, Request.Files[i].FileName);
                }
                else if (Request.Files.GetKey(i) == "uploadWord")
                {
                    pathToSave = Server.MapPath("~/Content/OtherContent");
                    video.WordPath = Path.Combine(pathToSave, Request.Files[i].FileName);
                }
                else if (Request.Files.GetKey(i) == "uploadSketchUp")
                {
                    pathToSave = Server.MapPath("~/Content/OtherContent");
                    video.SUPath = Path.Combine(pathToSave, Request.Files[i].FileName);
                }


                Request.Files[i].SaveAs(Path.Combine(pathToSave, filename));
            }


            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Video video)
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].ContentLength == 0) continue;
                string pathToSave = Server.MapPath("~/Content/Videos/");
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                video.videoPath = Path.Combine(pathToSave, Request.Files[upload].FileName);
                Request.Files[upload].SaveAs(Path.Combine(pathToSave, filename));
            }
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
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
