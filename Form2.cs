using System;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using IWshRuntimeLibrary;
namespace SPMinstaller
{
	

	public partial class SPMinstaller : Form
	{
		public static bool desktopshortcut = true;
		public static bool startmenushorcut = true;
		private static bool dotnetruntime = true;
		private static bool ptb = false;
		private static string branch;
		private static readonly string deskDir = "C:\\Users\\Public\\Desktop\\";
		private static readonly string startmenu = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\";
		public SPMinstaller()
		{
			InitializeComponent();
			
		}

		private void Form2_Load(object sender, EventArgs e)
		{
				
		}
		private void label2_Click(object sender, EventArgs e)
		{
			
		}

		public static void Install()
        {
			if (System.IO.File.Exists("C:\\temp\\SPM.zip")) System.IO.File.Delete("C:\\temp\\SPM.zip");
			if (Directory.Exists("C:\\SPM")) Directory.Delete("C:\\SPM", true);
			if (System.IO.File.Exists("C:\\temp\\tag.spmvi")) System.IO.File.Delete("C:\\temp\\tag.spmvi");
			if (!System.IO.Directory.Exists("C:\\temp")) System.IO.Directory.CreateDirectory("C:\\temp");
			// SET SPM URL
			if (ptb) branch = "ptb";
			else branch = "master";
			string url = "http://repo.bultek.com.ua/SPM-BINARY/SPM-"+branch+".zip";
			//DOWNLOAD SPM
			using (WebClient spmdl = new WebClient()) spmdl.DownloadFile(url, "C:\\temp\\spm.zip");
			// Extract the archive
			string zipPath = "C:\\temp\\spm.zip";
			string extractPath = "C:\\";
			ZipFile.ExtractToDirectory(zipPath, extractPath);
			// Main Installation Scripts
			// Post-Installation things, add shortcuts
			if (System.IO.File.Exists(deskDir + "SPM.lnk")) System.IO.File.Delete(deskDir + "SPM.lnk");
			if (System.IO.File.Exists(deskDir + "SPM.lnk")) System.IO.File.Delete(deskDir + "SPM.lnk");
            if (desktopshortcut == true && !System.IO.File.Exists(deskDir + "SPM.lnk")) CreateShortcut(deskDir + "SPM.lnk", "C:\\SPM\\SharpPackageManager.exe");
            if (startmenushorcut == true && !System.IO.File.Exists(deskDir + "SPM.lnk")) CreateShortcut(startmenu + "SPM.lnk", "C:\\SPM\\SharpPackageManager.exe");

			System.IO.File.Delete("C:\\temp\\SPM.zip");
			//Install .NET 6.0 runtime
			if (dotnetruntime)
			{
				if (System.IO.File.Exists("C:\\temp\\dotnetruntime.exe")) System.IO.File.Delete("C:\\temp\\dotnetruntime.exe");
				using (WebClient dotnetdl = new WebClient())
				{


					dotnetdl.DownloadFile("https://download.visualstudio.microsoft.com/download/pr/df4372ca-82c8-4bfa-acf9-c49e27279e7e/6bddefd26964017ff520dc1443029e04/dotnet-runtime-6.0.1-win-x64.exe", "C:\\temp\\dotnetruntime.exe");

					// Param1 = Link of file
					// Param2 = Path to save

				}
				Process PackageStartInfo = new Process();
				PackageStartInfo.StartInfo.FileName = "C:\\temp\\dotnetruntime.exe";
				PackageStartInfo.StartInfo.UseShellExecute = true;
				PackageStartInfo.StartInfo.Verb = "runas";
				PackageStartInfo.StartInfo.Arguments = "/install /quiet /norestart";
				PackageStartInfo.Start();
				PackageStartInfo.WaitForExit();
			}
		}

        public static void CreateShortcut(string shortcutPath, string targetPath)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = targetPath;
            shortcut.IconLocation = @"C:\SPM\icon.ico";
            shortcut.Description = "Sharp Package Manager";
            shortcut.WorkingDirectory = @"C:\SPM";
            shortcut.Save();
        }
        private void button1_Click(object sender, EventArgs e)
		{
			Install();
			MessageBox.Show(
			"SPM is installed",
			"SPM",
			MessageBoxButtons.OK,
			MessageBoxIcon.Information,
			MessageBoxDefaultButton.Button1,
			MessageBoxOptions.DefaultDesktopOnly);

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (desktopshortcut == false) desktopshortcut = true;
			else if (desktopshortcut == true) desktopshortcut = false;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (startmenushorcut==true) startmenushorcut= false;
			else if (startmenushorcut==false) startmenushorcut= true;
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void remove_Click(object sender, EventArgs e)
        {
			if (Directory.Exists("C:\\SPM")) Directory.Delete("C:\\SPM", true);
			if (System.IO.File.Exists(deskDir + "SPM.lnk")) System.IO.File.Delete(deskDir + "SPM.lnk");
			if (System.IO.File.Exists(startmenu + "SPM.lnk")) System.IO.File.Delete(startmenu + "SPM.lnk");
			MessageBox.Show(
				"SPM is uninstalled",
				"SPM",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly);
		}

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
			if (dotnetruntime) dotnetruntime = false;
			else dotnetruntime = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
			if (ptb) ptb = false;
			else ptb = true;
		}
    }
    }
