using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMVC.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(decimal sayi1=0, decimal sayi2=0)
        {
            decimal sonuc = sayi1 + sayi2;
            ViewBag.snc = sonuc;
            return View();

        }

        

        
    }
}