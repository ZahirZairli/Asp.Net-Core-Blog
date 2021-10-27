using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriterBM(12);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CatList();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog newblog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(newblog);
            if (results.IsValid)
            {
                newblog.BlogStatus = true;
                newblog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                newblog.WriterId = 12;
                bm.TAdd(newblog);
                return RedirectToAction("BlogListByWriter","Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                CatList();
            }
            return View();
        }
        public void CatList()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CatList();
            var blogvalue = bm.TGetById(id);
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(b);
            if (results.IsValid)
            {
                b.WriterId = 12;
                var blogvalue = bm.TGetById(b.BlogId);
                b.BlogStatus = true;
                b.BlogCreateDate = blogvalue.BlogCreateDate;
                bm.TUpdate(b);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                CatList();
            }
            return View();
        }
    }
}
