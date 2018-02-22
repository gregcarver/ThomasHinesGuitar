using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ThomasHinesGuitar.Models;

namespace ThomasHinesGuitar.Controllers
{
    public class ContactViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactViewModels
        public ActionResult Index()
        {
            return View(db.ContactViewModels.ToList());
        }

        // GET: ContactViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contactViewModel = db.ContactViewModels.Find(id);
            if (contactViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contactViewModel);
        }

        // GET: ContactViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Subject,Message")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                db.ContactViewModels.Add(contactViewModel);
                //TempData["Id"] = contactViewModel.Id;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(contactViewModel);
        }

        // GET: ContactViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contactViewModel = db.ContactViewModels.Find(id);
            if (contactViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contactViewModel);
        }

        // POST: ContactViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Subject,Message")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(contactViewModel);
        }

        // GET: ContactViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contactViewModel = db.ContactViewModels.Find(id);
            if (contactViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contactViewModel);
        }

        // POST: ContactViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactViewModel contactViewModel = db.ContactViewModels.Find(id);
            db.ContactViewModels.Remove(contactViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("keelan.burnhamprovalus@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("youremailid@gmail.com", "password");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
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
