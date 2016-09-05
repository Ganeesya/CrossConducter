namespace Task_Yomikae
{
	partial class configForm
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button_Settting = new System.Windows.Forms.Button();
			this.button_Copy = new System.Windows.Forms.Button();
			this.button_Down = new System.Windows.Forms.Button();
			this.button_UP = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(483, 198);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.List;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 216);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(33, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "+";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(51, 216);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(30, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "-";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.buttonSub_Click);
			// 
			// button_Settting
			// 
			this.button_Settting.Location = new System.Drawing.Point(420, 216);
			this.button_Settting.Name = "button_Settting";
			this.button_Settting.Size = new System.Drawing.Size(75, 23);
			this.button_Settting.TabIndex = 3;
			this.button_Settting.Text = "set";
			this.button_Settting.UseVisualStyleBackColor = true;
			this.button_Settting.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// button_Copy
			// 
			this.button_Copy.Location = new System.Drawing.Point(87, 216);
			this.button_Copy.Name = "button_Copy";
			this.button_Copy.Size = new System.Drawing.Size(75, 23);
			this.button_Copy.TabIndex = 4;
			this.button_Copy.Text = "copy";
			this.button_Copy.UseVisualStyleBackColor = true;
			// 
			// button_Down
			// 
			this.button_Down.Location = new System.Drawing.Point(292, 216);
			this.button_Down.Name = "button_Down";
			this.button_Down.Size = new System.Drawing.Size(32, 23);
			this.button_Down.TabIndex = 5;
			this.button_Down.Text = "↓";
			this.button_Down.UseVisualStyleBackColor = true;
			this.button_Down.Click += new System.EventHandler(this.button_Down_Click);
			// 
			// button_UP
			// 
			this.button_UP.Location = new System.Drawing.Point(254, 216);
			this.button_UP.Name = "button_UP";
			this.button_UP.Size = new System.Drawing.Size(32, 23);
			this.button_UP.TabIndex = 6;
			this.button_UP.Text = "↑";
			this.button_UP.UseVisualStyleBackColor = true;
			this.button_UP.Click += new System.EventHandler(this.button_UP_Click);
			// 
			// configForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(508, 261);
			this.Controls.Add(this.button_UP);
			this.Controls.Add(this.button_Down);
			this.Controls.Add(this.button_Copy);
			this.Controls.Add(this.button_Settting);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listView1);
			this.Name = "configForm";
			this.Text = "configForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.configForm_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button_Settting;
		private System.Windows.Forms.Button button_Copy;
		private System.Windows.Forms.Button button_Down;
		private System.Windows.Forms.Button button_UP;
	}
}