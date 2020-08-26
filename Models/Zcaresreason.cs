using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zcaresreason
    {
        public int ZcaresreasonId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Care Reason")]
        public string caresreason { get; set; }
    }
}
