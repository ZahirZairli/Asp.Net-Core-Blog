using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoY.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.toplamblog = c.Blogs.Count().ToString();
            ViewBag.category = c.Categories.Count();
            ViewBag.sizinblog = c.Blogs.Where(x=>x.WriterId==12).Count();
            return View();
        }
    }
}
