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
	public partial class TestForm : Form
	{
		WholeTest test = new WholeTest();
		byte qNumber = 0;   // Question number
		bool enableBlocking = false;
		public TestForm()
		{
			InitializeComponent();
		}

//TODO Блокирование кол-ва выбранных чекбоксов
		private void TogglePanelBlocking(bool res)
		{
			enableBlocking = res;
		}
		private void SetPanel(Codes.Type type)
		{
			switch (type)
			{
				case Codes.Type.SOLO:
					checkBoxList.Show();
					ansBox.Hide();
					TogglePanelBlocking(true);
					break;
				case Codes.Type.MULTI:
					checkBoxList.Show();
					ansBox.Hide();
					TogglePanelBlocking(false);
					break;
				case Codes.Type.OPENED:
					ansBox.Show();
					checkBoxList.Hide();
					TogglePanelBlocking(false);
					break;
				default: break;
			}
		}
		private void RefreshAnswers(Codes.Type type)
		{
			if (type == Codes.Type.SOLO || type == Codes.Type.MULTI)
			{
				for (int i = 0; i < checkBoxList.Items.Count; i++)
				{
					checkBoxList.Items[i] = test.Pack[qNumber]
						.Answer.ElementAtOrDefault(i).Key ?? "";
					checkBoxList.SetItemChecked(i, false);
				}
			}
			else if (type == Codes.Type.OPENED)
			{
				ansBox.Text = "";
			}
		}
		private void EndTestEvent()
		{
			DialogResult dialogResult =
				MessageBox.Show("Завершить тест?", "Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.Close();
			}
		}
		private void TestForm_Load(object sender, EventArgs e)
		{

			test.GeneratePack();

			qLabel.Text = $"Вопрос {qNumber + 1}/{test.Pack.Count}";
			taskBox.Load(test.Pack[qNumber].Image);
			SetPanel(test.Pack[qNumber].Type);
			RefreshAnswers(test.Pack[qNumber].Type);
		}

		private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//TODO Сформировать объект User

			//TODO Добавить запись в журнал

			//TODO Вывести информацию о тесте
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			if (qNumber < test.Pack.Count - 1)
			{
				qNumber++;
				qLabel.Text = $"Вопрос {qNumber + 1}/{test.Pack.Count}";

				taskBox.Load(test.Pack[qNumber].Image);
				SetPanel(test.Pack[qNumber].Type);
				//TODO Обработка ответов: запись, сравнение
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

		private void qLabel_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void checkBoxList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (enableBlocking)
			{
				for (int i = 0; i < checkBoxList.Items.Count; i++)
				{
					if (i != e.Index)
					{ checkBoxList.SetItemChecked(i, false); }
				}
			}
		}
	}
}
