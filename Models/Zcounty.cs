using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zcounty
    {
        public int ZcountyId { get; set; }

        [Display(Name = "County")]
        [MaxLength(50)]
        public string county { get; set; }
    }
}
