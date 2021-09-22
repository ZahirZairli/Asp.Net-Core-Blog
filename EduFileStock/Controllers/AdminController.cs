using EduFileStock.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EduFileStock.Controllers
{
    public class AdminController : Controller
    {
        DataClassesDataContext db = new DataClassesDataContext(); 
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }





        //_____________SignIn________________
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult SignIn(string IstifadeciMail, string IstifadeciParol)
        {
            var c = CreateMD5("levengi" + IstifadeciParol + "levengi");
            DataTable dt = Sql.Exec($"select * from Istifadeci where IstifadeciMail=N'{IstifadeciMail}' and IstifadeciParol=N'{c}'");
            if (dt.Rows.Count == 0 || IstifadeciMail == null || IstifadeciParol == null)
            {
                TempData["Message"] = "Istifadəçi mailiniz və ya parolunuz yanlışdır.Zəhmət olmasa yenidən cəhd edin!";
                return RedirectToAction("AdminLogin");
            }
            else
            {
                TempData["Message"] = "Əməliyyat uğurla həyata keçirildi!";
                HttpCookie cookie = new HttpCookie("User");
                cookie.Expires = DateTime.Now.AddDays(1d);
                cookie.Values.Add("UserId", dt.Rows[0][0].ToString());
                cookie.Values.Add("UserName", dt.Rows[0][1].ToString());
                cookie.Values.Add("UserTip", dt.Rows[0][4].ToString());
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index");
            }
        }


        public ActionResult ForgetPass()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("User");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookie);
            return RedirectToAction("AdminLogin");
        }

        public ActionResult kodal(string IstifadeciMail)
        {
            DataTable dt = Sql.Exec($"Select * from Istifadeci where IstifadeciMail=N'{IstifadeciMail}'");
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][5].ToString() == IstifadeciMail)
                {
                    Random a = new Random();
                    var kod = a.Next(100000, 9999999);
                    MailMessage mesajim = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("zairli.zahir@hotmail.com", "tankionline2017");
                    istemci.Port = 587;
                    istemci.Host = "smtp.live.com";
                    istemci.EnableSsl = true;
                    mesajim.To.Add(IstifadeciMail);
                    mesajim.From = new MailAddress("zairli.zahir@hotmail.com");
                    mesajim.Subject = "The Code for RePassword";
                    mesajim.Body = kod.ToString();
                    istemci.Send(mesajim);
                    TempData["Message"] = "Əməliyyat uğurla həyata keçirildi!";
                    Sql.Exec($"Update  Istifadeci set IstifadeciQurtar=N'{kod}' where IstifadeciMail=N'{IstifadeciMail }'");
                    return RedirectToAction("UpdatePass");
                }
                else
                {
                    TempData["Message"] = "Bu maildə istifadəçi tapılmadı";
                    return RedirectToAction("ForgetPass");
                }
            }
            else
            {
                TempData["Message"] = "Bu maildə istifadəçi tapılmadı!";
                return RedirectToAction("ForgetPass");
            }

        }


        public ActionResult UpdatePassword(string IstifadeciQurtar, string IstifadeciParol, string IstifadeciMail)
        {
            DataTable dt = Sql.Exec($"Select * from Istifadeci where IstifadeciMail=N'{IstifadeciMail}' and IstifadeciQurtar=N'{IstifadeciQurtar}' ");
            if (dt.Rows.Count != 0)
            {
                var l = CreateMD5("levengi" + IstifadeciParol + "levengi");
                if (IstifadeciQurtar == dt.Rows[0][6].ToString() && IstifadeciQurtar != null && IstifadeciQurtar != "0")
                {
                    Sql.Exec($"Update Istifadeci set IstifadeciParol=N'{l}', IstifadeciQurtar='0' where IstifadeciMail=N'{IstifadeciMail}'");
                    TempData["Message"] = "Kodunuz uğurla dəyişdirildi!";
                    return RedirectToAction("AdminLogin");
                }
                else
                {
                    TempData["Message"] = "Mail və ya random kod yanlışdır!";
                    return RedirectToAction("ForgetPass");
                }
            }
            else
            {
                TempData["Message"] = "Mail və ya random kod yanlışdır!";
                return RedirectToAction("ForgetPass");
            }
        }
        public ActionResult UpdatePass()
        {
            return View();
        }

        //---------------------------Materail----------------------------


        public ActionResult contact()
        {
            var cookie = Request.Cookies["User"];
            var id = cookie["UserId"];
            var id2 = Convert.ToInt32(id);

            List<Istifadeci> istifadeci = new List<Istifadeci>();
            ViewBag.istifadeci = db.Istifadeci.SingleOrDefault(x => x.IstifadeciId == id2);

            var tip = ViewBag.istifadeci.IstifadeciTipId;

            if (tip == 1)
            {
            List<contact> contact = new List<contact>();
            ViewBag.contact = db.contact.ToList();
            return View();
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }
        public ActionResult silcontact(int id)
        {
            db.contact.DeleteOnSubmit(db.contact.SingleOrDefault(x => x.ContactId == id));
            db.SubmitChanges();
            return RedirectToAction("contact");
        }
        public ActionResult team()
        {
            var cookie = Request.Cookies["User"];
            var id = cookie["UserId"];
            var id2 = Convert.ToInt32(id);

            List<Istifadeci> istifadeci = new List<Istifadeci>();
            ViewBag.istifadeci = db.Istifadeci.SingleOrDefault(x => x.IstifadeciId == id2);

            var tip = ViewBag.istifadeci.IstifadeciTipId;

            if (tip == 1)
            { 
                List<team> team = new List<team>();
            ViewBag.team = db.team.ToList();
            return View();
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }
        public ActionResult li()
        {

            var cookie = Request.Cookies["User"];
            var id = cookie["UserId"];
            var id2 = Convert.ToInt32(id);

            List<Istifadeci> istifadeci = new List<Istifadeci>();
            ViewBag.istifadeci = db.Istifadeci.SingleOrDefault(x => x.IstifadeciId == id2);

            var tip = ViewBag.istifadeci.IstifadeciTipId;

            if (tip == 1)
            { 
                List<melumatli> melumat = new List<melumatli>();
            ViewBag.melumat = db.melumatli.OrderBy(x => x.MelumatAd).ToList();
            List<melumataltli> melumatalt = new List<melumataltli>();
            ViewBag.melumatalt = db.melumataltli.OrderBy(x => x.MelumatAltLiAd).ToList();

            List<limain> limain = db.limain.ToList();
            ViewBag.limain = db.limain.OrderBy(x => x.MelumatAltLiAd).ToList();
            return View();
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }
        public ActionResult detal()
        {
            List<detalmain> detail = new List<detalmain>();
            ViewBag.detail = db.detalmain.ToList();

            List<melumataltli> altli = new List<melumataltli>();
            ViewBag.altli = db.melumataltli.ToList();
            return View();
        }

        public ActionResult yenikat(melumatli yenimelumat)
        {
            db.melumatli.InsertOnSubmit(yenimelumat);
            db.SubmitChanges();
            return RedirectToAction("li");
        }

        public ActionResult yenialtli(melumataltli yenimelumat)
        {
            db.melumataltli.InsertOnSubmit(yenimelumat);
            db.SubmitChanges();
            return RedirectToAction("li");
        }


        public ActionResult silmelumat(int id)
        {
            db.melumatli.DeleteOnSubmit(db.melumatli.SingleOrDefault(x => x.MelumatId == id));
            db.SubmitChanges();
            return RedirectToAction("li");
        }
        public ActionResult silaltli(int id)
        {
            db.melumataltli.DeleteOnSubmit(db.melumataltli.SingleOrDefault(x => x.MelumatAltLiId == id));
            db.SubmitChanges();
            return RedirectToAction("li");
        }


        public ActionResult editmelumat(int id)
        {
            var cookie = Request.Cookies["User"];
            var id3 = cookie["UserId"];
            var id2 = Convert.ToInt32(id3);

            List<Istifadeci> istifadeci = new List<Istifadeci>();
            ViewBag.istifadeci = db.Istifadeci.SingleOrDefault(x => x.IstifadeciId == id2);

            var tip = ViewBag.istifadeci.IstifadeciTipId;

            if (tip == 1)
            { 
                var edieditmelumat= db.melumatli.SingleOrDefault(x => x.MelumatId == id);
                return View(edieditmelumat);
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }

        public ActionResult upmelumat(int id, melumatli yeni)
        {
            melumatli old = db.melumatli.SingleOrDefault(x => x.MelumatId == id);
            old.MelumatAd = yeni.MelumatAd;
            db.SubmitChanges();
            return RedirectToAction("li");
        }




        public ActionResult editaltli(int id)
        {
            var cookie = Request.Cookies["User"];
            var id3 = cookie["UserId"];
            var id2 = Convert.ToInt32(id3);

            List<Istifadeci> istifadeci = new List<Istifadeci>();
            ViewBag.istifadeci = db.Istifadeci.SingleOrDefault(x => x.IstifadeciId == id2);

            var tip = ViewBag.istifadeci.IstifadeciTipId;

            if (tip == 1)
            {
                List<melumatli> melumat = db.melumatli.ToList();
                ViewBag.melumat = db.melumatli.OrderBy(x => x.MelumatAd).ToList();
                var editaltli = db.melumataltli.SingleOrDefault(x => x.MelumatAltLiId == id);
                return View(editaltli);
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        }

        public ActionResult upaltli(int id, melumataltli yeni)
        {
            melumataltli old = db.melumataltli.SingleOrDefault(x => x.MelumatAltLiId == id);
            old.MelumatAltLiAd = yeni.MelumatAltLiAd;
            old.MelumatAltLiMelumatId = yeni.MelumatAltLiMelumatId;
            db.SubmitChanges();
            return RedirectToAction("li");
        }

        public ActionResult silteam(int id)
        {
            db.team.DeleteOnSubmit(db.team.SingleOrDefault(x => x.TeamId == id));
            db.SubmitChanges();
            return RedirectToAction("team");
        }


        public ActionResult yeniteam(team yeniteam, HttpPostedFileBase TeamPhoto)
        {
            if (TeamPhoto != null)
            {
                string PhotoName = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(TeamPhoto.FileName);
                TeamPhoto.SaveAs(Server.MapPath("~/Content/images/team/" + PhotoName));
                yeniteam.TeamPhoto = PhotoName;
            }
            db.team.InsertOnSubmit(yeniteam);
            db.SubmitChanges();
            return RedirectToAction("team");
        }


        public ActionResult yenidetal(detail yeni, HttpPostedFileBase DetailPhoto1, HttpPostedFileBase DetailPhoto2, HttpPostedFileBase DetailPhoto3, HttpPostedFileBase DetailFile)
        {
            if (DetailPhoto1 != null)
            {
                string PhotoName = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(DetailPhoto1.FileName);
                DetailPhoto1.SaveAs(Server.MapPath("~/Content/images/team/" + PhotoName));
                yeni.DetailPhoto1= PhotoName;
            }
            if (DetailPhoto2 != null)
            {
                string PhotoName2 = "Photo2" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(DetailPhoto2.FileName);
                DetailPhoto2.SaveAs(Server.MapPath("~/Content/images/team/" + PhotoName2));
                yeni.DetailPhoto2 = PhotoName2;
            }
            if (DetailPhoto3 != null)
            {
                string PhotoName3 = "Photo3" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(DetailPhoto3.FileName);
                DetailPhoto3.SaveAs(Server.MapPath("~/Content/images/team/" + PhotoName3));
                yeni.DetailPhoto3 = PhotoName3;
            }
            if (DetailFile != null)
            {
                string FileName = "File" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(DetailFile.FileName);
                DetailFile.SaveAs(Server.MapPath("~/Content/images/team/" + FileName));
                yeni.DetailFile = FileName;
            }
            yeni.DetailTarix = DateTime.Now;
            db.detail.InsertOnSubmit(yeni);
            db.SubmitChanges();
            return RedirectToAction("detal");
        }

        public ActionResult sildetail(int id)
        {
            db.detail.DeleteOnSubmit(db.detail.SingleOrDefault(x => x.DetailId == id));
            db.SubmitChanges();
            return RedirectToAction("detal");
        }

    }
}