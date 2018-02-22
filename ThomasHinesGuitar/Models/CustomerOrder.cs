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
       
        public int Id { get; set;}
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int orderNumber { get; set; }
        public DateTime dateAdded { get; set; }

        SqlConnection fluff = new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; AttachDbFilename=C:\Users\David Dannheim\Desktop\GitHub (Project for THG)\ThomasHinesGuitar\App_Data\aspnet-ThomasHinesGuitar-20180219110451.mdf;Initial Catalog = aspnet-ThomasHinesGuitar-20180219110451;Integrated Security = True");
        SqlCommand numberAndDate = new SqlCommand();
        
        public string insertCustomerDetails (CustomerOrder obj)
        {
            obj.orderNumber = obj.Id;
            obj.dateAdded = DateTime.Now;
            numberAndDate.CommandText = "Insert into CustomerOrders values ('" + obj.Email + "','" + obj.Name + "','" + obj.orderNumber + "','" + obj.dateAdded + "')";
            numberAndDate.Connection = fluff;

            try
            {
                fluff.Open();
                numberAndDate.ExecuteNonQuery();
                fluff.Close();
                return ("Success");
            }
            catch (Exception es)
            {
                throw es;
            }



        }


    }
}