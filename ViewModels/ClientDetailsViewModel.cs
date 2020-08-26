using WCAProject.Models;
using System.Collections.Generic;
namespace WCAProject.ViewModels
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public List<ClientService> Inquiries { get; set; }
        public ScaScreen ScaScreen { get; set; }

    }
}
