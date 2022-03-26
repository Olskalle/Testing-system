
namespace Testing_system
{
	partial class LogForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.answers = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.group,
            this.surname,
            this.name,
            this.answers,
            this.mark,
            this.date,
            this.time});
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(723, 426);
			this.dataGridView1.TabIndex = 0;
			// 
			// group
			// 
			this.group.HeaderText = "Группа";
			this.group.MaxInputLength = 1024;
			this.group.Name = "group";
			this.group.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.group.Width = 80;
			// 
			// surname
			// 
			this.surname.HeaderText = "Фамилия";
			this.surname.Name = "surname";
			this.surname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.surname.Width = 150;
			// 
			// name
			// 
			this.name.HeaderText = "Имя";
			this.name.Name = "name";
			this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.name.Width = 150;
			// 
			// answers
			// 
			this.answers.HeaderText = "Кол-во баллов";
			this.answers.Name = "answers";
			this.answers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.answers.Width = 50;
			// 
			// mark
			// 
			this.mark.HeaderText = "Оценка";
			this.mark.Name = "mark";
			this.mark.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.mark.Width = 50;
			// 
			// date
			// 
			this.date.HeaderText = "Дата прохождения";
			this.date.Name = "date";
			this.date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// time
			// 
			this.time.HeaderText = "Время прохождения";
			this.time.Name = "time";
			this.time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// LogForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 450);
			this.Controls.Add(this.dataGridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "LogForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Журнал";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn group;
		private System.Windows.Forms.DataGridViewTextBoxColumn surname;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.DataGridViewTextBoxColumn answers;
		private System.Windows.Forms.DataGridViewTextBoxColumn mark;
		private System.Windows.Forms.DataGridViewTextBoxColumn date;
		private System.Windows.Forms.DataGridViewTextBoxColumn time;
	}
}