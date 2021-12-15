using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;

namespace Stok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcStokEntities2 db = new MvcStokEntities2();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SATISLAR p) 
        {
            db.SATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}