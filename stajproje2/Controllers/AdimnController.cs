using stajproje2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace stajproje2.Controllers
{
    public class AdimnController : Controller
    {
        Model1 db = new Model1();
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string ara)
        {
            
            // var personel = db.Personel.ToList();
            var personel = db.Kullanıcı.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                personel = personel.Where(x => x.k_id.ToString().ToLower().Contains(ara.ToLower()) || x.k_tel.ToLower().Contains(ara.ToLower()) || x.k_mail.ToLower().Contains(ara) || x.k_isim.ToLower().Contains(ara) || x.k_baslangıc.ToString().ToLower().Contains(ara)).ToList();
            }
            return View(personel);

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Musteri(string ara)
        {

            var musterii = db.Musteri.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                 musterii = musterii.Where(x => x.m_tel.ToLower().Contains(ara.ToLower()) || x.m_ad.ToLower().Contains(ara.ToLower()) || x.m_mail.ToLower().Contains(ara.ToLower()) || x.m_sirket.ToLower().Contains(ara.ToLower())).ToList();
            }
            
            return View(musterii);

        }

       
        public ActionResult Ziyaret(string ara)
        {
            var ziyaret = db.Ziyaretler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                ziyaret = ziyaret.Where(y => y.z_id.ToString().ToLower().Contains(ara) || y.z_ismi.ToLower().Contains(ara.ToLower())||
                y.z_tarih.ToString().ToLower().Contains(ara.ToLower()) ||y.z_olay_id.ToString().Contains(ara.ToLower()) || y.Olay.olay_durum.ToLower().Contains(ara.ToLower()) ||
                y.sube_fk_id.ToString().Contains(ara.ToLower()) || y.Subeler.sube_ad.ToLower().Contains(ara.ToLower()) || y.z_user_id.ToString().Contains(ara.ToLower()) || y.Kullanıcı.k_isim.ToLower().Contains(ara.ToLower())).ToList();
                  
            }
            return View(ziyaret);

        }
        public ActionResult ZiyaretOnaylanan(string ara)
        {
            var ziyaret = db.Ziyaretler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                ziyaret = ziyaret.Where(y => y.z_id.ToString().ToLower().Contains(ara) || y.z_ismi.ToLower().Contains(ara.ToLower()) ||
              y.z_tarih.ToString().ToLower().Contains(ara.ToLower()) || y.z_olay_id.ToString().Contains(ara.ToLower()) || y.Olay.olay_durum.ToLower().Contains(ara.ToLower()) ||
              y.sube_fk_id.ToString().Contains(ara.ToLower()) || y.Subeler.sube_ad.ToLower().Contains(ara.ToLower())).ToList();
            }
            return View(ziyaret);
          
        }
        public ActionResult ZiyaretEdilecek(string ara)
        {
            var ziyaret = db.Ziyaretler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                ziyaret = ziyaret.Where(y => y.z_id.ToString().ToLower().Contains(ara) || y.z_ismi.ToLower().Contains(ara.ToLower()) ||
                              y.z_tarih.ToString().ToLower().Contains(ara.ToLower()) || y.z_olay_id.ToString().Contains(ara.ToLower()) || y.Olay.olay_durum.ToLower().Contains(ara.ToLower()) ||
                              y.sube_fk_id.ToString().Contains(ara.ToLower()) || y.Subeler.sube_ad.ToLower().Contains(ara.ToLower())).ToList();
            }
            return View(ziyaret);
            
        }
        public ActionResult ZiyaretRed(string ara)
        {
            var ziyaret = db.Ziyaretler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                ziyaret = ziyaret.Where(y => y.z_id.ToString().ToLower().Contains(ara) || y.z_ismi.ToLower().Contains(ara.ToLower()) ||
              y.z_tarih.ToString().ToLower().Contains(ara.ToLower()) || y.z_olay_id.ToString().Contains(ara.ToLower()) || y.Olay.olay_durum.ToLower().Contains(ara.ToLower()) ||
              y.sube_fk_id.ToString().Contains(ara.ToLower()) || y.Subeler.sube_ad.ToLower().Contains(ara.ToLower())).ToList();
            }
            return View(ziyaret);
        }
        public ActionResult ZiyaretOnayBekle(string ara)
        {
            var ziyaret = db.Ziyaretler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                ziyaret = ziyaret.Where(y => y.z_id.ToString().ToLower().Contains(ara) || y.z_ismi.ToLower().Contains(ara.ToLower()) ||
              y.z_tarih.ToString().ToLower().Contains(ara.ToLower()) || y.z_olay_id.ToString().Contains(ara.ToLower()) || y.Olay.olay_durum.ToLower().Contains(ara.ToLower()) ||
              y.sube_fk_id.ToString().Contains(ara.ToLower()) || y.Subeler.sube_ad.ToLower().Contains(ara.ToLower())).ToList();
            }
            return View(ziyaret);
        }
        public ActionResult ZiyaretGuncellenecek(string ara)
        {
            var ziyaret = db.Ziyaretler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                ziyaret = ziyaret.Where(y => y.z_id.ToString().ToLower().Contains(ara) || y.z_ismi.ToLower().Contains(ara.ToLower()) ||
              y.z_tarih.ToString().ToLower().Contains(ara.ToLower()) || y.z_olay_id.ToString().Contains(ara.ToLower()) || y.Olay.olay_durum.ToLower().Contains(ara.ToLower()) ||
              y.sube_fk_id.ToString().Contains(ara.ToLower()) || y.Subeler.sube_ad.ToLower().Contains(ara.ToLower())).ToList();
            }
            return View(ziyaret);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Sube(string ara)
        {
            var sube = db.Subeler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                sube = sube.Where(x => x.sube_il.ToLower().Contains(ara.ToLower()) || x.sube_ad.ToLower().Contains(ara.ToLower()) || x.sube_tel.ToLower().Contains(ara.ToLower()) || x.sube_adres.ToLower().Contains(ara.ToLower())).ToList();
            }
            return View(sube);


        }
        [Authorize(Roles = "Admin,User")]
        public ActionResult Satıs(string ara)
        {
            var sat = db.Satıs.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                sat = sat.Where(x => x.sat_adet.ToString().Contains(ara.ToLower()) ||x.sat_id.ToString().ToLower().Contains(ara)  || x.sat_fiyat.ToString().ToLower().Contains(ara.ToLower()) || x.sat_urun.ToLower().Contains(ara.ToLower()) ||x.m_fk_id.ToString().Contains(ara.ToLower()) || x.Musteri.m_ad.ToLower().Contains(ara.ToLower()) || x.toplam_fiyat.ToString().ToLower().Contains(ara) ||x.doviz_fiyat.ToString().ToLower().Contains(ara)  || x.Kullanıcı.k_isim.ToLower().Contains(ara.ToLower())).ToList();
            }
            return View(sat);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult PersonelEkle(Kullanıcı per)
        {
            var b = db.Kullanıcı.Where(x => x.k_mail == per.k_mail);
            var a = b.Count();
            var c = db.Kullanıcı.Where(x => x.k_username == per.k_username);
            var d = c.Count();
            if(a>0 && d>0)
            {
                ViewBag.uyar = "Bu eposta ve kullanıcı adı sistemde kayıtlı.";
                return View(per);
            }
            
            
            if (a > 0)
            {
                ViewBag.uyarıı = "Bu eposta sistemde kayıtlı";
                return View(per);
            }
            if (d > 0)
            {
                ViewBag.uyarı = "Bu kullanıcı adı sistemde kayıtlı";
            }
            else
            {
                if (ModelState.IsValid)
                {

                    per.k_tel = Guid.NewGuid().ToString();
                    per.k_Rol = "user";
                    db.Kullanıcı.Add(per);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Adimn");
                }
            
            }
            return View();
            
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult SubeEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult SubeEkle(Subeler su)
        {
            su.s_islem_tarihi = DateTime.Now;
            if (ModelState.IsValid)
            {
                
                db.Subeler.Add(su);
                db.SaveChanges();
                return RedirectToAction("Sube", "Adimn");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult MusteriEkle(Musteri mus)
        {
            if(ModelState.IsValid)
            {
                db.Musteri.Add(mus);
                db.SaveChanges();
                return RedirectToAction("Musteri","Adimn");
            }
            return View();
            
        }
        [Authorize(Roles = "Admin,user")]
        
        public ActionResult Filtre()
        {
            List<SelectListItem> deger1 = (from i in db.Kullanıcı.Where(x => x.k_Rol == "user").ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.k_isim,
                                               Value = i.k_id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            List<SelectListItem> sube = (from i in db.Subeler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.sube_ad,
                                             Value = i.sube_id.ToString(),


                                         }).ToList();
            ViewBag.sube = sube;

            List<SelectListItem> olay = (from i in db.Olay.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.olay_durum,
                                             Value = i.olay_id.ToString(),


                                         }).ToList();
            ViewBag.olay = olay;
            return View();
        }

        [HttpPost]
        public ActionResult FiltreList(Ziyaretler zet,DateTime? z_olusturma, DateTime? z_tarih,int? sube_fk_id,int? z_user_id,int? z_olay_id)
        {
            List<SelectListItem> deger1 = (from i in db.Kullanıcı.Where(x => x.k_Rol == "user").ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.k_isim,
                                               Value = i.k_id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            List<SelectListItem> sube = (from i in db.Subeler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.sube_ad,
                                             Value = i.sube_id.ToString(),


                                         }).ToList();
            ViewBag.sube = sube;

            List<SelectListItem> olay = (from i in db.Olay.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.olay_durum,
                                             Value = i.olay_id.ToString(),


                                         }).ToList();
            ViewBag.olay = olay;

            SqlConnection baglanti = new SqlConnection(@"Data Source = .; Initial Catalog = stajproje; Trusted_Connection=True");
            string sql = $"Select * from Ziyaretler where ";
            string a = "";
            string b = "";
            if (z_olusturma != null)
            {
                a = zet.z_olusturma?.ToString("yyyy-MM-dd");
            }
            if (z_tarih != null)
            {
                b = zet.z_tarih?.ToString("yyyy-MM-dd");
            }


            int filt = 0;

            if (z_user_id != null)
            {
                filt = 1;
                sql += $" z_user_id={z_user_id}";
            }

            if (sube_fk_id != null)
            {
                if (filt == 0)
                {
                    sql += $" sube_fk_id={sube_fk_id}";
                    filt = 1;
                }
                else
                {
                    sql += $" and sube_fk_id={sube_fk_id}";
                }
            }

            if (z_olay_id != null)
            {
                if (filt == 0)
                {
                    sql += $"z_olay_id={z_olay_id}";
                    filt = 1;
                }
                else
                {
                    sql += $" and z_olay_id={z_olay_id}";
                }
            }

            if (z_olusturma != null)
            {
                if (filt == 0)
                {
                    sql += $"z_olusturma>='{a}'";
                    filt = 1;
                }
                else
                {
                    sql += $" and z_olusturma>='{a}'";
                }
            }

            if (z_tarih != null)
            {
                if (filt == 0)
                {
                    sql += $"z_tarih<='{b}'";
                    filt = 1;
                }
                else
                {
                    sql += $" and z_tarih<='{b}'";
                }
            }
            if (z_user_id == null && sube_fk_id == null && z_olay_id == null && z_olusturma == null && z_tarih == null)
            {
                sql = $"Select * from Ziyaretler";
            }
            var ls = db.Ziyaretler.SqlQuery(sql).ToList();
            return View(ls);

        }






    }
}