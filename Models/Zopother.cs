using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zopother
    {
        public int ZopotherId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Other Op")]
        public string opother { get; set; }

    }
}
