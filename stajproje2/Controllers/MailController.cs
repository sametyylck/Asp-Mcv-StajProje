using stajproje2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace stajproje2.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Mail model)
        {
         
            return View();


          
        }

      
    }
}