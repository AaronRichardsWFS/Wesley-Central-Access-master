using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zinternalcategory
    {
        public int ZinternalcategoryId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Internal Subcategory")]
        public string internalsubcat { get; set; }

    }
}
