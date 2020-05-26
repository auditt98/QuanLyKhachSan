using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLKS.Domain;

namespace QLKS.Controllers
{
    public class VATTUsController : Controller
    {
        private QLKSContext db = new QLKSContext();

        // GET: VATTUs
        public ActionResult Index()
        {
            var vATTUs = db.VATTUs.Include(v => v.PHONG);
            return View(vATTUs.ToList());
        }

        // GET: VATTUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VATTU vATTU = db.VATTUs.Find(id);
            if (vATTU == null)
            {
                return HttpNotFound();
            }
            return View(vATTU);
        }

        // GET: VATTUs/Create
        public ActionResult Create()
        {
            ViewBag.PHONG_ID = new SelectList(db.PHONGs, "ID", "ma");
            return View();
        }

        // POST: VATTUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ten,ngaymua,ngaysudung,soluong,mota,sotien,PHONG_ID")] VATTU vATTU)
        {
            if (ModelState.IsValid)
            {
                db.VATTUs.Add(vATTU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PHONG_ID = new SelectList(db.PHONGs, "ID", "ma", vATTU.PHONG_ID);
            return View(vATTU);
        }

        // GET: VATTUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VATTU vATTU = db.VATTUs.Find(id);
            if (vATTU == null)
            {
                return HttpNotFound();
            }
            ViewBag.PHONG_ID = new SelectList(db.PHONGs, "ID", "ma", vATTU.PHONG_ID);
            return View(vATTU);
        }

        // POST: VATTUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ten,ngaymua,ngaysudung,soluong,mota,sotien,PHONG_ID")] VATTU vATTU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vATTU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PHONG_ID = new SelectList(db.PHONGs, "ID", "ma", vATTU.PHONG_ID);
            return View(vATTU);
        }

        // GET: VATTUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VATTU vATTU = db.VATTUs.Find(id);
            if (vATTU == null)
            {
                return HttpNotFound();
            }
            return View(vATTU);
        }

        // POST: VATTUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VATTU vATTU = db.VATTUs.Find(id);
            db.VATTUs.Remove(vATTU);
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
