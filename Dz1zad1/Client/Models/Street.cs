using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class Street
    {
        [Display(Name = "Название улиц")]
        public string Name { get; set; }
    }
}