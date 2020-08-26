using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Service Description")]
        [DisplayFormat(NullDisplayText = "No service assigned")]
        public string service_desc { get; set; }

        [MaxLength(255)]
        [Display(Name = "Report")]
        public string report { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }

        [MaxLength(255)]
        [Display(Name = "Credible")]
        public string credible { get; set; }

        [MaxLength(255)]
        [Display(Name = "Temp")]
        public string temp { get; set; }

    }
}
