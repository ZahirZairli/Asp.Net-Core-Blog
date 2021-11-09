using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoY.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutRepository());
        public IActionResult About()
        {
            var values = am.GetList();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
