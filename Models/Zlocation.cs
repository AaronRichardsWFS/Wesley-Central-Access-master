using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zlocation
    {
        public int ZlocationId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Location")]
        public string location { get; set; }

        [MaxLength(255)]
        [Display(Name = "Report")]
        public string report { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }

        [MaxLength(255)]
        [Display(Name = "Credible Status")]
        public string credstatus { get; set; }

        [MaxLength(255)]
        [Display(Name = "Temp")]
        public string temp { get; set; }

    }
}
