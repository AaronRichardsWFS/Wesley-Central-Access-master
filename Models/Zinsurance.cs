using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zinsurance
    {
        public int ZinsuranceId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Insurance")]
        public string insurance { get; set; }

        [MaxLength(255)]
        [Display(Name = "Report")]
        public string report { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set;}

    }
}
