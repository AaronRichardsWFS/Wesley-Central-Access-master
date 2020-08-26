using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zinternal
    {
        public int ZinternalId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Internal Type")]
        public string internal_type { get; set; }

        [MaxLength(255)]
        [Display(Name = "Report")]
        public string report { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set;}

        [Display(Name = "Credible Status")]
        [MaxLength(255)]
        public string credstatus { get; set; }

        [Display(Name = "Temp")]
        [MaxLength(255)]
        public string temp { get; set; }

    }
}
