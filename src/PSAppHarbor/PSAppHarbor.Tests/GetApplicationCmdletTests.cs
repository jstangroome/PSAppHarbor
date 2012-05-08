using AppHarbor.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSAppHarbor.Tests
{
    [TestClass]
    public class GetApplicationCmdletTests : AppHarborModuleTests
    {
        [TestCategory("Integration")]
        [TestMethod]
        public void GetApplicationCmdlet_should_return_all_applications_for_account()
        {
            using (var shell = PowerShellWithLiveConnectedAppHarborModule())
            {
                shell.AddCommand<GetApplicationCmdlet>();
                var output = shell.Invoke();
                Assert.AreNotEqual(0, output.Count);
                Assert.IsInstanceOfType(output[0].BaseObject, typeof(Application));
            }
            
        }
    }
}
