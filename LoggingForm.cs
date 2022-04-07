using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Testing_system
{
	public partial class LoggingForm : Form 
	{
		public User GetUser { get; set; }
		private bool CompareGroup(string group)//Метод проверки введённой группы на правильность
		{
			string pattern = @"^([а-я,А-Я]+)-([0-9]+)$"; // Маска для проверки ввода группы
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			if (Regex.IsMatch(group, pattern, RegexOptions.IgnoreCase)) //Проверка ввода группы на соответствие маске
			{ return true; }
			else
			{ return false; }
		}
		public LoggingForm()
		{
			InitializeComponent();
		}
		public static string ToUpperFirstLetter(string source) 
		{
			//Метод замены первой буквы на заглавную
			if (string.IsNullOrEmpty(source)) 
				return string.Empty;
			char[] letters = source.ToCharArray(); 
			letters[0] = char.ToUpper(letters[0]); 
			return new string(letters); 
		}
		private void LoggingForm_Load(object sender, EventArgs e)
		{

		}

		private void continueButton_Click(object sender, EventArgs e)
		{
			//Провервка введёных данных и создание объекта класса пользователя
			bool isFilled = false;
			isFilled = !surnameBox.Text.Equals("")
					&& !nameBox.Text.Equals("")
					&& !groupBox.Text.Equals("");   //пустые ли ячейки
													

			if (!CompareGroup(groupBox.Text)) 
			{
				MessageBox.Show("Неверно введена группа", "Предупреждение"); //Если группа введена неверно
			}
			else
			{
				if (!isFilled)
				{
					MessageBox.Show("Заполните все поля!", "Предупреждение"); //Если не заполненны все поля
				}
				else
				{
					string surname = ToUpperFirstLetter(surnameBox.Text);
					string name = ToUpperFirstLetter(nameBox.Text);
					string group = groupBox.Text.ToUpper();
					TestForm testForm = new TestForm();
					DateTime start = DateTime.Now;
					testForm.currentUser = new User(surname, name,group, start); //Если все поля заполнены верно, то создаётся новый пользователь
					testForm.ShowDialog();
					this.Close();
				}
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


		private void LetterOnly_KeyPress(object sender, KeyPressEventArgs e) 
		{
			//Запрет на ввод символов, отличных от букв
			if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)8) return;
			else
				e.Handled = true;
		}

		private void groupBox_KeyPress(object sender, KeyPressEventArgs e) 
		{
			//Запрет на ввод ввод символов, отличных от букв, цифр и знака дефис
			if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)8 || Char.IsDigit(e.KeyChar) || e.KeyChar == '-') return;
			else
				e.Handled = true;
		}
	}
}
