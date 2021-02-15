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
    public class ReclaimResponsesController : Controller
    {
        private Model db = new Model();

        // GET: ReclaimResponses
        public ActionResult Index()
        {
            var reclaimResponse = db.ReclaimResponse.Include(r => r.Employee).Include(r => r.Reclaim);
            return View(reclaimResponse.ToList());
        }

        // GET: ReclaimResponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimResponse reclaimResponse = db.ReclaimResponse.Find(id);
            if (reclaimResponse == null)
            {
                return HttpNotFound();
            }
            return View(reclaimResponse);
        }

        // GET: ReclaimResponses/Create
        public ActionResult Create()
        {
            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name");
            ViewBag.IdReclaim = new SelectList(db.Reclaim, "IdReclaim", "detail");
            return View();
        }

        // POST: ReclaimResponses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReclaimResponse,IdReclaim,IdEmployee,ResponseDate,detail")] ReclaimResponse reclaimResponse)
        {
            if (ModelState.IsValid)
            {
                db.ReclaimResponse.Add(reclaimResponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name", reclaimResponse.IdEmployee);
            ViewBag.IdReclaim = new SelectList(db.Reclaim, "IdReclaim", "detail", reclaimResponse.IdReclaim);
            return View(reclaimResponse);
        }

        // GET: ReclaimResponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimResponse reclaimResponse = db.ReclaimResponse.Find(id);
            if (reclaimResponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name", reclaimResponse.IdEmployee);
            ViewBag.IdReclaim = new SelectList(db.Reclaim, "IdReclaim", "detail", reclaimResponse.IdReclaim);
            return View(reclaimResponse);
        }

        // POST: ReclaimResponses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReclaimResponse,IdReclaim,IdEmployee,ResponseDate,detail")] ReclaimResponse reclaimResponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclaimResponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name", reclaimResponse.IdEmployee);
            ViewBag.IdReclaim = new SelectList(db.Reclaim, "IdReclaim", "detail", reclaimResponse.IdReclaim);
            return View(reclaimResponse);
        }

        // GET: ReclaimResponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimResponse reclaimResponse = db.ReclaimResponse.Find(id);
            if (reclaimResponse == null)
            {
                return HttpNotFound();
            }
            return View(reclaimResponse);
        }

        // POST: ReclaimResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReclaimResponse reclaimResponse = db.ReclaimResponse.Find(id);
            db.ReclaimResponse.Remove(reclaimResponse);
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
