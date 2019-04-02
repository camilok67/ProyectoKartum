using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Icosoft.Models;

namespace Icosoft.Controllers
{
    public class MedidaTipoesController : Controller
    {
        private IcosoftContext db = new IcosoftContext();

        // GET: MedidaTipoes
        public ActionResult Index()
        {
            return View(db.MedidaTipoes.ToList());
        }

        // GET: MedidaTipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidaTipo medidaTipo = db.MedidaTipoes.Find(id);
            if (medidaTipo == null)
            {
                return HttpNotFound();
            }
            return View(medidaTipo);
        }

        // GET: MedidaTipoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedidaTipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMEDIDATIPO,Nombre")] MedidaTipo medidaTipo)
        {
            if (ModelState.IsValid)
            {
                db.MedidaTipoes.Add(medidaTipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medidaTipo);
        }

        // GET: MedidaTipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidaTipo medidaTipo = db.MedidaTipoes.Find(id);
            if (medidaTipo == null)
            {
                return HttpNotFound();
            }
            return View(medidaTipo);
        }

        // POST: MedidaTipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMEDIDATIPO,Nombre")] MedidaTipo medidaTipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medidaTipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medidaTipo);
        }

        // GET: MedidaTipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidaTipo medidaTipo = db.MedidaTipoes.Find(id);
            if (medidaTipo == null)
            {
                return HttpNotFound();
            }
            return View(medidaTipo);
        }

        // POST: MedidaTipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedidaTipo medidaTipo = db.MedidaTipoes.Find(id);
            db.MedidaTipoes.Remove(medidaTipo);
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
