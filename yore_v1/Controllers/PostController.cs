using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yore_v1.Models;

namespace yore_v1.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                using (PostsModel postModel = new PostsModel())
                {
                    return View(postModel.Posts.ToList());
                }
            }
            return View("~/Views/User/Login.cshtml");
        }

    }
}