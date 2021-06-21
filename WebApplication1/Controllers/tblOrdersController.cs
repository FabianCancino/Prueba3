using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class tblOrdersController : Controller
    {
        private CamboxEntities db = new CamboxEntities();

        // GET: tblOrders
        public ActionResult Index()
        {
            return View(db.tblOrder.ToList());
        }

        // GET: tblOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrder.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            return View(tblOrder);
        }

        // GET: tblOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOrder,Date")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.tblOrder.Add(tblOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOrder);
        }

        // GET: tblOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrder.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            return View(tblOrder);
        }

        // POST: tblOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOrder,Date")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOrder);
        }

        // GET: tblOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrder.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            return View(tblOrder);
        }

        // POST: tblOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOrder tblOrder = db.tblOrder.Find(id);
            db.tblOrder.Remove(tblOrder);
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
