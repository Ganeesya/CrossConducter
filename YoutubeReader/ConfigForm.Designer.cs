namespace YoutubeReader
{
	partial class ConfigForm
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCansel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.textBoxChannel = new System.Windows.Forms.TextBox();
			this.textBoxApiKey = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(261, 61);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCansel
			// 
			this.buttonCansel.Location = new System.Drawing.Point(342, 61);
			this.buttonCansel.Name = "buttonCansel";
			this.buttonCansel.Size = new System.Drawing.Size(75, 23);
			this.buttonCansel.TabIndex = 1;
			this.buttonCansel.Text = "Cansel";
			this.buttonCansel.UseVisualStyleBackColor = true;
			this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "channelID";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(12, 39);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(42, 12);
			this.linkLabel1.TabIndex = 3;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "APIKey";
			// 
			// textBoxChannel
			// 
			this.textBoxChannel.Location = new System.Drawing.Point(88, 6);
			this.textBoxChannel.Name = "textBoxChannel";
			this.textBoxChannel.Size = new System.Drawing.Size(329, 19);
			this.textBoxChannel.TabIndex = 4;
			// 
			// textBoxApiKey
			// 
			this.textBoxApiKey.Location = new System.Drawing.Point(88, 36);
			this.textBoxApiKey.Name = "textBoxApiKey";
			this.textBoxApiKey.Size = new System.Drawing.Size(329, 19);
			this.textBoxApiKey.TabIndex = 5;
			// 
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 93);
			this.Controls.Add(this.textBoxApiKey);
			this.Controls.Add(this.textBoxChannel);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCansel);
			this.Controls.Add(this.buttonOK);
			this.Name = "ConfigForm";
			this.Text = "ConfigForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCansel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.TextBox textBoxChannel;
		private System.Windows.Forms.TextBox textBoxApiKey;
	}
}