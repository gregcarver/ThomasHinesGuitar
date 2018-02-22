using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThomasHinesGuitar.Models;
using ThomasHinesGuitar.ViewModels;

namespace ThomasHinesGuitar.Controllers
{
    public class AdminMainController : Controller
    { 

        // GET: AdminMAin

        [HttpGet]
        public ActionResult AdminMainPage()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AdminMainPage(AdminMain main)
        {
            AdminMain newmain = new AdminMain();
            string result = newmain.InsertContactDetails(main);
            ViewData["Result"] = result;
            ModelState.Clear();
            return View();
        }

    }
}