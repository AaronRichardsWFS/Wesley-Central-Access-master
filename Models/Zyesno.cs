using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Zyesno
    {
        public int ZyesnoId { get; set; }

        [MaxLength(10)]
        public string yesno { get; set; }

    }
}
