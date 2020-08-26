using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zreason
    {
        public int ZreasonId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Reason")]
        public string final_reason { get; set; }

        [Display(Name = "Report")]
        [MaxLength(255)]
        public string report { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set;}

        [Display(Name = "Match Status")]
        [MaxLength(50)]
        public string status_match { get; set; }

    }
}
