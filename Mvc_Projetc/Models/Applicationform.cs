using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Projetc.Models
{
    public class Applicationform
    {
        public int id {  get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        
        [Required]
        public string  education { get; set; }
       
        [Required]
        public string Experience { get; set; }
        public string status { get; set; }

        [Required]
        public string resume { get; set; }
        [Required]
        public int jid {  get; set; }   


    }
}