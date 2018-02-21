using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThomasHinesGuitar.FormViewModels
{
    public class CustomerOrderViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int orderNumber { get; set; }
        public DateTime dateAdded { get; set; }
    }
}