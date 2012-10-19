//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Data.Services;
using System.Data.Services.Common;
using CodeFirst = Demo.MasterData.Data.CodeFirst;
using DbFirst = Demo.MasterData.Data.DbFirst;
using Custom = Demo.MasterData.Data.Custom;

namespace Demo.MasterData.Services
{
    public class MasterDataService : DataService<Custom.MasterDataContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);

            config.UseVerboseErrors = true;
            //config.SetEntitySetPageSize("Patients", 2);
            config.SetEntitySetAccessRule("Patients", EntitySetRights.AllRead | EntitySetRights.WriteDelete | EntitySetRights.WriteAppend);
            //config.SetEntitySetAccessRule("Patients", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Episodes", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Visits", EntitySetRights.AllRead);
           
            //config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            //Explore Behavior Settings:  config.DataServiceBehavior.?
            
        }
    }
}
