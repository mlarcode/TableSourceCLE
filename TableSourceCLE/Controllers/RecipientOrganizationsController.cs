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
    public class RecipientOrganizationsController : Controller
    {
        private TableSourceCLEContext db = new TableSourceCLEContext();

        // GET: RecipientOrganizations
        public ActionResult Index()
        {
            var recipientOrganizations = db.RecipientOrganizations.Include(r => r.RecipientCategory);
            return View(recipientOrganizations.ToList());
        }

        // GET: RecipientOrganizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipientOrganization recipientOrganization = db.RecipientOrganizations.Find(id);
            if (recipientOrganization == null)
            {
                return HttpNotFound();
            }
            return View(recipientOrganization);
        }

        // GET: RecipientOrganizations/Create
        public ActionResult Create()
        {
            ViewBag.recipientCategoryID = new SelectList(db.RecipientCategories, "recipientCategoryID", "recipientCategoryName");
            return View();
        }

        // POST: RecipientOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recipientID,recipientName,recipientAddress,recipientCity,recipientState,recipientZip,recipientPhone,recipientEmail,recipientTaxID,recipientCategoryID")] RecipientOrganization recipientOrganization)
        {
            if (ModelState.IsValid)
            {
                db.RecipientOrganizations.Add(recipientOrganization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recipientCategoryID = new SelectList(db.RecipientCategories, "recipientCategoryID", "recipientCategoryName", recipientOrganization.recipientCategoryID);
            return View(recipientOrganization);
        }

        // GET: RecipientOrganizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipientOrganization recipientOrganization = db.RecipientOrganizations.Find(id);
            if (recipientOrganization == null)
            {
                return HttpNotFound();
            }
            ViewBag.recipientCategoryID = new SelectList(db.RecipientCategories, "recipientCategoryID", "recipientCategoryName", recipientOrganization.recipientCategoryID);
            return View(recipientOrganization);
        }

        // POST: RecipientOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recipientID,recipientName,recipientAddress,recipientCity,recipientState,recipientZip,recipientPhone,recipientEmail,recipientTaxID,recipientCategoryID")] RecipientOrganization recipientOrganization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipientOrganization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recipientCategoryID = new SelectList(db.RecipientCategories, "recipientCategoryID", "recipientCategoryName", recipientOrganization.recipientCategoryID);
            return View(recipientOrganization);
        }

        // GET: RecipientOrganizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipientOrganization recipientOrganization = db.RecipientOrganizations.Find(id);
            if (recipientOrganization == null)
            {
                return HttpNotFound();
            }
            return View(recipientOrganization);
        }

        // POST: RecipientOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipientOrganization recipientOrganization = db.RecipientOrganizations.Find(id);
            db.RecipientOrganizations.Remove(recipientOrganization);
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
