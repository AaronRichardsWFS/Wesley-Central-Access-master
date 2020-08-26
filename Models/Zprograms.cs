using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zprograms
    {
        public int ZprogramsId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Program Id")]
        public string programs_id { get; set; }

        [MaxLength(255)]
        [Display(Name = "Program Description")]
        public string program_desc { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set;}

    }
}
