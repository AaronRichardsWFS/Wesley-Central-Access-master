using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WCAProject.Models
{
    public class Client
    {

        public int ClientId { get; set; }

        // fk
        [Display(Name = "County")]
        public int? ZcountyId { get; set; }
        public Zcounty Zcounty { get; set; }

        [Display(Name = "Race")]
        public int? ZraceId { get; set; }
        public Zrace Zrace { get; set; }

        [Display(Name = "Primary Insurance")]
        public int? ZinsuranceId { get; set; }
        public Zinsurance Zinsurance { get; set; }

        // [Display(Name = "SCA Screening")]
        // public int? ScaScreenId { get; set; }
        // public ScaScreen ScaScreen { get; set; }

        // making this open field so not technically fk
        [Display(Name = "Secondary Insurance")]
        public int? insurance2 { get; set; }

 

        // main

        [RegularExpression(@"^[A-Z]+[-A-Za-z]*$", ErrorMessage = "First name must be capitalized.")]
        [Display(Name = "Client First")]
        public string cfirst { get; set; }

        [RegularExpression(@"^[A-Z]+[-A-Za-z]*$", ErrorMessage = "Last name must be capitalized.")]
        [Display(Name = "Client Last")]
        public string clast { get; set; }

        [Display(Name = "Full Name")]
        [DisplayFormat(NullDisplayText = "Name not assigned")]
        public string name
        {
            get
            {
              if(clast != null){
                if(cfirst != null){
                  return clast + ", " + cfirst;
                }
                return clast;
              }else if (cfirst != null){
                return cfirst;
              }
              return "";
            }
        }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Email 2")]
        public string email2 { get; set; }

        // [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        // [MaxLength(255, ErrorMessage = "Must be no more than 255 characters.")]
        // [Display(Name = "Email Address")]
        // public string email2 { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Format: XXX-XXX-XXXX.")]
        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Format: XXX-XXX-XXXX.")]
        [Display(Name = "Phone Number 2")]
        public string phone2 { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DOB")]
        public DateTime? dob { get; set; }

        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Format: XXX-XX-XXXX.")]
        [Display(Name = "SSN")]
        public string ssn { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "Zip")]
        public string zipcode { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [DataType("numeric(2,0)", ErrorMessage = "Enter a valid age")]
        [Display(Name = "Age")]
        public int? age { get; set;}

        [Display(Name = "Secondary Insurance")]
        public string ins_other { get; set; }

        [Display(Name = "Primary Insurance Notes")]
        public string ins_note { get; set; }

        [Display(Name = "Secondary Insurance Notes")]
        public string ins_other_note { get; set; }

        [Display(Name = "Credible Id")]
        public string CredibleID { get; set;}

        [Display(Name = "Client Notes/Warnings")]
        public string nextactionnote { get; set; }

        [Display(Name = "Contact Name/Relationship")]
        public string contact { get; set; }

        [Display(Name = "Contact Name/Relationship 2")]
        public string contact2 { get; set; }
    }
}
