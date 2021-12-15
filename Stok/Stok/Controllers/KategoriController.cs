using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;
using PagedList.Mvc;
using PagedList;

namespace Stok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcStokEntities2 db = new MvcStokEntities2(); //MvcStokEntities1 sınıfından nesne türetiyoruz.Tablolara ulaşmak için.
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.KATEGORILER.ToList(); //Kategorilerdeki değerleri select vs kullanmadan listelemiş olduk.

            var degerler = db.KATEGORILER.ToList().ToPagedList(sayfa,2); //KAçıncı sayfadan başlasın, her sayfada kaç tane öğe olsun
            return View(degerler);
        }
        [HttpGet] //Ekleme işlemi yapmadan açsın.
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost] //Butona tıkladığında ekleme işlemi gerçekleşsin
         public ActionResult YeniKategori(KATEGORILER p1)
        {
            if (!ModelState.IsValid) //Kategori ekleme alanı boşsa kategori adını giriniz mesajı çıkar.
            {
                return View("YeniKategori");
            }
            db.KATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.KATEGORILER.Find(id); //kategoriler içinden id yi bul.
            db.KATEGORILER.Remove(kategori); //sil
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.KATEGORILER.Find(id);
            return View("KategoriGetir", ktgr); //geriye kategorigetiri döndürür.
        }

        public ActionResult Guncelle(KATEGORILER p1)
        {
            var ktg = db.KATEGORILER.Find(p1.KATEGORIID); //güncellenmek istenen değeri al kategoiler içinden bul. P1 bizim güncellemek istediğimiz değerin IDsi.
            ktg.KATEGORIAD = p1.KATEGORIAD; //ktg yeni hali
            db.SaveChanges();
            return RedirectToAction("Index");

        
        }


    }
}