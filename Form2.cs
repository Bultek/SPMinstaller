using System;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
// using IWshRuntimeLibrary;
//using System.IO.Compression;
namespace SPMinstaller
{
	

	public partial class SPMinstaller : Form
	{
		public bool desktopshortcut = true;
		public bool startmenushorcut = true;
		public bool dotnetruntime = true;
		public string branch;
		public string deskDir = "C:\\Users\\Public\\Desktop\\";
		public string startmenu = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\";
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

		private void button1_Click(object sender, EventArgs e)
		{

			if (System.IO.File.Exists("C:\\temp\\SPM.zip")) System.IO.File.Delete("C:\\temp\\SPM.zip");
			if (Directory.Exists("C:\\SPM")) Directory.Delete("C:\\SPM", true);
			if (System.IO.File.Exists("C:\\temp\\tag.spmvi")) System.IO.File.Delete("C:\\temp\\tag.spmvi");
			if (!System.IO.Directory.Exists("C:\\temp")) System.IO.Directory.CreateDirectory("C:\\temp");
			// SET BPM URL
			using (WebClient tagdl = new WebClient())
			{
				tagdl.DownloadFile("https://raw.githubusercontent.com/Bultek/SharpPackageManager/versioncontrol/ptbtag.spmvi", "C:\\temp\\tag.spmvi");
				// Param1 = Link of file
				// Param2 = Path to save
			}

			StreamReader tagreader = new StreamReader("C:\\temp\\tag.spmvi");
			Tag = tagreader.ReadLine();
			string url = "https://github.com/Bultek/SharpPackageManager/releases/download/"+Tag+"/SPM.zip";
			//DOWNLOAD BPM
			using (WebClient spmdl = new WebClient())
			{


				spmdl.DownloadFile(url, "C:\\temp\\spm.zip");

					// Param1 = Link of file
					// Param2 = Path to save

			}
			// Extract the archive
			string zipPath = "C:\\temp\\spm.zip";
			string extractPath = "C:\\";
			ZipFile.ExtractToDirectory(zipPath, extractPath);
			// Main Installation Scripts
			//Directory.Move(extractPath + "SharpPackageManager-" + Tag, "C:\\SPM");
			// Post-Installation things, add shortcuts
			if (System.IO.File.Exists(deskDir + "SPM.lnk")) System.IO.File.Delete(deskDir + "SPM.lnk");
			if (System.IO.File.Exists(deskDir + "SPM.lnk")) System.IO.File.Delete(deskDir + "SPM.lnk");
			if (desktopshortcut == true && !System.IO.File.Exists(deskDir + "SPM.lnk")) System.IO.File.Copy("C:\\SPM\\SPM.lnk", deskDir+"SPM.lnk");
			if (startmenushorcut == true && !System.IO.File.Exists(deskDir + "SPM.lnk")) System.IO.File.Copy("C:\\SPM\\SPM.lnk", startmenu+"SPM.lnk");

			System.IO.File.Delete("C:\\temp\\SPM.zip");
			//Install .NET 6.0 runtime
			if (dotnetruntime)
			{
				if (System.IO.File.Exists("C:\\temp\\dotnetruntime.exe")) System.IO.File.Delete("C:\\temp\\dotnetruntime.exe");
				using (WebClient dotnetdl = new WebClient())
				{


					dotnetdl.DownloadFile("https://download.visualstudio.microsoft.com/download/pr/3223fa10-441d-406b-af2e-94874ce38199/09347f9b4aea0ab34d6944b6b78fa29d/aspnetcore-runtime-6.0.0-win-x64.exe", "C:\\temp\\dotnetruntime.exe");

					// Param1 = Link of file
					// Param2 = Path to save

				}
				Process PackageStartInfo = new Process();
				//PackageStartInfo.StartInfo.FileName = "C:\\temp\\dotnetruntime.exe";
				PackageStartInfo.StartInfo.UseShellExecute = true;
				PackageStartInfo.StartInfo.Verb = "runas";
				PackageStartInfo.StartInfo.Arguments = "/install /quiet /norestart";
				PackageStartInfo.Start();
				PackageStartInfo.WaitForExit();
				MessageBox.Show(
				"SPM is installed",
				"SPM",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly);
			}

			
		}
		

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			//Set the branch (there is no stable version right now, you will download public test builds)
			branch = "ptb";
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
			if (File.Exists(deskDir + "SPM.lnk")) File.Delete(deskDir + "SPM.lnk");
			if (File.Exists(startmenu + "SPM.lnk")) File.Delete(startmenu + "SPM.lnk");
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
    }
    }
