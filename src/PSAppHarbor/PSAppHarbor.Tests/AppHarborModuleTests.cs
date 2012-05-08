using System.Management.Automation;

namespace PSAppHarbor.Tests
{
    public class AppHarborModuleTests
    {
        protected PowerShell PowerShellWithAppHarborModule()
        {
            var moduleName = typeof(ConnectAppHarborCmdlet).Assembly.Location;
            var shell = PowerShell.Create();
            shell.AddCommand("Import-Module").AddParameter("Name", moduleName);
            shell.Invoke();
            return shell;
        }

        protected PowerShell PowerShellWithLiveConnectedAppHarborModule()
        {
            var moduleName = typeof(ConnectAppHarborCmdlet).Assembly.Location;
            var shell = PowerShell.Create();
            shell.AddCommand("Import-Module").AddParameter("Name", moduleName);
            shell.Invoke();
            shell.AddCommand<ConnectAppHarborCmdlet>().AddParameter("Credential", TestCredentials.Live);
            shell.Invoke();
            return shell;
        }
    }
}
