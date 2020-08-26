using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zworker
    {
        public int ZworkerId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Worker Name")]
        public string worker { get; set; }

        [MaxLength(255)]
        [Display(Name = "Report")]
        public string report { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set;}

        

        [MaxLength(255)]
        [Display(Name = "A/D Username")]
        public string UserName { get; set; }






    }
}
