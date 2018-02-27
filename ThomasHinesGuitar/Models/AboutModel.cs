using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThomasHinesGuitar.Models
{
    public class AboutModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string aboutView { get; set; }
        public string insertAboutView(AboutModel obj)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                db.AboutModel.Add(obj);
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