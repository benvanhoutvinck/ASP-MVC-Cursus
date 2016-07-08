using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string resultaat = "Dit is jouw eerste bezoek";

            //zijn er cookies?
            if (Request.Cookies != null)
            {
                //is er een cookies met de naam "user"?
                if (Request.Cookies["lastvisit"] != null)
                {
                    //dan lezen we het tijdstip van het laatste bezoek uit de cookie
                    resultaat = "Welkom terug. Jouw laatste bezoek was op " +
                     Request.Cookies["lastvisit"]["tijdstip"] +
                     ". Jouw voorkeurtaal is " +
                     Request.Cookies["lastvisit"]["taal"] + ".";
                }

                //we slaan het huidige tijdstip op als laatste bezoek
                string laatsteBezoek = DateTime.Now.ToString();
                var userCookie = new HttpCookie("lastvisit");
                userCookie["tijdstip"] = laatsteBezoek;
                userCookie["taal"] = Request.UserLanguages[0];
                userCookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(userCookie);
            }
            ViewBag.Tijdstip = resultaat;

            //sessionvariabele aanpassen
            this.Session["aantalBezoeken"] = (int)this.Session["aantalBezoeken"] + 1;

            //applicationvariabele aanpassen
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] =
            (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();
        }

        public ActionResult Wissen()
        {
            //zijn er cookies?
            if (Request.Cookies != null)
            {
                //is er een cookies met de naam "user"?
                if (Request.Cookies["lastvisit"] != null)
                {
                    Request.Cookies["lastvisit"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(Request.Cookies["lastvisit"]);
                }
            }
            return View();
        }

        public ActionResult SessionWissen()
        {
            //reset sessionvariabele
            this.Session["aantalBezoeken"] = 0;
            //reset applicationvariabele
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = 0;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}