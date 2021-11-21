using System;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using Octokit;
using Octokit.Reactive;
// using IWshRuntimeLibrary;
//using System.IO.Compression;
namespace SPMinstaller
{
	

	public partial class SPMinstaller : Form
	{
		public bool desktopshortcut = true;
		public bool startmenushorcut = true;
		public bool python = true;
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

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			// Set the branch
			branch = "dev";
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			//Set the branch
			branch = "ptb";
		}

		private void label2_Click(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{

			if (System.IO.File.Exists("C:\\temp\\SPM.zip")) System.IO.File.Delete("C:\\temp\\SPM.zip");
			if (Directory.Exists("C:\\SPM")) Directory.Delete("C:\\SPM", true);
			// SET BPM URL
			var client = new GitHubClient(new ProductHeaderValue("bultek"));
			var release = client.Repository.Release.GetLatest("bultek", "sharppackagemanager");
			var tag = release[0].TagName;

				
			//Console.WriteLine(release);
				
				
				
			string url = "";
			//DOWNLOAD BPM
			using (WebClient spmdl = new WebClient())
			{


				spmdl.DownloadFile(url, "C:\\temp\\spm.zip");

					// Param1 = Link of file
					// Param2 = Path to save

			}
			// Extract the archive

				// Post-Installation things, add shortcuts
			if (desktopshortcut == true) System.IO.File.Copy("C:\\BPM\\BPM.lnk", deskDir+"BPM.lnk");
			if (startmenushorcut == true) System.IO.File.Copy("C:\\BPM\\BPM.lnk", startmenu+"BPM.lnk");

			System.IO.File.Delete("C:\\temp\\BPM.zip");
			MessageBox.Show(
			"BPM is installed",
			"BPM",
			MessageBoxButtons.OK,
			MessageBoxIcon.Information,
			MessageBoxDefaultButton.Button1,
			MessageBoxOptions.DefaultDesktopOnly);

			
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			//changing installiation setting for python
			if (python == true) python = false;
			else if (python == false) python = true;
				
			}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
