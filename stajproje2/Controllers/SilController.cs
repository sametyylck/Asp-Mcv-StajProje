using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stajproje2.Models;

namespace stajproje2.Controllers
{
    public class SilController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Silperso(int id)
        {
            var personel = db.Kullanıcı.Find(id);
            db.Kullanıcı.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index", "Adimn");
            //return RedirectToAction("~/Adimn/Index");
        }

        public ActionResult Silziya(int id)
        {
            var ziyaret = db.Ziyaretler.Find(id);
            db.Ziyaretler.Remove(ziyaret);
            db.SaveChanges();
            return RedirectToAction("Ziyaret", "Adimn");
        }

        public ActionResult Silmust(int id)
        {
            var must = db.Musteri.Find(id);
            db.Musteri.Remove(must);
            db.SaveChanges();
            return RedirectToAction("Musteri", "Adimn");
        }

        public ActionResult Silsube(int id)
        {
            var sube = db.Subeler.Find(id);
            db.Subeler.Remove(sube);
            db.SaveChanges();
            return RedirectToAction("Sube", "Adimn");
        }
    }
}