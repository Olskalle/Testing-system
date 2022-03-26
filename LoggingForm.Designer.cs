
namespace Testing_system
{
	partial class LoggingForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.continueButton = new System.Windows.Forms.Button();
			this.nameBox = new System.Windows.Forms.MaskedTextBox();
			this.surnameBox = new System.Windows.Forms.MaskedTextBox();
			this.groupNameBox = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Фамилия";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Имя";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Группа";
			// 
			// continueButton
			// 
			this.continueButton.Location = new System.Drawing.Point(249, 160);
			this.continueButton.Name = "continueButton";
			this.continueButton.Size = new System.Drawing.Size(94, 23);
			this.continueButton.TabIndex = 6;
			this.continueButton.Text = "Продолжить";
			this.continueButton.UseVisualStyleBackColor = true;
			this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
			// 
			// nameBox
			// 
			this.nameBox.Location = new System.Drawing.Point(12, 73);
			this.nameBox.Mask = ">L<L??????????????????????????????????????????????";
			this.nameBox.Name = "nameBox";
			this.nameBox.PromptChar = ' ';
			this.nameBox.Size = new System.Drawing.Size(266, 20);
			this.nameBox.TabIndex = 7;
			// 
			// surnameBox
			// 
			this.surnameBox.Location = new System.Drawing.Point(12, 28);
			this.surnameBox.Mask = ">L<L??????????????????????????????????????????????";
			this.surnameBox.Name = "surnameBox";
			this.surnameBox.PromptChar = ' ';
			this.surnameBox.Size = new System.Drawing.Size(266, 20);
			this.surnameBox.TabIndex = 8;
			// 
			// groupNameBox
			// 
			this.groupNameBox.Location = new System.Drawing.Point(12, 116);
			this.groupNameBox.Mask = ">LL???#0";
			this.groupNameBox.Name = "groupNameBox";
			this.groupNameBox.PromptChar = ' ';
			this.groupNameBox.Size = new System.Drawing.Size(92, 20);
			this.groupNameBox.TabIndex = 9;
			// 
			// LoggingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 195);
			this.Controls.Add(this.groupNameBox);
			this.Controls.Add(this.surnameBox);
			this.Controls.Add(this.nameBox);
			this.Controls.Add(this.continueButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "LoggingForm";
			this.RightToLeftLayout = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ввод данных пользователя";
			this.Load += new System.EventHandler(this.LoggingForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button continueButton;
		private System.Windows.Forms.MaskedTextBox nameBox;
		private System.Windows.Forms.MaskedTextBox surnameBox;
		private System.Windows.Forms.MaskedTextBox groupNameBox;
	}
}