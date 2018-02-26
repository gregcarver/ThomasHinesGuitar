using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ThomasHinesGuitar.Models
{

    public class CustomerOrder
    {
       [Key]
        public int Id { get; set;}

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        
        //public int orderNumber { get; set; }
        public DateTime dateAdded { get; set; }

        public string insertCustomerDetails (CustomerOrder obj)
        {
                ApplicationDbContext db = new ApplicationDbContext();
                db.CustomerOrder.Add(obj).dateAdded = DateTime.Now;
                
            try
            {
                db.CustomerOrder.Add(obj);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}