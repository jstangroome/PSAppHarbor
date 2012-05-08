using System.Management.Automation;
using System.Security;

namespace PSAppHarbor.Tests
{
    static partial class TestCredentials
    {
        private static SecureString ConvertToSecureString(string plainText)
        {
            var secure = new SecureString();
            foreach (var c in plainText.ToCharArray())
            {
                secure.AppendChar(c);
            }
            return secure;
        }

        public static PSCredential Invalid
        {
            get
            {
                return new PSCredential("notauser", ConvertToSecureString("notthepassword"));
            }
        }

        public static PSCredential Live
        {
            get
            {
                return new PSCredential(LiveUserName, ConvertToSecureString(LivePassword));
            }
        }

    }
}
