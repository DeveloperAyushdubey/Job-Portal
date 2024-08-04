using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Projetc.Models
{
    public class Admin
    {
        public int id {  get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
        [Required]
        public string phone {  get; set; }  
    }
}