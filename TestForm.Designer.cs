
namespace Testing_system
{
	partial class TestForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.checkBoxList = new System.Windows.Forms.CheckedListBox();
			this.ansBox = new System.Windows.Forms.TextBox();
			this.taskBox = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.qLabel = new System.Windows.Forms.Label();
			this.endButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.taskBox)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.checkBoxList);
			this.splitContainer1.Panel1.Controls.Add(this.ansBox);
			this.splitContainer1.Panel1.Controls.Add(this.taskBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.qLabel);
			this.splitContainer1.Panel2.Controls.Add(this.endButton);
			this.splitContainer1.Panel2.Controls.Add(this.nextButton);
			this.splitContainer1.Size = new System.Drawing.Size(848, 525);
			this.splitContainer1.SplitterDistance = 433;
			this.splitContainer1.TabIndex = 0;
			// 
			// checkBoxList
			// 
			this.checkBoxList.FormattingEnabled = true;
			this.checkBoxList.Items.AddRange(new object[] {
            "Ответ 1",
            "Ответ 2",
            "Ответ 3",
            "Ответ 4"});
			this.checkBoxList.Location = new System.Drawing.Point(16, 312);
			this.checkBoxList.Name = "checkBoxList";
			this.checkBoxList.Size = new System.Drawing.Size(818, 109);
			this.checkBoxList.TabIndex = 3;
			this.checkBoxList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkBoxList_ItemCheck);
			// 
			// ansBox
			// 
			this.ansBox.Location = new System.Drawing.Point(11, 312);
			this.ansBox.MaxLength = 1024;
			this.ansBox.Multiline = true;
			this.ansBox.Name = "ansBox";
			this.ansBox.Size = new System.Drawing.Size(823, 73);
			this.ansBox.TabIndex = 2;
			this.ansBox.Text = "Ответ";
			// 
			// taskBox
			// 
			this.taskBox.Location = new System.Drawing.Point(11, 11);
			this.taskBox.Name = "taskBox";
			this.taskBox.Size = new System.Drawing.Size(824, 286);
			this.taskBox.TabIndex = 1;
			this.taskBox.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(520, 26);
			this.label2.TabIndex = 3;
			this.label2.Text = "При нажатии кнопки \"Далее\", когда не выбран ни один вариант ответа, или в поле не" +
    " вписан ответ,\r\nвопрос автоматически засчитывается как неверный. Назад вернуться" +
    " нельзя.\r\n";
			// 
			// qLabel
			// 
			this.qLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.qLabel.AutoSize = true;
			this.qLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.qLabel.Location = new System.Drawing.Point(11, 17);
			this.qLabel.Name = "qLabel";
			this.qLabel.Size = new System.Drawing.Size(146, 25);
			this.qLabel.TabIndex = 2;
			this.qLabel.Text = "Вопрос Х/20";
			this.qLabel.TextChanged += new System.EventHandler(this.qLabel_TextChanged);
			// 
			// endButton
			// 
			this.endButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.endButton.Location = new System.Drawing.Point(704, 17);
			this.endButton.Name = "endButton";
			this.endButton.Size = new System.Drawing.Size(131, 52);
			this.endButton.TabIndex = 1;
			this.endButton.Text = "Завершить";
			this.endButton.UseVisualStyleBackColor = true;
			this.endButton.Click += new System.EventHandler(this.endButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(567, 17);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(131, 52);
			this.nextButton.TabIndex = 0;
			this.nextButton.Text = "Далее";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(848, 525);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "TestForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Тестирование";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestForm_FormClosed);
			this.Load += new System.EventHandler(this.TestForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.taskBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label qLabel;
		private System.Windows.Forms.Button endButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.PictureBox taskBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox checkBoxList;
		private System.Windows.Forms.TextBox ansBox;
	}
}

