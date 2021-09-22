using EduFileStock.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EduFileStock.Models.DataClassesDataContext;

namespace EduFileStock.Controllers
{
    public class SiteController : Controller
    {
        DataClassesDataContext db = new DataClassesDataContext();
        // GET: Site
        public ActionResult Index()
        {
            List<melumatli> melumat = new List<melumatli>();
            ViewBag.melumat = db.melumatli.OrderBy(x => x.MelumatAd).ToList();
            List<melumataltli> melumatalt = new List<melumataltli>();
            ViewBag.melumatalt = db.melumataltli.OrderBy(x => x.MelumatAltLiAd).ToList();
            return View();
        }
        public ActionResult contact()
        {
            List<melumatli> melumat = new List<melumatli>();
            ViewBag.melumat = db.melumatli.OrderBy(x => x.MelumatAd).ToList();
            List<melumataltli> melumatalt = new List<melumataltli>();
            ViewBag.melumatalt = db.melumataltli.OrderBy(x => x.MelumatAltLiAd).ToList();

            return View();
        }
        public ActionResult about()
        {
            List<melumatli> melumat = new List<melumatli>();
            ViewBag.melumat = db.melumatli.OrderBy(x => x.MelumatAd).ToList();
            List<melumataltli> melumatalt = new List<melumataltli>();
            ViewBag.melumatalt = db.melumataltli.OrderBy(x => x.MelumatAltLiAd).ToList();
            
            
            List<team> team = new List<team>();
            ViewBag.team = db.team.ToList();

            return View();
        }
        public ActionResult detail(int id)
        {
            List<melumatli> melumat = new List<melumatli>();
            ViewBag.melumat = db.melumatli.OrderBy(x => x.MelumatAd).ToList();
            List<melumataltli> melumatalt = new List<melumataltli>();
            ViewBag.melumatalt = db.melumataltli.OrderBy(x => x.MelumatAltLiAd).ToList();



            List<detail> detal = new List<detail>();
            ViewBag.detal = db.detail.Where(x => x.DetailLiId == id);
            var ad = db.melumataltli.SingleOrDefault(x => x.MelumatAltLiId == id);

            return View(ad);
        }
        public ActionResult detailmain(int id)
        {
            List<melumatli> melumat = new List<melumatli>();
            ViewBag.melumat = db.melumatli.OrderBy(x => x.MelumatAd).ToList();
            List<melumataltli> melumatalt = new List<melumataltli>();
            ViewBag.melumatalt = db.melumataltli.OrderBy(x => x.MelumatAltLiAd).ToList();


            List<detail> detal = new List<detail>();
            ViewBag.detal = db.detail.SingleOrDefault(x => x.DetailId == id);

            return View();
        }

        public ActionResult inscontact(contact newcontact)
        {
            db.contact.InsertOnSubmit(newcontact);
            db.SubmitChanges();
            return RedirectToAction("contact");
        }
    }
}