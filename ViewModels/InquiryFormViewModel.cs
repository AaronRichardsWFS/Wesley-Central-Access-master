using WCAProject.Models;
using System.Collections.Generic;
namespace WCAProject.ViewModels
{
    public class InquiryFormViewModel
    {
        public Client Client { get; set; }
        public ClientService Inquiry { get; set; }

        public Clineitem Note { get; set; }

        public List<Clineitem> Notes { get; set; }

        public ScaScreen ScaScreen { get; set; }

    }
}
