using System.Management.Automation;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSAppHarbor.Tests
{
    [TestClass]
    public class ConnectAppHarborCmdletTests
    {
        public PowerShell PowerShellWithAppHarborModule()
        {
            var moduleName = typeof(ConnectAppHarborCmdlet).Assembly.Location;
            var shell = PowerShell.Create();
            shell.AddCommand("Import-Module").AddParameter("Name", moduleName);
            shell.Invoke();
            return shell;
        }

        public PSCredential NewCredential(string username, string password)
        {
            var securePassword = new SecureString();
            foreach (var c in password.ToCharArray())
            {
                securePassword.AppendChar(c);
            }
            return new PSCredential(username, securePassword);
        }

        [TestCategory("Integration")]
        [TestMethod]
        public void ConnectAppHarbor_should_write_an_error_if_credentials_are_wrong()
        {
            using (var shell = PowerShellWithAppHarborModule())
            {
                shell.AddCommand("Connect-AppHarbor").AddParameter("Credential", NewCredential("notauser", "notthepassword"));
                shell.Invoke();
                Assert.AreNotEqual(0, shell.Streams.Error.Count);
            }
        }
    }
}
