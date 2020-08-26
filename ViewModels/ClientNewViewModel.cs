using WCAProject.Models;
using System.Collections.Generic;
namespace WCAProject.ViewModels
{
    public class ClientNewViewModel
    {
        public Client c { get; set; }
        public ClientService Inquiry { get; set; }
        public Clineitem Note { get; set; }
        public ScaScreen sca { get; set; }

    }
}
