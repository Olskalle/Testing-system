
namespace Testing_system
{
	partial class MenuForm
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
			this.startTestButton = new System.Windows.Forms.Button();
			this.logButton = new System.Windows.Forms.Button();
			this.infoButton = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// startTestButton
			// 
			this.startTestButton.Location = new System.Drawing.Point(12, 12);
			this.startTestButton.Name = "startTestButton";
			this.startTestButton.Size = new System.Drawing.Size(140, 39);
			this.startTestButton.TabIndex = 0;
			this.startTestButton.Text = "Начать тестирование";
			this.startTestButton.UseVisualStyleBackColor = true;
			this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
			// 
			// logButton
			// 
			this.logButton.Location = new System.Drawing.Point(12, 57);
			this.logButton.Name = "logButton";
			this.logButton.Size = new System.Drawing.Size(140, 39);
			this.logButton.TabIndex = 1;
			this.logButton.Text = "Журнал тестирований";
			this.logButton.UseVisualStyleBackColor = true;
			this.logButton.Click += new System.EventHandler(this.logButton_Click);
			// 
			// infoButton
			// 
			this.infoButton.Location = new System.Drawing.Point(12, 102);
			this.infoButton.Name = "infoButton";
			this.infoButton.Size = new System.Drawing.Size(140, 39);
			this.infoButton.TabIndex = 2;
			this.infoButton.Text = "Справка";
			this.infoButton.UseVisualStyleBackColor = true;
			this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
			// 
			// exitButton
			// 
			this.exitButton.Location = new System.Drawing.Point(12, 147);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(140, 39);
			this.exitButton.TabIndex = 3;
			this.exitButton.Text = "Выход";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = global::Testing_system.Properties.Resources.image048_1;
			this.pictureBox1.Location = new System.Drawing.Point(169, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(231, 174);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// MenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 200);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.infoButton);
			this.Controls.Add(this.logButton);
			this.Controls.Add(this.startTestButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MenuForm";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Меню";
			this.Load += new System.EventHandler(this.MenuForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button startTestButton;
		private System.Windows.Forms.Button logButton;
		private System.Windows.Forms.Button infoButton;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}