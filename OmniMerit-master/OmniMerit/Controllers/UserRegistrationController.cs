using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniMerit.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        public ActionResult Register()
        {
            List<SelectListItem> classList = new List<SelectListItem>();
            classList.Add(new SelectListItem
            {
                Text = "8",
                Value = "8th"
            });
            classList.Add(new SelectListItem
            {
                Text = "9",
                Value = "9th"
            });
            classList.Add(new SelectListItem
            {
                Text = "10",
                Value = "10th"
            });
            classList.Add(new SelectListItem
            {
                Text = "11",
                Value = "11th"
            });
            classList.Add(new SelectListItem
            {
                Text = "12",
                Value = "12th"
            });
            ViewBag.ClassList = classList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities de = new MyDatabaseEntities())
                {
                    de.Users.Add(u);
                    de.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "Successfully Registered with us. \nThanks!";
                }
            }
            return View(u);
        }
    }
}