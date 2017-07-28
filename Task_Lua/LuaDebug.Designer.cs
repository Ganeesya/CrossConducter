namespace Task_Lua
{
	partial class LuaDebug
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
			this.textBox_script = new System.Windows.Forms.TextBox();
			this.textBox_debug = new System.Windows.Forms.TextBox();
			this.butten_FileSelect = new System.Windows.Forms.Button();
			this.label_filename = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox_script
			// 
			this.textBox_script.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_script.Location = new System.Drawing.Point(14, 47);
			this.textBox_script.Multiline = true;
			this.textBox_script.Name = "textBox_script";
			this.textBox_script.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_script.Size = new System.Drawing.Size(678, 417);
			this.textBox_script.TabIndex = 0;
			// 
			// textBox_debug
			// 
			this.textBox_debug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_debug.Location = new System.Drawing.Point(12, 470);
			this.textBox_debug.Multiline = true;
			this.textBox_debug.Name = "textBox_debug";
			this.textBox_debug.Size = new System.Drawing.Size(680, 139);
			this.textBox_debug.TabIndex = 1;
			// 
			// butten_FileSelect
			// 
			this.butten_FileSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butten_FileSelect.Location = new System.Drawing.Point(617, 12);
			this.butten_FileSelect.Name = "butten_FileSelect";
			this.butten_FileSelect.Size = new System.Drawing.Size(75, 23);
			this.butten_FileSelect.TabIndex = 2;
			this.butten_FileSelect.Text = "ファイル指定";
			this.butten_FileSelect.UseVisualStyleBackColor = true;
			this.butten_FileSelect.Click += new System.EventHandler(this.butten_FileSelect_Click);
			// 
			// label_filename
			// 
			this.label_filename.AutoSize = true;
			this.label_filename.Location = new System.Drawing.Point(12, 17);
			this.label_filename.Name = "label_filename";
			this.label_filename.Size = new System.Drawing.Size(35, 12);
			this.label_filename.TabIndex = 3;
			this.label_filename.Text = "label1";
			// 
			// LuaDebug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(704, 621);
			this.Controls.Add(this.label_filename);
			this.Controls.Add(this.butten_FileSelect);
			this.Controls.Add(this.textBox_debug);
			this.Controls.Add(this.textBox_script);
			this.Name = "LuaDebug";
			this.Text = "LuaDebug";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LuaDebug_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button butten_FileSelect;
		public System.Windows.Forms.TextBox textBox_script;
		public System.Windows.Forms.TextBox textBox_debug;
		public System.Windows.Forms.Label label_filename;
	}
}