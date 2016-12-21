using OmniMerit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniMerit.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin u)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities de = new MyDatabaseEntities())
                {
                    var v = de.Users.Where(model => model.Username.Equals(u.Username) && model.Password.Equals(u.Password)).FirstOrDefault();
                    if(v != null)
                    {
                        Session["LoggedUserID"] = v.UserID.ToString();
                        Session["LoggedUsername"] = v.FullName.ToString();
                        return RedirectToAction("AfterLogin");
                        
                    }
                    else
                    {
                        ViewBag.Message = "Username or Password not correct!";
                        return View(u);
                    }
                }
            }
         
            ViewBag.Message = "Invalid Login Details";
            return View(u);
        }


        public ActionResult AfterLogin()
        {
            if(Session["LoggedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}