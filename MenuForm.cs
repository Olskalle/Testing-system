using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_system
{
	public partial class MenuForm : Form
	{
		public bool IsTestOpened { get; set; } = false;
		public bool IsLogOpened { get; set; } = false;
		public bool IsInfoOpened { get; set; } = false;
		public MenuForm()
		{
			InitializeComponent();
		}

		private void startTestButton_Click(object sender, EventArgs e)
		{
			LoggingForm loggingForm = new LoggingForm();
			loggingForm.ShowDialog();
		}

		private void logButton_Click(object sender, EventArgs e)
		{
			LogForm logForm = new LogForm();
			logForm.ShowDialog();
			//envoeoe	
		}
		private void infoButton_Click(object sender, EventArgs e)
		{
			InfoForm infoForm = new InfoForm();
			infoForm.ShowDialog();
		}
		private void exitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MenuForm_Load(object sender, EventArgs e)
		{

		}
	}
}
