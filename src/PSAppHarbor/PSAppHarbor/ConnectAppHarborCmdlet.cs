using System.Management.Automation;
using System.Security.Authentication;
using RestSharp;
using RestSharp.Contrib;

namespace PSAppHarbor
{
    [Cmdlet(VerbsCommunications.Connect, "AppHarbor")]
    public class ConnectAppHarborCmdlet : PSCmdlet
    {
        [Credential]
        [Parameter(Mandatory = true, Position = 0)]
        public PSCredential Credential { get; set; }

        protected override void EndProcessing()
        {
            var networkCredential = Credential.GetNetworkCredential();
            var restClient = new RestClient("https://appharbor-token-client.apphb.com");
            var request = new RestRequest("/token", Method.POST);

            request.AddParameter("username", networkCredential.UserName);
            request.AddParameter("password", networkCredential.Password);

            WriteVerbose(string.Format("Requesting access token for user '{0}'", networkCredential.UserName));
            var response = restClient.Execute(request);
            var responseValues = HttpUtility.ParseQueryString(response.Content);
            if (!string.IsNullOrEmpty(responseValues["error"]))
            {
                WriteError(new ErrorRecord(new AuthenticationException(responseValues["error"]), string.Empty, ErrorCategory.SecurityError, null));
            }
            AccessTokenStore.Instance.AccessToken = responseValues["access_token"];
            WriteVerbose("Authenticated");
        }
    }
}
