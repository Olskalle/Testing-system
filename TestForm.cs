using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Testing_system
{
	public partial class TestForm : Form
	{
		public User currentUser;
		WholeTest test = new WholeTest();
		byte qNumber = 0;   // Question number
		bool enableBlocking = false;
		byte currentScore = 0;
		public TestForm()
		{
			InitializeComponent();
		}

		private void SetPanel(Codes.Type type)
		{
			switch (type)
			{
				case Codes.Type.SOLO:
					checkBoxList.Show();
					multiCheckBox.Hide();
					ansBox.Hide();
					break;
				case Codes.Type.MULTI:
					multiCheckBox.Show();
					checkBoxList.Hide();
					ansBox.Hide();
					break;
				case Codes.Type.OPENED:
					ansBox.Show();
					checkBoxList.Hide();
					multiCheckBox.Hide();
					break;
				default: break;
			}
		}
		private void RefreshAnswers(Codes.Type type)
		{
			if (type == Codes.Type.SOLO)
			{
				for (int i = 0; i < checkBoxList.Items.Count; i++)
				{
					checkBoxList.Items[i] = test.Pack[qNumber]
						.Answer.ElementAtOrDefault(i).Key ?? "";
					checkBoxList.SetItemChecked(i, false);
				}
			}
			else if (type == Codes.Type.MULTI)
			{
				for (int i = 0; i < multiCheckBox.Items.Count; i++)
				{
					multiCheckBox.Items[i] = test.Pack[qNumber]
						.Answer.ElementAtOrDefault(i).Key ?? "";
					multiCheckBox.SetItemChecked(i, false);
				}
			}
			else if (type == Codes.Type.OPENED)
			{
				ansBox.Text = "";
			}
		}
		private void EndTestEvent()
		{
			this.Close();
		}

		private void CompareChecked()
		{
			List<string> checkedItems = new List<string>();

			switch (test.Pack[qNumber].Type)
			{
				case Codes.Type.MULTI:
					foreach (var item in multiCheckBox.CheckedItems)
					{ checkedItems.Add(item.ToString()); }
					break;
				case Codes.Type.SOLO:
					foreach (var item in checkBoxList.CheckedItems)
					{ checkedItems.Add(item.ToString()); }
					break;
				case Codes.Type.OPENED: break;
				default: break;
			}
			if (Enumerable.SequenceEqual(test.Pack[qNumber].TrueAnswers, checkedItems))
			{
				//TODO Поправить стоимость типов заданий
				currentScore += (byte)test.Pack[qNumber].Type;
			}

			//------DEBUG------
			List<string> all = new List<string>();
			switch (test.Pack[qNumber].Type)
			{
				case Codes.Type.MULTI:
					foreach (var item in multiCheckBox.Items)
					{ all.Add(item.ToString()); }
					break;
				case Codes.Type.SOLO:
					foreach (var item in checkBoxList.Items)
					{ all.Add(item.ToString()); }
					break;
				case Codes.Type.OPENED: break;
				default: break;
			}
			string allstr = string.Join(",", all);
			string ch = string.Join(",", checkedItems);
			string allans = string.Join(",", test.Pack[qNumber].Answer.Keys);
			string tr = string.Join(",", test.Pack[qNumber].TrueAnswers);
			bool res = Enumerable.SequenceEqual(test.Pack[qNumber].TrueAnswers, checkedItems);
			Debug.WriteLine($"--Q{qNumber}---\nAll {allstr}\nChecked {ch}\nAll answers {allans}\nTrue {tr}\nComparison result {res}\n");
		}

		private void SetImage(string path)
		{
			if (File.Exists(path))
			{
				taskBox.Load(path);
			}
			else
			{
				taskBox.Image = Properties.Resources.Missing_Image;
				taskBox.Refresh();
			}
		}

		private void TestForm_Load(object sender, EventArgs e)
		{

			test.GeneratePack();

			qLabel.Text = $"Вопрос {qNumber + 1}/{test.Pack.Count}";
			//taskBox.Load(test.Pack[qNumber].Image);
			SetImage(test.Pack[qNumber].Image);
			SetPanel(test.Pack[qNumber].Type);
			RefreshAnswers(test.Pack[qNumber].Type);
		}
		
		private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//Запись времени прохождения, полученных баллов и добавление информации пользователя в файл с последующим выводом результатов тестирования
			currentUser.Finish = DateTime.Now; 
			currentUser.Score = currentScore; 										
			Journal addJournal = new Journal();
			addJournal.XmlAdd(currentUser); 
			string elapsed = currentUser.Elapsed.ToString().Trim();
			elapsed = elapsed.Substring(0, elapsed.LastIndexOf('.'));
			MessageBox.Show("Вы прошли тест\nВаш результат:\t" + currentUser.Score + "\nВаша оценка:\t" + currentUser.Mark + "\nВремя прохождения:\t" + elapsed,"Поздравляем");
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			//Следующий вопрос,
			if (qNumber < test.Pack.Count -	1)
			{
				qNumber++;
				qLabel.Text = $"Вопрос {qNumber + 1}/{test.Pack.Count}";

				//---------------Удалить перед релизом----
				qLabel.Text += $"\n{currentScore}";
				//----------------------------------------

				//taskBox.Load(test.Pack[qNumber].Image);
				SetImage(test.Pack[qNumber].Image);
				SetPanel(test.Pack[qNumber].Type);
				//TODO Обработка ответов: запись, сравнение
				CompareChecked();
				RefreshAnswers(test.Pack[qNumber].Type);
			}
			else
			{       //Окончание теста, попытка нажатия кнопки далее при достижении конца теста
				EndTestEvent();
			}
		}

		private void endButton_Click(object sender, EventArgs e)
		{
			EndTestEvent();
		}

		private void checkBoxList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			for (int i = 0; i < checkBoxList.Items.Count; i++)
			{
				if (i != e.Index)
				{ checkBoxList.SetItemChecked(i, false); }
			}
		}

		private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//После прохождения теста или при нажатии на кнопку "Завершить"
			DialogResult dialogResult =
				MessageBox.Show("Завершить тест?", "Предупреждение", MessageBoxButtons.YesNo);
			e.Cancel = (dialogResult == DialogResult.No);
		}
	}
}
