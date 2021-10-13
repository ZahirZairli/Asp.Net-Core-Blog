using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemoY.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoY.Controllers
{
    [AllowAnonymous]
    public class Register : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        RegisterCity cm = new RegisterCity();
        [HttpGet]
        public IActionResult Index()
        {


            List<SelectListItem> deger1 = (from x in cm.RegisterCities()
                                           select new SelectListItem
                                           {
                                               Text = x.CityName,   //optionun metni
                                               Value = x.CityName //optionun valuesi
                                           }).ToList();
            ViewBag.dpr = deger1;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
                if (results.IsValid)
                {
                    p.WriterStatus = true;
                    p.WriterAbout = "Deneme dir qaqa bu";
                    wm.WriterAdd(p);
                    ViewBag.mesaj = "Uğurla qeydiyyatdan keçdiniz!";
                    return RedirectToAction("Index", "Login");   
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            return View();
        }
    }
}
