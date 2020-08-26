using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zhearabout
    {
        public int ZhearaboutId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Hear About")]
        public string hearabout { get; set; }

    }
}
