using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zplatform
    {
        public int ZplatformId { get; set; }

        [DataType("numeric(18,0)")]
        [Display(Name = "Internal Id")]
        public int? internalId { get; set; }

        [MaxLength(250)]
        [Display(Name = "Platform")]
        public string opplatform { get; set; }

    }
}
