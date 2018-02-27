using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThomasHinesGuitar.Models;

namespace ThomasHinesGuitar.Controllers
{
    public partial class AdminController : Controller
    {
        private Models.AdminMain main = new Models.AdminMain();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMAin

        [HttpGet]
        [Authorize(Roles ="SuperUser")]
        public ActionResult AdminMainPage()
        {
            //var mainList = db.AdminMain.ToList();
            ////ViewBag.MainList = mainList.LastOrDefault();
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "SuperUser")]
        public ActionResult AdminCheckPage()
        {
            var mainList = db.AdminMain.ToList();
            //var mainItem = mainList.LastOrDefault();
            return View(mainList);
        }

        [Authorize(Roles = "SuperUser")]
        [HttpPost]
        public ActionResult AdminMainPage(AdminMain inMain)
        {
            string result;
            if (ModelState.IsValid)
            {
                try
                {
                    result = main.InsertContactDetails(inMain);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            
            


            return View();
        }

    }
}