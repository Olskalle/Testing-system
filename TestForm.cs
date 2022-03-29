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
		byte qNumber = 0;	// Question number
		public TestForm()
		{
			InitializeComponent();
		}

		private void TestForm_Load(object sender, EventArgs e)
		{
			test.GeneratePack();
			/*
			 *	В зависимости от типа вопроса гененируем интерфейс
			 *	OPENED --> Показываем панель с полем ввода
			 *	SOLO, MULTI --> Показываем панель с чекбоксами
			 *	
			 *	В случае с SOLO нужна функция DeselectOther()
			 *	запрещающая выделять больше одного чекбокса
			 *	
			 *	Варианты:
			 *			* динамически создаем чекбоксы в панели и заполняем их
			 *			* берем 4(условно) постоянных чекбокса и меняем им атрибуты
			 */

		}

		private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
		{

		}
	}
}
