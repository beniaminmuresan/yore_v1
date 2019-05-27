using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yore_v1.Models;

namespace yore_v1.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            User userModel = new User();

            return View(userModel);
        }
        [HttpPost]
        public ActionResult Register(User userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Users.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exists";
                    return View("Register", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfull";
            return View("Register", new User());
        }
    }
}