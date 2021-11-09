using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoY.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            int id = 12;
            var writervalues = wm.TGetById(id);
            return View(writervalues);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p,string Yoxla)
        {
            WriterValidator wv = new WriterValidator();
            int id = p.WriterId;
            var edited = wm.TGetById(id);
            p.WriterStatus = true;

            if (p.WriterPassword == null  && p.WriterPassword2 == null)
            {
                p.WriterPassword = edited.WriterPassword;
                p.WriterPassword2 = edited.WriterPassword2;
            }
            ValidationResult results = wv.Validate(p);
            if (results.IsValid && edited.WriterPassword == Yoxla)
            {
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.message = "Zəhmət olmasa köhnə şifrənizi daxil edin!";
            }

            return View();
        }
    }
}
