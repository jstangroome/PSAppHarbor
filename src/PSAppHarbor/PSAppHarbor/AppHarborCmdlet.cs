using System.Management.Automation;

namespace PSAppHarbor
{
    public abstract class AppHarborCmdlet : PSCmdlet
    {
        protected IAppHarborApi _api;
        
        protected void EnsureAuthenticated()
        {
            _api = ApiProvider.Instance.GetApi();
        }
    }
}