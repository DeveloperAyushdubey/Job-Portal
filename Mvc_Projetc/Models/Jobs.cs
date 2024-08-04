using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Projetc.Models
{
    public class Jobs
    {
        public  int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string companyname { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string skills { get; set; }
        [Required]
        public string duration { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string qulification { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string ctc { get; set; }
        [Required]
        public string position { get; set; }
        [Required]
        public string education {  get; set; }
        [Required]
        public string responsibilities { get; set; }
        [Required]
        public int sid { get; set; }    
    }
}