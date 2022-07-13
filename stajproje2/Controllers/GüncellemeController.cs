using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using stajproje2.Models;

namespace stajproje2.Controllers
{
    public class GüncellemeController : Controller
    {
        Model1 db = new Model1();

       
        public ActionResult Güncelleperso(int id)
        {
            var perso = db.Kullanıcı.Find(id);
            
            return View(perso);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Güncelleperso(Kullanıcı k)
        {
            var b=db.Kullanıcı.Where(x=>x.k_mail==k.k_mail);
            var a = b.Count();
            if (a>0)
            {
                ViewBag.uyarı = "Bu eposta sistemde kayıtlı";
                return View(k);
            }
            else
            {
                var perso = db.Kullanıcı.Find(k.k_id);
                if (ModelState.IsValid)
                {
                    perso.k_islem_tarihi = DateTime.Now;
                    perso.k_isim = k.k_isim;
                    perso.k_tel = k.k_tel;
                    perso.k_mail = k.k_mail;
                    perso.k_baslangıc = k.k_baslangıc;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Adimn");
                }
               
            }
            return View(k);  
            
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Güncellemust(int id)
        {
            var update = db.Musteri.Find(id);
            ViewBag.mst = id;
            return View(update);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Güncellemust(Musteri data)
        {
            var must = db.Musteri.Find(data.m_id);
            if (ModelState.IsValid)
            {
                must.m_ad = data.m_ad;
                must.m_tel = data.m_tel;
                must.m_mail = data.m_mail;
                must.m_sirket = data.m_sirket;
                db.SaveChanges();
                return RedirectToAction("Musteri", "Adimn");
            }
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Güncellesube(int id)
        {
            var sube = db.Subeler.Find(id);
            return View(sube);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Güncellesube(Subeler sub)
        {
            var sun = db.Subeler.Find(sub.sube_id);

            if (ModelState.IsValid)
            {
                sun.sube_ad = sub.sube_ad;
                sun.sube_il = sub.sube_il;
                sun.sube_tel = sub.sube_tel;
                sun.sube_adres = sub.sube_adres;
                db.SaveChanges();
                return RedirectToAction("Sube", "Adimn");
            }

            return View(sub);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Detay(int id)
        {
            var personel = new SelectList(db.Kullanıcı.ToList(), "k_id", "k_isim");
            ViewBag.user_id = personel;

            var musteri = new SelectList(db.Musteri.ToList(), "m_id", "m_ad");
            ViewBag.m_fk_id = musteri;

            var detay = db.Satıs.Find(id);
            return View(detay);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Detay(Satıs satıs)
        {
            var personel = new SelectList(db.Kullanıcı.ToList(), "k_id", "k_isim");
            ViewBag.user_id = personel;


            var musteri = new SelectList(db.Musteri.ToList(), "m_id", "m_ad");
            ViewBag.m_fk_id = musteri;

            var detay = db.Satıs.Find(satıs.sat_id);
            return View(satıs);
        }





        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult Detaygetir(int id)
        {
            var personel = new SelectList(db.Kullanıcı.ToList(), "k_id", "k_isim");
            ViewBag.user_id = personel;

            var musteri = new SelectList(db.Musteri.ToList(), "m_id", "m_ad");
            ViewBag.m_fk_id = musteri;

            var detay = db.Satıs.Find(id);
            return View(detay);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public ActionResult Detaygetir(Satıs satıs)
        {
            var personel = new SelectList(db.Kullanıcı.ToList(), "k_id", "k_isim");
            ViewBag.user_id = personel;


            var musteri = new SelectList(db.Musteri.ToList(), "m_id", "m_ad");
            ViewBag.m_fk_id = musteri;

            var detay = db.Satıs.Find(satıs.sat_id);
            if (ModelState.IsValid)
            {
                detay.sat_adet = satıs.sat_adet;
                detay.sat_urun = satıs.sat_urun;
                detay.sat_fiyat = satıs.sat_fiyat;
                db.SaveChanges();
                return RedirectToAction("Satıs", "Adimn");
            }
            return View(satıs);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Ziyraetata()
        {
            var personel = new SelectList(db.Kullanıcı.Where(x => x.k_Rol == "user").ToList(), "k_id", "k_isim");
            ViewBag.z_user_id = personel;

            var sube = new SelectList(db.Subeler.ToList(), "sube_id", "sube_ad");
            ViewBag.sube_fk_id = sube;
            
           
            


            return View();

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Ziyraetata(Ziyaretler zet, Mail model)
        {
            var personel = new SelectList(db.Kullanıcı.Where(x=> x.k_Rol == "user").ToList(), "k_id", "k_isim");
            ViewBag.z_user_id = personel;

          

            var sube = new SelectList(db.Subeler.ToList(), "sube_id", "sube_ad");
            
            ViewBag.sube_fk_id = sube;
            zet.z_islem_tarihi = DateTime.Now;
            
             zet.z_olusturma = DateTime.Now;
             zet.z_olay_id = 5;
             db.Ziyaretler.Add(zet);
             db.SaveChanges();
               
            
            var perso = db.Kullanıcı.Where(k => k.k_id == zet.z_user_id).SingleOrDefault();
            var ziyare = db.Subeler.Where(x => x.sube_id == zet.sube_fk_id).SingleOrDefault();
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "gss48081@gmail.com";
                WebMail.Password = "xyrrslfttwxlthew";
                Mail mai = new Mail();
              
                //Send email  
                WebMail.Send(to:perso.k_mail, subject: "Ziyaret Atandı", body:"Sayın "+perso.k_isim+ " "+" yöneticiniz"+" "+ziyare.sube_ad +" "+"şubesine " + zet.z_tarih + " "+ "tarihli ziyaret atadı.", cc: "gss48081@gmail.com", isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }

            return RedirectToAction("Ziyaret", "Adimn",zet);
        }

        public ActionResult ZiyaretIslemleri(int id)

        {
            var ziya = db.Ziyaretler.Find(id);
            // var personel = new SelectList(db.Kullanıcı.Where(x => x.k_Rol == "user").ToList(), "k_id", "k_isim");
            //ViewBag.z_user_id = personel;
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


            //var sube = new SelectList(db.Subeler.ToList(), "sube_id", "sube_ad");
            //ViewBag.sube_fk_id = sube;

            List<SelectListItem> ol = (from i in db.Olay.ToList()
                                       select new SelectListItem
                                       {
                                           Text = i.olay_islem,
                                           Value = i.olay_id.ToString()
                                       }).ToList();
            ViewBag.olay = ol;

            return View(ziya);
        }

        [HttpPost]
        public ActionResult ZiyaretIslemleri(Ziyaretler zet)
        {
            var ziya = db.Ziyaretler.Find(zet.z_id);
            List<SelectListItem> deger1 = (from i in db.Kullanıcı.Where(x => x.k_Rol == "user").ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.k_isim,
                                               Value = i.k_id.ToString()
                                           }).ToList();

            List<SelectListItem> sube = (from i in db.Subeler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.sube_ad,
                                             Value = i.sube_id.ToString()
                                         }).ToList();
            ViewBag.sube = sube;

            List<SelectListItem> ol = (from i in db.Olay.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.olay_islem,
                                             Value = i.olay_id.ToString()
                                         }).ToList();
            ViewBag.olay = ol;


            ziya.z_olay_id = zet.z_olay_id; 
            
            zet.z_islem_tarihi = DateTime.Now;

       

            var perso = db.Kullanıcı.Where(k => k.k_id == zet.z_user_id).SingleOrDefault();
            var ziyare = db.Subeler.Where(x => x.sube_id == zet.sube_fk_id).SingleOrDefault();
            var olayid = db.Olay.Where(y => y.olay_id == zet.z_olay_id).SingleOrDefault();
            var zz=db.Ziyaretler.Where(c=>c.z_id==zet.z_id).SingleOrDefault();
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "gss48081@gmail.com";
                WebMail.Password = "xyrrslfttwxlthew";
                Mail mai = new Mail();

            if(olayid.olay_id==1)
                {
                    WebMail.Send(to: perso.k_mail, subject: "Ziyaret Güncelleme", body: "Sayın " + perso.k_isim + " " + " yöneticiniz" + " " + ziyare.sube_ad + " " + "şubesine " +" "+zz.z_olusturma+" "+"tarihinde oluşturulan"+" " +zet.z_tarih + " " + "tarihli ziyaret görevini güncelledi.", cc: "gss48081@gmail.com", isBodyHtml: true);
                    ViewBag.Status = "Email Sent Successfully.";
                    ziya.z_tarih = zet.z_tarihgüncel;
                }
            else if(olayid.olay_id==2)
                {
                    WebMail.Send(to: perso.k_mail, subject: "Ziyaret Onaylama", body: "Sayın " + perso.k_isim + " " + " yöneticiniz" + " "+ zet.z_tarih+" "+" tarihli" +" "+ ziyare.sube_ad + " " + "şubesine "+" " +"yaptığınız ziyareti onayladı.", cc: "gss48081@gmail.com", isBodyHtml: true);
                    ViewBag.Status = "Email Sent Successfully.";
                }
            else if(olayid.olay_id==3)
                {
                    WebMail.Send(to: perso.k_mail, subject: "Ziyaret Red", body: "Sayın " + perso.k_isim + " " + " yöneticiniz" + " " + ziyare.sube_ad + " " + "isimli subeye "+" " + zet.z_tarih + " " + "tarihinde yaptığınız ziyareti rreddedildi.Yeniden ziyaret yapınız.", cc: "gss48081@gmail.com", isBodyHtml: true);
                    ViewBag.Status = "Email Sent Successfully.";
                    ziya.z_tarih = zet.z_tarihgüncel;
                }
                else
                {
                    return View();
                }
                //Send email  
                
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }

            db.SaveChanges();
            return RedirectToAction("Ziyaret", "Adimn");
        
           
            
        }


    }
}