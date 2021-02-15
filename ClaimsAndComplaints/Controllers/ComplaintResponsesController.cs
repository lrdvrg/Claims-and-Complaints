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
    public class ComplaintResponsesController : Controller
    {
        private Model db = new Model();

        // GET: ComplaintResponses
        public ActionResult Index()
        {
            var complaintResponse = db.ComplaintResponse.Include(c => c.Complaint).Include(c => c.Employee);
            return View(complaintResponse.ToList());
        }

        // GET: ComplaintResponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintResponse complaintResponse = db.ComplaintResponse.Find(id);
            if (complaintResponse == null)
            {
                return HttpNotFound();
            }
            return View(complaintResponse);
        }

        // GET: ComplaintResponses/Create
        public ActionResult Create()
        {
            ViewBag.IdComplaint = new SelectList(db.Complaint, "IdComplaint", "detail");
            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name");
            return View();
        }

        // POST: ComplaintResponses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComplaintResponse,IdComplaint,IdEmployee,ResponseDate,detail")] ComplaintResponse complaintResponse)
        {
            if (ModelState.IsValid)
            {
                db.ComplaintResponse.Add(complaintResponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdComplaint = new SelectList(db.Complaint, "IdComplaint", "detail", complaintResponse.IdComplaint);
            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name", complaintResponse.IdEmployee);
            return View(complaintResponse);
        }

        // GET: ComplaintResponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintResponse complaintResponse = db.ComplaintResponse.Find(id);
            if (complaintResponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdComplaint = new SelectList(db.Complaint, "IdComplaint", "detail", complaintResponse.IdComplaint);
            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name", complaintResponse.IdEmployee);
            return View(complaintResponse);
        }

        // POST: ComplaintResponses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComplaintResponse,IdComplaint,IdEmployee,ResponseDate,detail")] ComplaintResponse complaintResponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintResponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdComplaint = new SelectList(db.Complaint, "IdComplaint", "detail", complaintResponse.IdComplaint);
            ViewBag.IdEmployee = new SelectList(db.Employee, "IdEmployee", "Name", complaintResponse.IdEmployee);
            return View(complaintResponse);
        }

        // GET: ComplaintResponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintResponse complaintResponse = db.ComplaintResponse.Find(id);
            if (complaintResponse == null)
            {
                return HttpNotFound();
            }
            return View(complaintResponse);
        }

        // POST: ComplaintResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplaintResponse complaintResponse = db.ComplaintResponse.Find(id);
            db.ComplaintResponse.Remove(complaintResponse);
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
