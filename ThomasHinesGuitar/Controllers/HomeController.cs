using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using ThomasHinesGuitar.Models;

namespace ThomasHinesGuitar.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var aboutList = db.AboutModel.ToList();
            return View(aboutList);
        
        }

        [HttpPost]
        public ActionResult Contact()
        {
            ViewBag.Message = "Sample message";

            return View();
        }

        
        public ActionResult Error()
        {
            return View();
        }
    }
}