using System.Collections.Generic;
using System.Linq;
using AppHarbor.Model;

namespace PSAppHarbor.Tests
{
    class FakeAppHarborApi : IAppHarborApi
    {
        public IList<Application> ApplicationsToReturn { get; set; }

        public Application GetApplication(string applicationID)
        {
            return ApplicationsToReturn.FirstOrDefault();
        }

        public IList<Application> GetApplications()
        {
            return ApplicationsToReturn;
        }
    }
}