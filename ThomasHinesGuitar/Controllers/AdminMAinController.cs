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
        private ApplicationDbContext _context;
        // GET: AdminMAin

        public AdminMainController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult AdminMainPage()
        {
            var viewModel = new AdminMainViewModel
            {
                AdminMainList = _context.AdminMain.ToList()
            };
            return View();
        }

        [HttpPost]
        public ActionResult AdminMainPage(AdminMainViewModel viewModel)
        {
            //var adminId = User.Identity.GetUserId();
            //var contacts = _context.Users.Single(u => u.Id == adminId);
            //var location = _context.AdminMain.Single();


            return View();
        }

    }
}