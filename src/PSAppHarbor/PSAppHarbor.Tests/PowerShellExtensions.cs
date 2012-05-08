using System.Management.Automation;

namespace PSAppHarbor.Tests
{
    public static class PowerShellExtensions
    {
        public static PowerShell AddCommand<T>(this PowerShell shell)
        {
            var commandType = typeof (T);
            var cmdletAttribute = (CmdletAttribute)commandType.GetCustomAttributes(typeof (CmdletAttribute), false)[0];
            return shell.AddCommand(string.Format("{0}-{1}", cmdletAttribute.VerbName, cmdletAttribute.NounName));
        }
    }
}
