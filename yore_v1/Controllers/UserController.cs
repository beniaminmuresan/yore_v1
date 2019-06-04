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
        public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserID"] != null)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            User user = new User();
            return View(user);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            User user = new User();
            return View("Login", user);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Users.Any(x => x.Username == user.Username && x.Password == user.Password))
                {
                    Session["UserID"] = user.UserID.ToString();
                    Session["Username"] = user.Username.ToString();
                    return View("~/Views/Home/Index.cshtml");
                }
            }
            ModelState.Clear();
            ViewBag.LoginErrorMessage= "Invalid username or Password";
            return View("Login", new User());
        }
    }
}