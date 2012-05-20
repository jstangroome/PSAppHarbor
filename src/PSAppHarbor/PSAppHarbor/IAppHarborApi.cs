using System.Collections.Generic;
using AppHarbor.Model;

namespace PSAppHarbor
{
    public interface IAppHarborApi
    {
        Application GetApplication(string applicationID);
        IList<Application> GetApplications();
    }
}