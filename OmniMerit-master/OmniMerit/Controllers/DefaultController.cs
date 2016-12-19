using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace OmniMerit.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Career()
        {
            if (TempData["Message"]!=null)
            {
                ViewBag.Message = "Done Successfully";
            }
            return View();
        }
        public ActionResult Career1()
        {
            ViewBag.Message =null;
            return View();
        }
        public ActionResult Foundation()
        {
            ViewBag.Message = null;
            return View();
        }
        public ActionResult Engineering()
        {
            
            return View();
        }
        public ActionResult Medical()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ResumeUpload(FormCollection fc, HttpPostedFileBase file)
        {
            string name=string.Empty;
            string email=string.Empty;
            string path="";
            if (fc[0].ToString()!=null && fc[1].ToString()!=null)
            {
                 name = fc["name"].ToString();
                 email = fc["email"].ToString();
            }

            if (file != null && file.ContentLength > 0)
                try
                {
                     path = Path.Combine(Server.MapPath("~/Scripts/Images/resume"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                   
                    TempData["Message"]= "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
           


           

           
            return RedirectToAction("Career");
        }
    }
}