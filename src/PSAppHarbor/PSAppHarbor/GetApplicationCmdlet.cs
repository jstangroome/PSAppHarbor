using System.Management.Automation;
using System.Security.Authentication;
using AppHarbor;

namespace PSAppHarbor
{
    [Cmdlet(VerbsCommon.Get, "AHApplication")]
    public class GetApplicationCmdlet : PSCmdlet
    {
        private AppHarborApi _api;

        protected override void BeginProcessing()
        {
            if (string.IsNullOrEmpty(AccessTokenStore.Instance.AccessToken))
            {
                ThrowTerminatingError(new ErrorRecord(new AuthenticationException("Authenticate with Connect-AppHarbor"), string.Empty, ErrorCategory.SecurityError, null));
            }
            var authInfo = new AuthInfo { AccessToken = AccessTokenStore.Instance.AccessToken };
            _api = new AppHarborApi(authInfo);
        }

        [Parameter(Position=0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("ID")]
        public string[] ApplicationID { get; set; }
        
        protected override void ProcessRecord()
        {
            foreach (var id in ApplicationID)
            {
                WriteObject(_api.GetApplication(id));
            }

        }

        protected override void EndProcessing()
        {
            if (ApplicationID == null)
            {
                WriteObject(_api.GetApplications(), true);
            }
        }
    }
}
