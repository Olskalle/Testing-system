﻿using System;
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
		//TODO Смена панелей
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

		private void RefreshAnswers()
		{
			for (int i = 0; i < checkBoxList.Items.Count; i++)
			{
				//checkBoxList.Items[i] = test.Pack[i].Answer;
			}
		}

		private void TestForm_Load(object sender, EventArgs e)
		{
			test.GeneratePack();
			/*
			 *	В зависимости от типа вопроса гененируем интерфейс \
			 *	OPENED --> Показываем панель с полем ввода			|---SetPanel()
			 *	SOLO, MULTI --> Показываем панель с чекбоксами	   /
			 *	
			 *	В случае с SOLO нужна функция DeselectOther() <--- TogglePanelBlocking()
			 *	запрещающая выделять больше одного чекбокса
			 *	
			 *	Варианты:
			 *			* динамически создаем чекбоксы в панели и заполняем их
			 *			* берем 4(условно) постоянных чекбокса и меняем им атрибуты <----Выбрал этот
			 */
			taskBox.Load(test.Pack[qNumber].Image);
			SetPanel(test.Pack[qNumber].Type);
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
			}
			else
			{		//Окончание теста, попытка нажатия кнопки далее при достижении конца теста
				DialogResult dialogResult = 
					MessageBox.Show("Завершить тест?", "Предупреждение", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.Close();
				}
			}
		}

		private void endButton_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Завершить тест?", "Предупреждение", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.Close();
			}
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
