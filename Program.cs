using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPMinstaller;
using System.Security.Principal;

namespace SPMinstaller
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			if (args.Length == 0)
			{
                if (!IsAdministrator())
                {
                    MessageBox.Show("You must run this program as administrator.");
                    System.Environment.Exit(1);
                }
                {
                    MessageBox.Show("You must run this program as administrator.", "SPM Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(1);
                }
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new SPMinstaller());
			}
			else if (args.Length == 1 && args[0]=="-q")
            {
				if (IsAdministrator())
				{
					SPMinstaller.desktopshortcut = true;
					SPMinstaller.startmenushorcut = true;
					SPMinstaller.Install();
				}
                else MessageBox.Show("You need to run this program as administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

		}
		public static bool IsAdministrator()
		{
			return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
					  .IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}
