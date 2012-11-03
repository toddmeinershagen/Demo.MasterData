//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Web;
using CodeFirst = Demo.MasterData.Data.CodeFirst;
//using DbFirst = Demo.MasterData.Data.DbFirst;
//using Custom = Demo.MasterData.Data.Custom;

namespace Demo.MasterData.Services
{
    public class MasterDataService : DataService<CodeFirst.MasterDataContext>
    {
        public MasterDataService()
        {
            this.ProcessingPipeline.ProcessingRequest += ProcessingPipeline_ProcessingRequest;
        }

        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);

            //config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.UseVerboseErrors = true;
            //config.SetEntitySetPageSize("Patients", 2);
            //config.SetEntitySetAccessRule("Patients", EntitySetRights.AllRead | EntitySetRights.WriteDelete | EntitySetRights.WriteAppend);
            config.SetEntitySetAccessRule("Patients", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Episodes", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Visits", EntitySetRights.AllRead);
            //config.SetEntitySetPageSize("Patients", 1);
            
            //Explore Behavior Settings:  config.DataServiceBehavior.?
            config.SetServiceOperationAccessRule("GetPatientsWithLastNameStartingWith", ServiceOperationRights.AllRead);
        }

        void ProcessingPipeline_ProcessingRequest(object sender, DataServiceProcessingPipelineEventArgs e)
        {
            
        }

        [QueryInterceptor("Patients")]
        public Expression<Func<CodeFirst.Patient, bool>> OnQueryPatients()
        {
            return patient => true;
        }

        [WebGet]
        public IQueryable<CodeFirst.Patient> GetPatientsWithLastNameStartingWith(string prefix)
        {
            var context = this.CurrentDataSource;
            return from patient in context.Patients
                   where patient.LastName.StartsWith(prefix)
                   select patient;
        }
    }
}
