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
    // Model for the admin controller and views. This is the blueprint for the admin database.
    public class AdminMain
    {
        // This is the Id column declaration every table must have one. This always increments by 1 with each new entry.
        public int Id { get; set; }

        // These are the data fields of the table they are where we'll be holding our actual data.
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Location { get; set; }


        /// <summary>
        /// Takes the data from the controller that was passed from the view.  
        /// </summary>
        /// <param name="inMain"></param>
        /// <returns></returns>
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
        /// <summary>
        /// </summary>
        /// <param name="inMain"></param>
        /// <returns></returns>
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