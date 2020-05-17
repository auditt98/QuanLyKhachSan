using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLKS.Models;

namespace QLKS.Controllers
{
    public class NGUOIDUNGController : Controller
    {
        private QLKSContext db = new QLKSContext();

        // GET: NGUOIDUNG

        public ActionResult Login()
        {

            return View();
        }


        public ActionResult Index()
        {
            var nGUOIDUNGs = db.NGUOIDUNGs.Include(n => n.NHOMNGUOIDUNG);
            return View(nGUOIDUNGs.ToList());
        }

        // GET: NGUOIDUNG/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // GET: NGUOIDUNG/Create
        public ActionResult Create()
        {
            ViewBag.NHOMNGUOIDUNG_ID = new SelectList(db.NHOMNGUOIDUNGs, "ID", "ten");
            return View();
        }

        // POST: NGUOIDUNG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,tendangnhap,hash,tennguoidung,sodienthoai,ngaysinh,diachi,gioitinh,avatar,malaymatkhau,NHOMNGUOIDUNG_ID")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.NGUOIDUNGs.Add(nGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NHOMNGUOIDUNG_ID = new SelectList(db.NHOMNGUOIDUNGs, "ID", "ten", nGUOIDUNG.NHOMNGUOIDUNG_ID);
            return View(nGUOIDUNG);
        }

        // GET: NGUOIDUNG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            ViewBag.NHOMNGUOIDUNG_ID = new SelectList(db.NHOMNGUOIDUNGs, "ID", "ten", nGUOIDUNG.NHOMNGUOIDUNG_ID);
            return View(nGUOIDUNG);
        }

        // POST: NGUOIDUNG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,tendangnhap,hash,tennguoidung,sodienthoai,ngaysinh,diachi,gioitinh,avatar,malaymatkhau,NHOMNGUOIDUNG_ID")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NHOMNGUOIDUNG_ID = new SelectList(db.NHOMNGUOIDUNGs, "ID", "ten", nGUOIDUNG.NHOMNGUOIDUNG_ID);
            return View(nGUOIDUNG);
        }

        // GET: NGUOIDUNG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // POST: NGUOIDUNG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(nGUOIDUNG);
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
