using System.Data.Entity;

namespace Demo.MasterData.Data.CodeFirst
{
    public class MasterDataContext : DbContext//, IMasterPatientContext
    {
        public MasterDataContext()
            : base("MasterData")
        {
            Configuration.ProxyCreationEnabled = false;
            //Database.CreateIfNotExists();
        }

        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Episode> Episodes { get; set; }
        public IDbSet<Visit> Visits { get; set; }
    }
}
