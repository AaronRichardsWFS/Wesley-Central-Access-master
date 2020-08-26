using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zresourcereason
    {
        public int ZresourcereasonId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Resource Reason")]
        public string resourceresult { get; set; }

    }
}
