﻿using System.Web;
using System.Web.Mvc;

namespace Demo.MasterData.Services
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}