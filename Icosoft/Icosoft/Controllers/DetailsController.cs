using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Icosoft.Class;
using Icosoft.Models;

namespace Icosoft.Controllers
{
    public class DetailsController : Controller
    {
        private IcosoftContext db = new IcosoftContext();

        // GET: Details
        public ActionResult Index()
        {
            return View(db.Details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Details/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetailViews view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Image";

                if (view.ImageFile != null)
                {
                    pic = FileHelper.uploadphoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);

                }

                var detail = ToDetail(view);
                detail.Image = pic;

                db.Details.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Detail ToDetail(DetailViews view)
        {
            return new Detail
            {
                idDetail = view.idDetail,
                Height = view.Height,
                MeasureHeight = view.MeasureHeight,
                Width = view.Width,
                MeasureWidth = view.MeasureWidth,
                Depth = view.Depth,
                DepthMeasurement = view.DepthMeasurement,
                Image = view.Image,
                DescriptionAdmin = view.DescriptionAdmin,
                DescriptionUser = view.DescriptionUser

            };
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }

            return View(Toview(detail));
        }

        private DetailViews Toview(Detail detail)
        {
            return new DetailViews
            {
                idDetail = detail.idDetail,
                Height = detail.Height,
                MeasureHeight = detail.MeasureHeight,
                Width = detail.Width,
                MeasureWidth = detail.MeasureWidth,
                Depth = detail.Depth,
                DepthMeasurement = detail.DepthMeasurement,
                Image = detail.Image,
                DescriptionAdmin = detail.DescriptionAdmin,
                DescriptionUser = detail.DescriptionUser

            };
        }

        // POST: Details/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetailViews view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.Image;
                var folder = "~/Content/Image";

                if (view.ImageFile != null)
                {
                    pic = FileHelper.uploadphoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);

                }

                var detail = ToDetail(view);
                detail.Image = pic;

                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
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
