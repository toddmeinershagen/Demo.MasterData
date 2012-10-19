using System.Collections.Generic;
using System.Linq;

namespace Demo.MasterData.Data.Custom
{
    public class MasterDataContext
    {
        public MasterDataContext()
        {
            var patient1 = new Patient {Id = 1, FirstName = "Stewart", LastName = "Maxwell"};
            patient1.Episodes.Add(new Episode{Id = 1});
            patient1.Episodes.Add(new Episode{Id = 2});

            var patient2 = new Patient {Id = 2, FirstName = "Bao", LastName = "Vu"};

            Patients = new List<Patient>
                {
                   patient1, patient2
                }.AsQueryable();
        }

        public IQueryable<Patient> Patients { get; set; }
        public IQueryable<Episode> Episodes { get; set; }
        public IQueryable<Visit> Visits { get; set; }
    }
}
