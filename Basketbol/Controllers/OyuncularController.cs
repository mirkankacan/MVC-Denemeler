using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Basketbol.Models;

namespace Basketbol.Controllers
{
    public class OyuncularController : Controller
    {
        private BASKETBOLEntities db = new BASKETBOLEntities();

        // GET: Oyuncular
        public ActionResult Index()
        {
            
            return View();
        }

     
        public ActionResult Show()
        {
            return View(db.oyunculars.ToList());
        }
        // GET: Oyuncular/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oyuncular oyuncular = db.oyunculars.Find(id);
            if (oyuncular == null)
            {
                return HttpNotFound();
            }
            return View(oyuncular);
        }

        // GET: Oyuncular/Create
        public ActionResult Create()
        {
    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Adı,Numarası")] oyuncular oyuncular)
        {
            // İnternetten araştırarak buldum. Veritabanında girdiğimiz ismi arıyor 0 dan büyükse hata veriyor

            var ara = oyuncular.Adı;
            var sayi = (from x in db.oyunculars
                        where x.Adı == ara
                        select x).ToList();
            if (ModelState.IsValid)
            {
                if(sayi.Count>0)
                {
                    ViewBag.Message = "Bu isim '"+ara+"' ile daha önce kayıt yapılmış!";
                }
                else
                {
                    db.oyunculars.Add(oyuncular);
                    db.SaveChanges();
                    return RedirectToAction("Show");
                }
               
            }
            return View(oyuncular);
        }

        // GET: Oyuncular/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oyuncular oyuncular = db.oyunculars.Find(id);
            if (oyuncular == null)
            {
                return HttpNotFound();
            }
            return View(oyuncular);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Adı,Numarası")] oyuncular oyuncular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oyuncular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Show");
            }
            return View(oyuncular);
        }

        // GET: Oyuncular/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oyuncular oyuncular = db.oyunculars.Find(id);
            if (oyuncular == null)
            {
                return HttpNotFound();
            }
            return View(oyuncular);
        }

        // POST: Oyuncular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            oyuncular oyuncular = db.oyunculars.Find(id);
            db.oyunculars.Remove(oyuncular);
            db.SaveChanges();
            return RedirectToAction("Show");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
