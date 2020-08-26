using WCAProject.Models;
using System.Collections.Generic;
namespace WCAProject.ViewModels
{
    public class InquiryDetailsViewModel
    {
        public Client Client { get; set; }
        public ClientService Inquiry { get; set; }
        public List<Clineitem> Notes { get; set; }
        public ScaScreen ScaScreen { get; set; }
    }
}
