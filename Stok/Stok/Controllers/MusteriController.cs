using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;

namespace Stok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MvcStokEntities2 db = new MvcStokEntities2();
        public ActionResult Index(string p)
        {
            /*var degerler = db.MUSTERILER.ToList();
            return View(degerler);*/

            var degerler= from d in db.MUSTERILER select d; //musterilerden sec d ye at, d den tek tek seçerek degerlere at
            if (!string.IsNullOrEmpty(p))
            {
                //p değeri boş değilse, arama alanı doluysa

                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));//aranan değeri getirir.

            }

            return View(degerler.ToList());

        }

       [HttpGet]
       public ActionResult YeniMusteri()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniMusteri(MUSTERILER p1)
        {

            if (!ModelState.IsValid) //Müşteri ekleme alanı boşsa kategori adını giriniz mesajı çıkar.
            {
                return View("YeniMusteri");
            }
            db.MUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.MUSTERILER.Find(id);
            db.MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.MUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(MUSTERILER p1)
        {
            var musteri = db.MUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}