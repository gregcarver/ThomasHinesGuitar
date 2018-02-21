using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThomasHinesGuitar.Models;

namespace ThomasHinesGuitar.ViewModels
{
    public class AdminMainViewModel
    {
        public string Contact { get; set; }
        public string Location { get; set; }
        public IEnumerable<AdminMain> AdminMainList { get; set; }

    }
}