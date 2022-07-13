using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using stajproje2.Models;

namespace stajproje2.Controllers
{
    public class UserController : Controller
    { // GET: User
        Model1 db = new Model1();

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Satis()
        {

            var personel = new SelectList(db.Kullanıcı.Where(x => x.k_Rol == "user").ToList(), "k_id", "k_isim");
            ViewBag.user_id = personel;

            List<SelectListItem> deger1 = (from i in db.Doviz.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.dovizname,
                                               Value = i.doviz_id.ToString()
                                           }).ToList();

            ViewBag.satıs = deger1;





            var musteri = new SelectList(db.Musteri.ToList(), "m_id", "m_ad");
            ViewBag.m_fk_id = musteri;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Satis(Satıs sat)
        {
            var personel = new SelectList(db.Kullanıcı.Where(x => x.k_Rol == "user").ToList(), "k_id", "k_isim");
            ViewBag.user_id = personel;


            List<SelectListItem> deger1 = (from i in db.Doviz.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.dovizname,
                                               Value = i.doviz_id.ToString()
                                           }).ToList();
            ViewBag.satıs = deger1;

            var musteri = new SelectList(db.Musteri.ToList(), "m_id", "m_ad");
            ViewBag.m_fk_id = musteri;


            var toplam = sat.sat_adet * sat.sat_fiyat;
            sat.toplam_fiyat = toplam;
            if (ModelState.IsValid)
            {
                var dovizkuru = db.Doviz.Where(x => x.doviz_id == sat.doviz_id).First();
                double kurDegeri = KurGetir.Deger(dovizkuru.dovizname);
                sat.doviz_fiyat = kurDegeri;
                db.Satıs.Add(sat);
                db.SaveChanges();
                return RedirectToAction("Satıs", "Adimn");

            }
            return View(sat);


        }


  


    

        public ActionResult Guncelle(int id)
        {
            var sube = new SelectList(db.Subeler.ToList(), "sube_id", "sube_ad");
            ViewBag.sube_fk_id = sube;
            ViewBag.z_id = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guncelle(Ziyaretler zet)
        {
            
            var ziya = db.Ziyaretler.Find(zet.z_id);
            var sube = new SelectList(db.Subeler.ToList(), "sube_id", "sube_ad");
            ViewBag.sube_fk_id = sube;
            var ziyare = db.Subeler.Where(x => x.sube_id == zet.sube_fk_id).SingleOrDefault();
            var zz = db.Ziyaretler.Where(c => c.z_id == zet.z_id).SingleOrDefault();
            zet.z_islem_tarihi = DateTime.Now;  
            if (Request.Files.Count > 0)
            {

                string dosyadı = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyadı + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                ziya.z_resimm = "/Image/" + dosyadı + uzanti;

                WebImage webImage = new WebImage(Request.Files[0].InputStream);
                decimal width = webImage.Width;
                decimal height = webImage.Height;
                decimal rate = width / height;
                if (rate < 1.70m || rate > 1.85m)
                {
                    var newHeight = width * (0.5625m);
                    webImage.Resize((int)width, (int)newHeight, false, false);
                }
                webImage.Save(yol);
                



            }
                ziya.z_olay_id = zet.z_olay_id;
                ziya.sube_fk_id = zet.sube_fk_id;
                ziya.z_not = zet.z_not;
               
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
                WebMail.UserName = Convert.ToString(Session["k_mail"]);
                WebMail.Password = "nwilbhifaheprvyt";

                WebMail.Send(to:"gss48081@gmail.com" , subject: "Ziyaret Güncelleme", body: "Sayın yönetici "+zz.z_olusturma + " "+" tarihinde oluşturulan"+" " +zz.z_tarih +" "+" tarihli"+" " + ziyare.sube_ad + " " + "şubesine " + " " +" oluşturulan ziyaret ataması saha personeli tarafından güncellendi.", cc: "gss48081@gmail.com", isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
                zz.z_olay_id = 6;
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