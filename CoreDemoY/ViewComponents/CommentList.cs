using CoreDemoY.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoY.ViewComponents
{
    public class CommentList : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    UserName = "Ilqar Bedirzade"
                },
                new UserComment
                {
                    Id = 2,
                    UserName = "Vuqar Bedirzade"
                },
                                new UserComment
                {
                    Id = 3,
                    UserName = "Mahir Bedirzade"
                }
            };
            return View(commentvalues);
        }
    }
}
