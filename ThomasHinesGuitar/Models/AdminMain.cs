using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ThomasHinesGuitar.Models
{
    public class AdminMain
    {
        public int Id { get; set; }

        [Required]
        public string Contact { get; set; }
        [Required]
        public string Location { get; set; }


        public string InsertContactDetails(AdminMain inMain)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.AdminMain.Add(inMain);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AdminMain PullContactDetails(AdminMain inMain)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                inMain = db.AdminMain.LastOrDefault();
                return inMain;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}