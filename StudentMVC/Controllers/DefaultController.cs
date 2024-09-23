using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        dbOKULEntities db = new dbOKULEntities();
        public ActionResult Index()
        {
            var dersler = db.tblDERSLER.ToList();

            return View(dersler);
        }


        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(tblDERSLER p)
        {
            db.tblDERSLER.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var ders = db.tblDERSLER.Find(id);
            db.tblDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult DersGetir(int id)
        {
            var ders = db.tblDERSLER.Find(id);

            return View("DersGetir", ders);
        }

        public ActionResult Guncelle(tblDERSLER p)
        {
            var drs = db.tblDERSLER.Find(p.DersID);
            drs.DersAd = p.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");

        }

    }
}