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
		byte currentScore = 0;
		public TestForm()
		{
			InitializeComponent();
		}

		private string MaskString(string s)
		{
			return string.Join(" ",
						s.ToLower()
						 .Replace('-', ' ')
						 .Replace('\\', '/')
						 .Replace('.', ',')
						 .Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
		}
		private List<string> MaskString(List<string> s)
		{
			List<string> maskedList = s;
			maskedList.ForEach(e => e = MaskString(e));
			return maskedList;
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
					checkBoxList.Refresh();
				}
			}
			else if (type == Codes.Type.MULTI)
			{
				for (int i = 0; i < multiCheckBox.Items.Count; i++)
				{
					multiCheckBox.Items[i] = test.Pack[qNumber]
						.Answer.ElementAtOrDefault(i).Key ?? "";
					multiCheckBox.SetItemChecked(i, false);
					multiCheckBox.Refresh();
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

					if (Enumerable.SequenceEqual(test.Pack[qNumber].TrueAnswers, checkedItems))
					{ currentScore += (byte)Codes.Price.MULTI; }
					break;
				case Codes.Type.SOLO:

					foreach (var item in checkBoxList.CheckedItems)
					{ checkedItems.Add(item.ToString()); }

					if (Enumerable.SequenceEqual(test.Pack[qNumber].TrueAnswers, checkedItems))
					{ currentScore += (byte)Codes.Price.SOLO; }
					break;
				case Codes.Type.OPENED:
					string text = MaskString(ansBox.Text);
					if (MaskString(test.Pack[qNumber].TrueAnswers).Exists(t => t.Equals(text)))
					{ currentScore += (byte)Codes.Price.OPENED; }
					/*
					 * В XML с ответами добавить другие возможные распространенные формулировки ответа
					 * Сравнивать в нижнем регистре
					 * Тире заменить на пробелы, убрать лишние пробелы
					 * 
					 * Ответ правильный, если:
					 *			Введенная пользователем строка с примененной маской
					 *			совпадает с одним из вариантов из XML, тоже с маской
					 */
					break;
				default: break;
			}


			//------DEBUG------
			if (test.Pack[qNumber].Type != Codes.Type.OPENED)
			{
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
			else
			{
				string allans = string.Join(",", test.Pack[qNumber].Answer.Keys);
				string tr = string.Join(",", test.Pack[qNumber].TrueAnswers);
				string t = MaskString(ansBox.Text);
				Debug.WriteLine($"--Q{qNumber}---\nAnswer {ansBox.Text}\nAll answers {allans}\nTrue {tr}\n" +
					$"Comparison result {MaskString(test.Pack[qNumber].TrueAnswers).Exists(r => r.Equals(t))}\n");
				Debug.WriteLine($"{t}");
				List<string> bebei = MaskString(test.Pack[qNumber].TrueAnswers);
				bebei.ForEach(e => Debug.WriteLine($"-{e}, {e.Equals(t)}"));
			}
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
			//----------DEBUG---------------------
			//MessageBox.Show($"{string.Join(",", test.Pack[qNumber + 1].TrueAnswers)}");
			//------------------------------------

			qLabel.Text = $"Вопрос {qNumber + 1}/{test.Pack.Count}";
			SetImage(test.Pack[qNumber].Image);
			SetPanel(test.Pack[qNumber].Type);
			RefreshAnswers(test.Pack[qNumber].Type);
			//CompareChecked();
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

			if (qNumber < test.Pack.Count -	1)
			{
				CompareChecked();
				qNumber++;
				RefreshAnswers(test.Pack[qNumber].Type);
				SetImage(test.Pack[qNumber].Image);
				SetPanel(test.Pack[qNumber].Type);

				//----------DEBUG---------------------
				//MessageBox.Show($"{string.Join(",", test.Pack[qNumber + 1].TrueAnswers)}");
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
				string allans = string.Join(",", test.Pack[qNumber].TrueAnswers);
				Debug.WriteLine($"--Q{qNumber}---\nAll {allstr}\nAll answers {allans}\n");

				qLabel.Text = $"Вопрос {qNumber + 1}/{test.Pack.Count}";

				//---------------Удалить перед релизом----
				qLabel.Text += $"\n{test.Pack[qNumber].Code}";
				//----------------------------------------
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
