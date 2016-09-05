namespace VoiceroidConfigForm
{
	partial class VoiceroidConfigForm
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
			this.button_cansel = new System.Windows.Forms.Button();
			this.button_ok = new System.Windows.Forms.Button();
			this.textBox_main = new System.Windows.Forms.TextBox();
			this.textBox_butten = new System.Windows.Forms.TextBox();
			this.textBox_rich = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_title = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button_cansel
			// 
			this.button_cansel.Location = new System.Drawing.Point(326, 112);
			this.button_cansel.Name = "button_cansel";
			this.button_cansel.Size = new System.Drawing.Size(75, 23);
			this.button_cansel.TabIndex = 0;
			this.button_cansel.Text = "Cansel";
			this.button_cansel.UseVisualStyleBackColor = true;
			this.button_cansel.Click += new System.EventHandler(this.button_cansel_Click);
			// 
			// button_ok
			// 
			this.button_ok.Location = new System.Drawing.Point(245, 112);
			this.button_ok.Name = "button_ok";
			this.button_ok.Size = new System.Drawing.Size(75, 23);
			this.button_ok.TabIndex = 1;
			this.button_ok.Text = "OK";
			this.button_ok.UseVisualStyleBackColor = true;
			this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
			// 
			// textBox_main
			// 
			this.textBox_main.Location = new System.Drawing.Point(125, 12);
			this.textBox_main.Name = "textBox_main";
			this.textBox_main.Size = new System.Drawing.Size(276, 19);
			this.textBox_main.TabIndex = 2;
			// 
			// textBox_butten
			// 
			this.textBox_butten.Location = new System.Drawing.Point(125, 62);
			this.textBox_butten.Name = "textBox_butten";
			this.textBox_butten.Size = new System.Drawing.Size(276, 19);
			this.textBox_butten.TabIndex = 3;
			// 
			// textBox_rich
			// 
			this.textBox_rich.Location = new System.Drawing.Point(125, 37);
			this.textBox_rich.Name = "textBox_rich";
			this.textBox_rich.Size = new System.Drawing.Size(276, 19);
			this.textBox_rich.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "MainClassName";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "RichtextClassName";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "ButtenClassName";
			// 
			// textBox_title
			// 
			this.textBox_title.Location = new System.Drawing.Point(125, 87);
			this.textBox_title.Name = "textBox_title";
			this.textBox_title.Size = new System.Drawing.Size(276, 19);
			this.textBox_title.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 12);
			this.label4.TabIndex = 9;
			this.label4.Text = "WindowTitle";
			// 
			// VoiceroidConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 143);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox_title);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_rich);
			this.Controls.Add(this.textBox_butten);
			this.Controls.Add(this.textBox_main);
			this.Controls.Add(this.button_ok);
			this.Controls.Add(this.button_cansel);
			this.Name = "VoiceroidConfigForm";
			this.Text = "VoiceroidConfigForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VoiceroidConfigForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_cansel;
		private System.Windows.Forms.Button button_ok;
		private System.Windows.Forms.TextBox textBox_main;
		private System.Windows.Forms.TextBox textBox_butten;
		private System.Windows.Forms.TextBox textBox_rich;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_title;
		private System.Windows.Forms.Label label4;
	}
}