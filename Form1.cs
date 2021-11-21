using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;
using System.IO;
namespace SPMcs
{
	public partial class SPMinstall : Form
	{
		public string deskDir = "C:\\Users\\Public\\Desktop\\";
		public string startmenu = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\";
		public SPMinstall()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//this.Hide();
			global::SPMinstaller.SPMinstaller installer = new global::SPMinstaller.SPMinstaller();
			installer.ShowDialog();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (Directory.Exists("C:\\SPM")) Directory.Delete("C:\\BPM", true);
			if (File.Exists(deskDir + "SPM.lnk")) File.Delete(deskDir + "SPM.lnk");
			if (File.Exists(startmenu+"SPM.lnk")) File.Delete(startmenu+"SPM.lnk");
			MessageBox.Show(
				"SPM is uninstalled",
				"SPM",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly);
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
