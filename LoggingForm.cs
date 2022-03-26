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
	public partial class LoggingForm : Form
	{
		public LoggingForm()
		{
			InitializeComponent();
		}

		private void LoggingForm_Load(object sender, EventArgs e)
		{

		}

		private void continueButton_Click(object sender, EventArgs e)
		{
			bool isFilled = false;
			isFilled = nameBox.MaskCompleted & surnameBox.MaskCompleted & groupNameBox.MaskCompleted;
// TODO: Реализовать проверку заполнения всех полей
			if (isFilled)
			{
				MessageBox.Show("Заполните все поля!", "Предупреждение");
			}
			else
			{
				TestForm testForm = new TestForm();
				testForm.ShowDialog();
				this.Close();
			}
		}
	}
}
