using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Demo.MasterData.Consumer.Demo.MasterData.Services;

namespace Demo.MasterData.Consumer
{
    internal class Program
    {
        private static void Main(string[] args)
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

            HandleInlineCount(context);
            HandleProjection(context);
            //HandleWebApiClient(uri);

            Console.ReadLine();
        }

        /// <summary>
        /// This requires the service to run as v2 because the HttpClient Accept headers do not accept "odata=verbose" which is required for v3.
        /// </summary>
        /// <param name="uri"></param>
        private static void HandleWebApiClient(Uri uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("odata=verbose"));
                client.BaseAddress = new Uri(uri.AbsoluteUri + "/Patients");
                HttpResponseMessage resp = client.GetAsync("").Result;
                string jsonString = resp.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsonString);
            }
        }

        private static void HandleProjection(MasterDataContext context)
        {
            var projections = from patient in context.Patients
                              select new {Id = patient.Id, FullName = patient.LastName + ", " + patient.FirstName};

            foreach (var projection in projections)
            {
                Console.WriteLine("{0}-{1}", projection.Id, projection.FullName);
            }
        }

        private static void HandleInlineCount(MasterDataContext context)
        {
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
        }
    }
}