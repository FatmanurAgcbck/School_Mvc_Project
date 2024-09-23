using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        dbOKULEntities db = new dbOKULEntities();
        public ActionResult Index()
        {
            var ogrenci = db.tblOGRENCILER.ToList();
            return View(ogrenci);
        }


        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.tblKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(tblOGRENCILER p)
        {
            var klp = db.tblKULUPLER.Where(m => m.KulupID == p.tblKULUPLER.KulupID).FirstOrDefault();
            p.tblKULUPLER = klp;
            db.tblOGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.tblOGRENCILER.Find(id);
            db.tblOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.tblOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.tblKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupID.ToString()
                                             }
                                             ).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir", ogrenci);
        }

        public ActionResult Guncelle(tblOGRENCILER p)
        {
            var ogr = db.tblOGRENCILER.Find(p.OgrenciID);
            ogr.OgrAd = p.OgrAd;
            ogr.OgrSoyad = p.OgrSoyad;
            ogr.OgrFotograf = p.OgrFotograf;
            ogr.OgrCinsiyet = p.OgrCinsiyet;
            ogr.OgrKulup = p.OgrKulup;
            db.SaveChanges();


            return RedirectToAction("Index", "Ogrenciler");       
        }
        
    }
}