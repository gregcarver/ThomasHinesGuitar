using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThomasHinesGuitar.FormViewModels;
using ThomasHinesGuitar.Models;

namespace ThomasHinesGuitar.Controllers
{
    public class CustomerOrderController : Controller
    {
        private ApplicationDbContext _context;
        // GET: AdminMAin

        public CustomerOrderController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CustomerOrderViewModel
            {
                //CustomerOrder = _context.CustomerOrders.ToList()
            };
            return View(viewModel);
        }
    }
}
