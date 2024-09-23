using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
using OgrenciNotMVC.Models;
using System.Data;


namespace OgrenciNotMVC.Controllers
{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar

        dbOKULEntities db = new dbOKULEntities();

        public ActionResult Index()
        {

            var not = db.tblNOTLAR.ToList();
            return View(not);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(tblNOTLAR tbn)
        {
            db.tblNOTLAR.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var notlar = db.tblNOTLAR.Find(id);
            return View("NotGetir", notlar);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model, tblNOTLAR p, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var notlar = db.tblNOTLAR.Find(p.NotID);
                notlar.Sinav1 = p.Sinav1;
                notlar.Sinav2 = p.Sinav2;
                notlar.Sinav3 = p.Sinav3;
                notlar.Proje = p.Proje;
                notlar.Ortalama = p.Ortalama;

                db.SaveChanges();
                return RedirectToAction("Index", "Sinavlar");
            }
            return View();
        }
    }
}