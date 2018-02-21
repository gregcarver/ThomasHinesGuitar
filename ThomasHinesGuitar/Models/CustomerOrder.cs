using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        [Required]
        public int orderNumber { get; set; }
        [Required]
        public DateTime dateAdded { get; set; }
       
    }
}