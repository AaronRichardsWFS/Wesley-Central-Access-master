using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zschool
    {
        public int ZschoolId { get; set; }

        [MaxLength(255)]
        [Display(Name = "Site")]
        public string site { get; set; }

        [MaxLength(255)]
        [Display(Name = "School District")]
        public string schooldistrict { get; set; }

        [MaxLength(255)]
        [Display(Name = "Display Name")]
        public string displayname { get; set; }

        [MaxLength(255)]
        [Display(Name = "Therapist")]
        public string therapist { get; set; }

        [MaxLength(255)]
        [Display(Name = "Service Offered")]
        public string ServiceOffered { get; set; }

        [MaxLength(255)]
        [Display(Name = "Supervisor")]
        public string Supervisor { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set;}

    }
}
