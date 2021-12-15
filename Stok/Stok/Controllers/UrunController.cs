using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;


namespace Stok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        MvcStokEntities2 db = new MvcStokEntities2(); //MvcStokEntities1 sınıfından nesne türetiyoruz.Tablolara ulaşmak için.
        public ActionResult Index()
        {
            var degerler = db.URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            //LINQ SORGUSU
            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList() //Kategorilerin listesini çek bunu da i adlı değişkene ata

                                             select new SelectListItem //yeni listeyi seç
                                             {
                                                 Text = i.KATEGORIAD, //yeni listenin text değerini i den gelen KategoriAd dan al. (Görünen eeğer)
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler; //diğer sayfaya degerleri taşıyoruz.Sorgudan gelen değerleri tutar
            return View();
        }

        [HttpPost]

        public ActionResult YeniUrun(URUNLER p1)
        {
            //FirstOrDefault: Seçtiğimiz değeri getirir.
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == p1.KATEGORILER.KATEGORIID).FirstOrDefault();
            p1.KATEGORILER = ktg;
            db.URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       public ActionResult Sil(int id)
        {
            var urun = db.URUNLER.Find(id); //id değeri sil butonuna tıklanan değerin idsini alır
            db.URUNLER.Remove(urun);
            db.SaveChanges();

            return RedirectToAction("Index");
      
        }

       public ActionResult UrunGetir(int id)
        {

            var urun = db.URUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList() //Kategorilerin listesini çek bunu da i adlı değişkene ata

                                             select new SelectListItem //yeni listeyi seç
                                             {
                                                 Text = i.KATEGORIAD, //yeni listenin text değerini i den gelen KategoriAd dan al. (Görünen eeğer)
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler; //diğer sayfaya degerleri taşıyoruz.Sorgudan gelen değerleri tutar

            return View("UrunGetir", urun);
        }

        
        public ActionResult Guncelle(URUNLER p)
        {
            var urun = db.URUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.URUNFIYAT = p.URUNFIYAT;
            //urun.URUNKATEGORI = p.URUNKATEGORI;
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == p.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;

            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}