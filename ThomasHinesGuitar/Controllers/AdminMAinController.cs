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
        // Calls the adminmain class/model and initializes a obj for it.
        private Models.AdminMain main = new Models.AdminMain();
        // Does the same with the ApplicationDbContext Class
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMAin
        // Responds when the browser asks for the /admin/AdminMainPage
        // Authorize(Roles ="SuperUser") tells the controller to only run it's statement if the user is the SuperUser
        [HttpGet]
        [Authorize(Roles ="SuperUser")]
        public ActionResult AdminMainPage()
        {
            return View();
        }

        // Responds when the browser asks for the /admin/AdminCheckPage
        [HttpGet]
        [Authorize(Roles = "SuperUser")]
        public ActionResult AdminCheckPage()
        {
            var mainList = db.AdminMain.ToList();
            return View(mainList);
        }

        // pushes the model from the view to model to insert the data into the database.
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
        public ActionResult BuildAGuitar()
        {
            return View();
        }

    }
}