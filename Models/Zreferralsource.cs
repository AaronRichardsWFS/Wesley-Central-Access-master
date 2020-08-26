using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zreferralsource
    {
        public int ZreferralsourceId { get; set; }

        [MaxLength(50)]
        public string referralsource { get; set; }

    }
}
