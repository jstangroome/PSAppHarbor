using System;

namespace PSAppHarbor
{
    public class ApiProvider
    {
        // TODO consider using PowerShell session variables because statics are likely shared across RunSpaces
        public static readonly ApiProvider Instance = new ApiProvider();

        public Func<IAppHarborApi> GetApi { get; set; }
    }
}
