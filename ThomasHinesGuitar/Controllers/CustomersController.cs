using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThomasHinesGuitar.Models;
using ThomasHinesGuitar.ViewModels;


namespace ThomasHinesGuitar.Controllers
{
    public partial class AdminController : Controller
    {
        private ApplicationDbContext _context;
        // GET: AdminMAin
        //private ApplicationDbContext db = new ApplicationDbContext();
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize(Roles = "SuperUser")]
        [HttpGet]
        public ActionResult CustomerOrderView()
        {
            return View();
        }
        //[Authorize]
        [HttpPost]
        public ActionResult CustomerOrderView(CustomerOrder order)
        {
            CustomerOrder newOrder = new CustomerOrder();
            string result = newOrder.insertCustomerDetails(order);
            ViewData["Success"] = result;
            ModelState.Clear();           
            return View();
        }
        [Authorize(Roles = "SuperUser")]
        [HttpGet]
        public ActionResult customerOrderCheck()
        {
            var customerIDlist = db.CustomerOrder.ToList();
            return View(customerIDlist);
        }
        [Authorize(Roles = "SuperUser")]
        [HttpGet]
        public ActionResult aboutView()
        {
            return View();
        }
        [Authorize(Roles = "SuperUser")]
        [HttpPost]
        public ActionResult aboutView(AboutModel aboutobj)
        {
            AboutModel about = new AboutModel();
            string result = about.insertAboutView(aboutobj);
            return View();
        }
    }
}
