using System;
using System.Data.Services.Client;
using System.Linq;
using Demo.MasterData.Consumer.Demo.MasterData.Services;

namespace Demo.MasterData.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            client.Execute();
        }
    }

    public class Client
    {
        public void Execute()
        {
            var uri = new Uri("http://localhost:63458/MasterDataService.svc");
            var context = new MasterDataContext(uri);

            var patients = (from patient in context.Patients.IncludeTotalCount()
                           where patient.Id > 2
                           select patient) as DataServiceQuery<Patient>;

            var result = patients.Execute() as QueryOperationResponse<Patient>;
            Console.WriteLine("There were {0} total patients.", result.TotalCount);

            foreach (var patient in result)
            {
                Console.WriteLine("{0}, {1}", patient.LastName, patient.FirstName);
            }

            Console.WriteLine();

            var projections = from patient in context.Patients
                              select new { Id = patient.Id, FullName = patient.LastName + ", " + patient.FirstName };

            foreach (var projection in projections)
            {
                Console.WriteLine("{0}-{1}", projection.Id, projection.FullName);
            }

            Console.ReadLine();
        }
    }
}
