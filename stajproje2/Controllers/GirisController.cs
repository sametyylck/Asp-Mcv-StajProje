using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using stajproje2.Models;


namespace stajproje2.Controllers
{
    public class GirisController : Controller
    {
        Model1 db = new Model1();

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Kullanıcı k)
        {
            var bilgiler = db.Kullanıcı.FirstOrDefault(x => x.k_username == k.k_username && x.k_password == k.k_password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(k.k_username, false);
                Session["username"] = bilgiler.k_username;
                Session["userid"] = bilgiler.k_id.ToString();
                Session["k_isim"] = bilgiler.k_isim.ToString();
                Session["k_rol"] = bilgiler.k_Rol.ToString();
                Session["k_mail"] = bilgiler.k_mail.ToString();
                Session["k_password"] = bilgiler.k_password.ToString();

                return RedirectToAction("Satıs", "Adimn");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }

        }
       
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("name");
            Session.Clear();
            return RedirectToAction("Login", "Giris");
        }

        public ActionResult UserGüncelle()
        {
            var kullanıcılar = (string)Session["username"];
            var deger = db.Kullanıcı.FirstOrDefault(x => x.k_username == kullanıcılar);
            return View(deger);
        }

        [HttpPost]
        public ActionResult UserGüncelle(Kullanıcı k)
        {
            var kullanıcılar = (string)Session["username"];
            var user = db.Kullanıcı.Where(x => x.k_username == kullanıcılar).FirstOrDefault();
            user.k_tel = k.k_tel;
            user.k_isim = k.k_isim; 
            user.k_mail = k.k_mail;
            user.k_password = k.k_password;
            user.k_username = k.k_username;
            db.SaveChanges();
            
            return RedirectToAction("Ziyaret","Adimn");
        }

        public ActionResult SifreReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifreReset(string mail)
        {
            var email=db.Kullanıcı.Where(x=>x.k_mail==mail).FirstOrDefault();
            if(email!=null)
            {
                Random rnd = new Random();
                int yenisifre = rnd.Next();
                Kullanıcı sifre = new Kullanıcı();
                email.k_password = yenisifre.ToString();
                db.SaveChanges();

                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "gss48081@gmail.com";
                WebMail.Password = "xyrrslfttwxlthew";

                WebMail.Send(to:mail, subject: "Sifremi Unuttum", body:"Yeni Şifreniz:"+yenisifre.ToString() , cc: "gss48081@gmail.com", isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
                ViewBag.uyarı = "Şifreniz Gönderilmiştir.";
       
            }
            else
            {
                ViewBag.uyarı = "Hata oluştu";
            }

            return View();
        }


    }
}