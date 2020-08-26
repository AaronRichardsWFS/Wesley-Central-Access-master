using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zaction
    {
        public int ZactionId { get; set; }

        [MaxLength(255)]
        public string action { get; set; }

        [MaxLength(255)]
        public string report { get; set; }

        public bool active { get; set;}

    }
}
