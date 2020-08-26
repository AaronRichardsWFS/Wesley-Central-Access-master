using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class ScaScreen {

        public int ScaScreenId { get; set; }

        [Display(Name = "Client Name")]
        public int? ClientId { get; set; }
        public Client Client { get; set; }

        [Display(Name = "Inquiry")]
        public int? ClientServiceId { get; set; }
        public ClientService ClientService { get; set; }

        //main
        [Display(Name = "WS Clinic")]
        public int? wsclinic { get; set; }

        [Display(Name = "Referral Source")]
        [MaxLength(50)]
        public string referralsource { get; set; }

        [Display(Name = "Why Family Seen")]
        [MaxLength(500)]
        public string whyfamilyseen { get; set; }

        [Display(Name = "Treatment History")]
        [MaxLength(50)]
        public string treatmenthistory { get; set; }

        [Display(Name = "ASD Diagnosis")]
        [MaxLength(50)]
        public string asddiagnosis { get; set; }

        [Display(Name = "Halfway Shelter")]
        [MaxLength(50)]
        public string halfwayshelter { get; set; }

        [Display(Name = "Recently Moved")]
        [MaxLength(50)]
        public string recentlymove { get; set; }

        [Display(Name = "Outside VBH")]
        [MaxLength(50)]
        public string outsidevbh { get; set; }

        [Display(Name = "Meet Criteria")]
        [MaxLength(50)]
        public string meetcriteria { get; set; }

        [Display(Name = "Referral Details")]
        [MaxLength(500)]
        public string referraldetails { get; set; }

        [Display(Name = "Shelter Details")]
        [MaxLength(500)]
        public string shelterdetails { get; set; }

        [Display(Name = "Was State Notified?")]
        [MaxLength(50)]
        public string wasstatenotified { get; set; }

        [Display(Name = "General Note")]
        [MaxLength(500)]
        public string gennote { get; set; }

        [Display(Name = "Private Insurer")]
        [MaxLength(250)]
        public string privateinsurer { get; set; }

        [Display(Name = "Private Insurance")]
        [MaxLength(50)]
        public string privateinsurance { get; set; }

        [Display(Name = "Managed Care Type")]
        [MaxLength(50)]
        public string managedcaretype { get; set; }

        [Display(Name = "Requested Location")]
        [MaxLength(50)]
        public string requestedlocation { get; set; }

        [Display(Name = "Service Requested")]
        [MaxLength(50)]
        public string servicerequested { get; set; }

        [Display(Name = "Current County")]
        [MaxLength(50)]
        public string currentcounty { get; set; }

    }

}
