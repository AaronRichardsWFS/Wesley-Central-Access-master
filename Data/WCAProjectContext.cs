using Microsoft.EntityFrameworkCore;
using WCAProject.Models;

namespace WCAProject.Data
{
    public class WCAProjectContext : DbContext
    {
        public WCAProjectContext (DbContextOptions<WCAProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ClientService> ClientServices { get; set; }

        public DbSet<Clineitem> Clineitems { get; set; }

        public DbSet<ScaScreen> ScaScreen { get; set; }

        public DbSet<Zaction> Zaction { get; set; }
        public DbSet<Zcaresreason> Zcaresreason { get; set; }
        public DbSet<Zcounty> Zcounty { get; set; }
        public DbSet<Zhearabout> Zhearabout { get; set; }
        public DbSet<Zinsurance> Zinsurance { get; set; }
        
        public DbSet<Zinternal> Zinternal { get; set; }
        public DbSet<Zinternalcategory> Zinternalcategory { get; set; }
        public DbSet<Zlocation> Zlocation { get; set; }
        public DbSet<Zopother> Zopother { get; set; }
        public DbSet<Zplatform> Zplatform { get; set; }
        public DbSet<Zprograms> Zprograms { get; set; }
        public DbSet<Zrace> Zrace { get; set; }
        public DbSet<Zreason> Zreason { get; set; }
        public DbSet<Zreferralsource> Zreferralsource { get; set; }
        public DbSet<Zresourcereason> Zresourcereason { get; set; }
        public DbSet<Zschool> Zschool { get; set; }
        public DbSet<Zsite> Zsite { get; set; }
        public DbSet<Zstatus> Zstatus { get; set; }
        public DbSet<Zworker> Zworker { get; set; }
        public DbSet<Zyesno> Zyesno { get; set; }
    }

}
