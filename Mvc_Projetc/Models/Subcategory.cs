using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Projetc.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public bool isstatus {  get; set; } 

        public string status { get; set; }

        [Required]
        public int cid { get; set; }
    }
}