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
    public class SuppliesController : Controller
    {
        private IcosoftContext db = new IcosoftContext();

        // GET: Supplies
        public ActionResult Index()
        {
            var supplies = db.Supplies.Include(s => s.MedidaTipo).Include(s => s.Supplier);
            return View(supplies.ToList());
        }

        // GET: Supplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplie supplie = db.Supplies.Find(id);
            if (supplie == null)
            {
                return HttpNotFound();
            }
            return View(supplie);
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            ViewBag.IDMEDIDATIPO = new SelectList(db.MedidaTipoes, "IDMEDIDATIPO", "Nombre");
            ViewBag.idSuplier = new SelectList(db.Suppliers, "idSuplier", "SuplierName");
            return View();
        }

        // POST: Supplies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSupplie,SupplieName,idSuplier,IDMEDIDATIPO")] Supplie supplie)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supplie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMEDIDATIPO = new SelectList(db.MedidaTipoes, "IDMEDIDATIPO", "Nombre", supplie.IDMEDIDATIPO);
            ViewBag.idSuplier = new SelectList(db.Suppliers, "idSuplier", "SuplierName", supplie.idSuplier);
            return View(supplie);
        }

        // GET: Supplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplie supplie = db.Supplies.Find(id);
            if (supplie == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMEDIDATIPO = new SelectList(db.MedidaTipoes, "IDMEDIDATIPO", "Nombre", supplie.IDMEDIDATIPO);
            ViewBag.idSuplier = new SelectList(db.Suppliers, "idSuplier", "SuplierName", supplie.idSuplier);
            return View(supplie);
        }

        // POST: Supplies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSupplie,SupplieName,idSuplier,IDMEDIDATIPO")] Supplie supplie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMEDIDATIPO = new SelectList(db.MedidaTipoes, "IDMEDIDATIPO", "Nombre", supplie.IDMEDIDATIPO);
            ViewBag.idSuplier = new SelectList(db.Suppliers, "idSuplier", "SuplierName", supplie.idSuplier);
            return View(supplie);
        }

        // GET: Supplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplie supplie = db.Supplies.Find(id);
            if (supplie == null)
            {
                return HttpNotFound();
            }
            return View(supplie);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplie supplie = db.Supplies.Find(id);
            db.Supplies.Remove(supplie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Filtrar(string insumo, string proveedor)
        {
            var supplies = db.Supplies.Include(s => s.Supplier).Include(s=> s.MedidaTipo);
            if (!String.IsNullOrEmpty(insumo))
            {
                var insumoBusqueda = db.Supplies.Where(j => j.SupplieName.Contains(insumo)).Include(s => s.Supplier).Include(s => s.MedidaTipo);
                return View(insumoBusqueda);

            }

            else if (!String.IsNullOrEmpty(proveedor))
            {
                var insumoBusqueda = db.Supplies.Where(j => j.Supplier.SuplierName.Contains(proveedor)).Include(s => s.Supplier).Include(s => s.MedidaTipo);
                return View(insumoBusqueda);

            }

            return View(supplies);
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
