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

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

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
    }
}
