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
	public partial class LogForm : Form
	{
		public LogForm()
		{
			InitializeComponent();
		}

		private void LogForm_Load(object sender, EventArgs e)
		{
			//Заполнение таблицы журнала тестирования
			dataGridView1.AllowUserToAddRows = false; //Запрещаем пользователю самостоятельно добавлять строки в журнал тестирования
			dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //Центрирование теста
			List<User> users = new List<User>();
			Journal parsejournal = new Journal();
			users = parsejournal.ParseXML(); //Получаем список пользователей прошедших тест из файла
			foreach (User user in users)
			{
				dataGridView1.Rows.Add(user.Group, user.Surname, user.Name, user.Score, user.Mark, user.Start, user.Elapsed); //Заполняем таблицу журнала тестирования
			}
		}
	}
}
