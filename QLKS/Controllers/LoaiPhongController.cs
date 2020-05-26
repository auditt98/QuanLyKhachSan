using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class LoaiPhongController : Controller
    {
        // GET: LoaiPhong/List
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoaiPhongModel model)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(LoaiPhongModel model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}