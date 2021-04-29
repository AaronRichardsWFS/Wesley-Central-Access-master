using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class Clineitem
    {
        public int ClineitemId { get; set; }

        public int? ClientServiceId { get; set; }
        public ClientService ClientService { get; set; }

        [Display(Name = "Worker")]
        public int? ZworkerId { get; set; }
        public Zworker Zworker { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(NullDisplayText = "No receive date assigned", DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? ldate { get; set; }

        [MaxLength(255)]
        public string action { get; set; }

        /*Z action drop down*/ 
        [Display(Name = "Action")]
        public int? ZactionId { get; set; }
        public Zaction Zaction { get; set; }
    }
}
