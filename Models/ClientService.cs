using System;
using System.ComponentModel.DataAnnotations;

namespace WCAProject.Models
{
    public class ClientService
    {
        public int ClientServiceId { get; set; }

        // fk
        [Display(Name = "Who is Inquiry From? (Client Name)")]
        public int? ClientId { get; set; }
        public Client Client { get; set; }

        [Display(Name = "What Service Are They Requesting?")]
        public int? ServiceId { get; set; }
        public Service Service { get; set; }

        [Display(Name = "Reason for Care")]
        public int? ZcaresreasonId { get; set;}
        public Zcaresreason Zcaresreason { get; set; }

        [Display(Name = "Heard About")]
        public int? ZhearaboutId { get; set; }
        public Zhearabout Zhearabout { get; set; }

        [Display(Name = "Internal Type")]
        public int? ZinternalId { get; set; }
        public Zinternal Zinternal { get; set; }

        [Display(Name = "Internal Category")]
        public int? ZinternalcategoryId { get; set; }
        public Zinternalcategory Zinternalcategory { get; set; }

        [Display(Name = "Location")]
        public int? ZlocationId { get; set; }
        public Zlocation Zlocation { get; set; }

        [Display(Name = "OP Type")]
        public int? ZopotherId { get; set; }
        public Zopother Zopother { get; set; }

        [Display(Name = "Platform A")]
        public int? ZplatformId { get; set; }
        public Zplatform Zplatform { get; set; }

        [Display(Name = "Program")]
        public int? ZprogramsId { get; set; }
        public Zprograms Zprograms { get; set; }

        [Display(Name = "Reason for Resource")]
        public int? ZresourcereasonId { get; set; }
        public Zresourcereason Zresourcereason { get; set; }

        [Display(Name = "Site")]
        public int? ZsiteId { get; set; }
        public Zsite Zsite { get; set; }

        [Display(Name = "School")]
        public int? ZschoolId { get; set; }
        public Zschool Zschool { get; set; }

        // not a fk
        [Display(Name = "Other Site")]
        public string site2 { get; set; }

        //more fks
        [Display(Name = "Status")]
        public int? ZstatusId { get; set; }
        public Zstatus Zstatus { get; set; }

        [Display(Name = "Status Reason")]
        public int? ZreasonId { get; set; }
        public Zreason Zreason { get; set; }

        [Display(Name = "Worker")]
        public int? ZworkerId { get; set; }
        public Zworker Zworker { get; set; }

        // main

        [DataType(DataType.Date)]
        [Display(Name = "Date Received")]
        [DisplayFormat(NullDisplayText = "No receive date assigned", DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? recdate { get; set; }

        [Display(Name = "Site Other")]
        public string site_other { get; set; }

        [Display(Name = "Diagnosis")]
        public string diagnosis { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Closed")]
        public DateTime? closedate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Evaluation Date")]
        public string eval_date { get; set; }

        [Display(Name = "BHRS Diagnosis")]
        public string bhrs_diag { get; set; }

        [Display(Name = "Prescription")]
        public string prescription { get; set; }

        [Display(Name = "Family Available")]
        public string family_avail { get; set; }

        [Display(Name = "Psychologist")]
        public string psychologist { get; set; }

        [Display(Name = "Plan of Care Dates")]
        public string pocdates { get; set; }

        [Display(Name = "Internal or External")]
        public string intext {get; set;}

        [Display(Name = "Note")]
        public string intnote {get; set;}

        [Display(Name = "External Type")]
        public string exttype {get; set;}

        [Display(Name = "Note")]
        public string extnote {get; set;}

        [DataType(DataType.Date)]
        [Display(Name = "Track Date")]
        public string trackdate {get; set;}

        [Display(Name = "Track Note")]
        public string tracknote {get; set;}

        [Display(Name = "Home location")]
        public string homeloc {get; set;}

        [Display(Name = "School location")]
        public string schoolloc {get; set;}

        [Display(Name = "OP Type")]
        public string optype {get; set;}

        // main + specific screening questions for MH OP

        [Display(Name = "Currently in MH or D&A Treatment?")]
        public string treatment { get; set; }

        [Display(Name = "Thoughts of Harming Self/Others?")]
        public string harm { get; set; }

        [Display(Name = "Do you have children?")]
        public string child { get; set; }

        [Display(Name = "Have you had Recent Substance Use?")]
        public string substance { get; set; }

        [Display(Name = "Are you Injecting Drugs?")]
        public string drug { get; set; }

        [Display(Name = "Are you Experiencing any Withdraw Symptoms?")]
        public string withdraw { get; set; }

        [Display(Name = "Are you involved in any Legal Issues?")]
        public string legal { get; set; }

        [Display(Name = "Is above issue Court Ordered?")]
        public string court { get; set; }

        // main + specific screening questions for D&A

        [Display(Name = "What is your Maiden Name? (if applicable)")]
        public string maiden { get; set; }

        [Display(Name = "What Substances were you Using?")]
        public string what_sub { get; set; }

        [Display(Name = "Last Date of Use? (if applicable)")]
        public string last_date { get; set; }

        [Display(Name = "How Much and how Often? (if applicable)")]
        public string much_often { get; set; }

        [Display(Name = "Have you Recently been Treated for an Overdose?")]
        public string overdose { get; set; }

        [Display(Name = "Have you Recieved Mental Health Treatment? (when and type?)")]
        public string mental { get; set; }

        [Display(Name = "Are you Pregnant/Any Possibilities of so?")]
        public string pregnant { get; set; }

        [Display(Name = "Have you Given Birth in the Last 28 Days?")]
        public string birth { get; set; }

        [Display(Name = "Are you a Veteran?")]
        public string veteran { get; set; }

        [Display(Name = "Have you Injected Drugs?")]
        public string drug_da { get; set; }

        [Display(Name = "Are you Experiencing any Withdraw Symptoms?")]
        public string withdraw_da { get; set; }

        [Display(Name = "Thoughts of Harming Self/Others?")]
        public string harm_da { get; set; }
    }
}
