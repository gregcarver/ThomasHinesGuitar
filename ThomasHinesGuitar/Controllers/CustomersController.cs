using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,dateAdded")] CustomerOrder customer)
        {
            if (ModelState.IsValid)
            {
                db.CustomerOrder.Add(customer);
                db.SaveChanges();
                return RedirectToAction("customerOrderCheck");
            }

            return View(customer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customer = db.CustomerOrder.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Name,dateAdded")] CustomerOrder customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("customerOrderCheck");
            }
            return View(customer);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customer = db.CustomerOrder.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // POST: Dinner_Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerOrder customer = db.CustomerOrder.Find(id);
            db.CustomerOrder.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("customerOrderCheck");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }


}
