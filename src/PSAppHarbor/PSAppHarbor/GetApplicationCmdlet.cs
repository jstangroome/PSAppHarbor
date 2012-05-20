using System.Management.Automation;

namespace PSAppHarbor
{
    [Cmdlet(VerbsCommon.Get, "AHApplication")]
    public class GetApplicationCmdlet : AppHarborCmdlet
    {
        protected override void BeginProcessing()
        {
            EnsureAuthenticated();
        }

        [Parameter(Position=0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [Alias("ID", "Slug")]
        public string[] ApplicationID { get; set; }
        
        protected override void ProcessRecord()
        {
            if (ApplicationID == null)
            {
                WriteObject(_api.GetApplications(), true);
            }
            else
            {
                foreach (var id in ApplicationID)
                {
                    WriteObject(_api.GetApplication(id));
                }
            }
        }

    }
}
