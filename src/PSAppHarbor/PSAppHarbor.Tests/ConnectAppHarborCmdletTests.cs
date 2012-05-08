using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSAppHarbor.Tests
{
    [TestClass]
    public class ConnectAppHarborCmdletTests : AppHarborModuleTests
    {

        [TestCategory("Integration")]
        [TestMethod]
        public void ConnectAppHarbor_should_write_an_error_if_credentials_are_wrong()
        {
            using (var shell = PowerShellWithAppHarborModule())
            {
                shell.AddCommand<ConnectAppHarborCmdlet>().AddParameter("Credential", TestCredentials.Invalid);
                shell.Invoke();
                Assert.AreNotEqual(0, shell.Streams.Error.Count);
            }
        }

        [TestCategory("Integration")]
        [TestMethod]
        public void ConnectAppHarbor_should_return_silently_on_successful_authentication()
        {
            using (var shell = PowerShellWithAppHarborModule())
            {
                shell.AddCommand<ConnectAppHarborCmdlet>().AddParameter("Credential", TestCredentials.Live);
                var output = shell.Invoke();
                Assert.AreEqual(0, output.Count);
                Assert.AreEqual(0, shell.Streams.Error.Count);
            }
        }
    }
}
