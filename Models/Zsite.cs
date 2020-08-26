using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zsite
    {
        public int ZsiteId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Site")]
        public string site { get; set; }

        [MaxLength(255)]
        [Display(Name = "Report")]
        public string report { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set;}

    }
}
