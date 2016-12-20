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
        public ActionResult Login(User u)
        {
            if (!ModelState.IsValid)
            {
                using (MyDatabaseEntities de = new MyDatabaseEntities())
                {
                    var v = de.Users.Where(model => model.Username.Equals(u.Username) && model.Password.Equals(u.Password)).FirstOrDefault();
                    Console.Write(v);
                    if(v != null)
                    {
                        Session["LoggedUserID"] = v.UserID.ToString();
                        Session["LoggedUsername"] = v.FullName.ToString();
                        return RedirectToAction("AfterLogin");
                        //ViewBag.Message = "Login success";
                        //return View(u);
                    }
                }
            }
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