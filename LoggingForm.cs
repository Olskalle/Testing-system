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
			isFilled = !surnameBox.Text.Equals("") 
					&& !nameBox.Text.Equals("") 
					&& !groupBox.Text.Equals("");	//пустые ли ячейки
// TODO: Реализовать проверку заполнения всех полей
			if (!isFilled)
			{
				MessageBox.Show("Заполните все поля!", "Предупреждение");
			}
			else
			{
				TestForm testForm = new TestForm();
				DateTime start = DateTime.Now;
				User newUser = new User(surnameBox.Text, nameBox.Text, groupBox.Text, start);
				testForm.ShowDialog();
				this.Close();
			}
		}

        private void surnameBox_TextChanged(object sender, EventArgs e)
        {
			
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
