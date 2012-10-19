using System;
using System.Linq;

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
            var context = new Demo.MasterData.Services.MasterDataContext(uri);

            var patients = from patient in context.Patients
                           where patient.Id > 2
                           select patient;

            foreach (var patient in patients)
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
