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
    public class ComplaintsController : Controller
    {
        private Model db = new Model();

        // GET: Complaints
        public ActionResult Index()
        {
            var complaint = db.Complaint.Include(c => c.Client).Include(c => c.ComplaintType).Include(c => c.Department).Include(c => c.Product);
            return View(complaint.ToList());
        }

        // GET: Complaints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaint.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: Complaints/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name");
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name");
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name");
            return View();
        }

        // POST: Complaints/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComplaint,IdClient,IdProduct,IdComplaintType,IdDepartment,CreationDate,detail")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Complaint.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaint.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComplaint,IdClient,IdProduct,IdComplaintType,IdDepartment,CreationDate,detail")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaint.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint complaint = db.Complaint.Find(id);
            db.Complaint.Remove(complaint);
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
