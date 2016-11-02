using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TableSourceCLE.Models;

namespace TableSourceCLE.Controllers
{
    public class DonorOrganizationsController : Controller
    {
        private TableSourceCLEContext db = new TableSourceCLEContext();

        // GET: DonorOrganizations
        public ActionResult Index()
        {
            var donorOrganizations = db.DonorOrganizations.Include(d => d.DonorCategory);
            return View(donorOrganizations.ToList());
        }

        // GET: DonorOrganizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorOrganization donorOrganization = db.DonorOrganizations.Find(id);
            if (donorOrganization == null)
            {
                return HttpNotFound();
            }
            return View(donorOrganization);
        }

        // GET: DonorOrganizations/Create
        public ActionResult Create()
        {
            ViewBag.donorCategoryID = new SelectList(db.DonorCategories, "donorCategoryID", "donorCategoryName");
            return View();
        }

        // POST: DonorOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "donorID,donorName,donorAddress,donorCity,donorState,donorZip,donorPhone,donorEmail,donorTaxID,donorCategoryID")] DonorOrganization donorOrganization)
        {
            if (ModelState.IsValid)
            {
                db.DonorOrganizations.Add(donorOrganization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.donorCategoryID = new SelectList(db.DonorCategories, "donorCategoryID", "donorCategoryName", donorOrganization.donorCategoryID);
            return View(donorOrganization);
        }

        // GET: DonorOrganizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorOrganization donorOrganization = db.DonorOrganizations.Find(id);
            if (donorOrganization == null)
            {
                return HttpNotFound();
            }
            ViewBag.donorCategoryID = new SelectList(db.DonorCategories, "donorCategoryID", "donorCategoryName", donorOrganization.donorCategoryID);
            return View(donorOrganization);
        }

        // POST: DonorOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "donorID,donorName,donorAddress,donorCity,donorState,donorZip,donorPhone,donorEmail,donorTaxID,donorCategoryID")] DonorOrganization donorOrganization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorOrganization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.donorCategoryID = new SelectList(db.DonorCategories, "donorCategoryID", "donorCategoryName", donorOrganization.donorCategoryID);
            return View(donorOrganization);
        }

        // GET: DonorOrganizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorOrganization donorOrganization = db.DonorOrganizations.Find(id);
            if (donorOrganization == null)
            {
                return HttpNotFound();
            }
            return View(donorOrganization);
        }

        // POST: DonorOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorOrganization donorOrganization = db.DonorOrganizations.Find(id);
            db.DonorOrganizations.Remove(donorOrganization);
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
