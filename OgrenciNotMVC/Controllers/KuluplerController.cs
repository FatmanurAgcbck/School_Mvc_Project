using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class KuluplerController : Controller
    {

        // GET: Kulupler

        dbOKULEntities db = new dbOKULEntities();
        public ActionResult Index()
        {
            var kulupler = db.tblKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(tblKULUPLER p)
        {
            db.tblKULUPLER.Add(p);
            db.SaveChanges();
            return View();

        }

        public ActionResult Sil(int id)
        {
            var kulup = db.tblKULUPLER.Find(id);
            db.tblKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.tblKULUPLER.Find(id);
            
                
            return View("KulupGetir", kulup);
        }

        public ActionResult Guncelle(tblKULUPLER p)
        {
            var klp = db.tblKULUPLER.Find(p.KulupID);
            klp.KulupAd = p.KulupAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}