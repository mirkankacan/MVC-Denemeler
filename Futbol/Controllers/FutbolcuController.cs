using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Futbol.Models;

namespace Futbol.Controllers
{
    
    public class FutbolcuController : Controller
    {
        db database = new db();
        // GET: Islem
        public ActionResult Index()
        {
            var degerler = database.Futbolcus.ToList();
            return View(degerler);
        }
        public ActionResult FutbolcuEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FutbolcuEkle(Futbolcu f)
        {

            database.Futbolcus.Add(f);
            database.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FutbolcuSil(int id)
        {
            var sil = database.Futbolcus.Find(id);
            database.Futbolcus.Remove(sil);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FutbolcuGetir(int id)
        {
            var bul = database.Futbolcus.Find(id);
            return View("FutbolcuGetir", bul);
        }
        [HttpPost]
        public ActionResult FutbolcuGuncelle(Futbolcu f)
        {
       
            var guncel = database.Futbolcus.Find(f.ID);
            guncel.FutbolcuAdı = f.FutbolcuAdı;
            guncel.FutbolcuNumarası = f.FutbolcuNumarası;
            database.SaveChanges();
            return RedirectToAction("Index");
          
        }
    }
}