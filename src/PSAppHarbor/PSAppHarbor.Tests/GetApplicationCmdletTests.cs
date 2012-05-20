using System.Linq;
using AppHarbor.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

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

        [TestMethod]
        public void GetApplicationCmdlet_should_return_application_matching_ApplicationID_parameter()
        {
            using (var shell = PowerShellWithAppHarborModule())
            using (new SubstituteApiScope())
            {
                ApiProvider.Instance.GetApi().GetApplication("testAppID")
                    .Returns(new Application { Slug = "testAppID" });
                shell.AddCommand<GetApplicationCmdlet>().AddParameter("ApplicationID", "testAppID");

                var output = (Application)shell.Invoke().Single().BaseObject;

                Assert.AreEqual("testAppID", output.Slug);
            }
        }

        [TestMethod]
        public void GetApplicationCmdlet_should_return_application_matching_piped_object_with_Slug_property()
        {
            using (var shell = PowerShellWithAppHarborModule())
            using (new SubstituteApiScope())
            {
                ApiProvider.Instance.GetApi().GetApplication("testAppID")
                    .Returns(new Application { Slug = "testAppID" });
                shell.AddScript(@" New-Object -TypeName PSObject -Property @{ Slug='testAppID' } ");
                shell.AddCommand<GetApplicationCmdlet>();

                var output = (Application)shell.Invoke().Single().BaseObject;

                Assert.AreEqual("testAppID", output.Slug);
            }
        }
    }
}
