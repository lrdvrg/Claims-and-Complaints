using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClaimsAndComplaints.Models;

namespace ClaimsAndComplaints.Controllers
{
    public class ReclaimsController : Controller
    {
        private Model db = new Model();

        // GET: Reclaims
        public ActionResult Index()
        {
            var reclaim = db.Reclaim.Include(r => r.Client).Include(r => r.Department).Include(r => r.Product).Include(r => r.ReclaimType);
            return View(reclaim.ToList());
        }

        // GET: Reclaims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclaim reclaim = db.Reclaim.Find(id);
            if (reclaim == null)
            {
                return HttpNotFound();
            }
            return View(reclaim);
        }

        // GET: Reclaims/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name");
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name");
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name");
            return View();
        }

        // POST: Reclaims/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReclaim,IdClient,IdProduct,IdReclaimType,IdDepartment,CreationDate,detail")] Reclaim reclaim)
        {
            if (ModelState.IsValid)
            {
                db.Reclaim.Add(reclaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name", reclaim.IdClient);
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", reclaim.IdProduct);
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name", reclaim.IdReclaimType);
            return View(reclaim);
        }

        // GET: Reclaims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclaim reclaim = db.Reclaim.Find(id);
            if (reclaim == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name", reclaim.IdClient);
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", reclaim.IdProduct);
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name", reclaim.IdReclaimType);
            return View(reclaim);
        }

        // POST: Reclaims/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReclaim,IdClient,IdProduct,IdReclaimType,IdDepartment,CreationDate,detail")] Reclaim reclaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name", reclaim.IdClient);
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", reclaim.IdProduct);
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name", reclaim.IdReclaimType);
            return View(reclaim);
        }

        // GET: Reclaims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclaim reclaim = db.Reclaim.Find(id);
            if (reclaim == null)
            {
                return HttpNotFound();
            }
            return View(reclaim);
        }

        // POST: Reclaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclaim reclaim = db.Reclaim.Find(id);
            db.Reclaim.Remove(reclaim);
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
