using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zrace
    {
        public int ZraceId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Race")]
        public string race { get; set; }

        public bool active { get; set;}

    }
}
