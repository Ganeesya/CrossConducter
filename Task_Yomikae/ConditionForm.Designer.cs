namespace Task_Yomikae
{
	partial class ConditionForm
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
			this.checkBox_sorce = new System.Windows.Forms.CheckBox();
			this.textBox_ID = new System.Windows.Forms.TextBox();
			this.textBox_Name_R = new System.Windows.Forms.TextBox();
			this.checkBox_ID = new System.Windows.Forms.CheckBox();
			this.checkBox_Name_E = new System.Windows.Forms.CheckBox();
			this.checkBox_Message_E = new System.Windows.Forms.CheckBox();
			this.checkBox_Name_R = new System.Windows.Forms.CheckBox();
			this.checkBox_Message_R = new System.Windows.Forms.CheckBox();
			this.textBox_Mes_R = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox_Sorce = new System.Windows.Forms.ComboBox();
			this.comboBox_ToChange = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkAddSenderE = new System.Windows.Forms.CheckBox();
			this.checkAddSenderR = new System.Windows.Forms.CheckBox();
			this.textAddSender = new System.Windows.Forms.TextBox();
			this.check_AddsorceE = new System.Windows.Forms.CheckBox();
			this.check_Addsorce_R = new System.Windows.Forms.CheckBox();
			this.textAddSrc = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// checkBox_sorce
			// 
			this.checkBox_sorce.AutoSize = true;
			this.checkBox_sorce.Location = new System.Drawing.Point(12, 12);
			this.checkBox_sorce.Name = "checkBox_sorce";
			this.checkBox_sorce.Size = new System.Drawing.Size(100, 16);
			this.checkBox_sorce.TabIndex = 0;
			this.checkBox_sorce.Text = "入力ソース（＝）";
			this.checkBox_sorce.UseVisualStyleBackColor = true;
			this.checkBox_sorce.CheckedChanged += new System.EventHandler(this.checkBox_sorce_CheckedChanged);
			// 
			// textBox_ID
			// 
			this.textBox_ID.Location = new System.Drawing.Point(141, 107);
			this.textBox_ID.Name = "textBox_ID";
			this.textBox_ID.Size = new System.Drawing.Size(285, 19);
			this.textBox_ID.TabIndex = 2;
			// 
			// textBox_Name_R
			// 
			this.textBox_Name_R.Location = new System.Drawing.Point(141, 153);
			this.textBox_Name_R.Name = "textBox_Name_R";
			this.textBox_Name_R.Size = new System.Drawing.Size(285, 19);
			this.textBox_Name_R.TabIndex = 4;
			// 
			// checkBox_ID
			// 
			this.checkBox_ID.AutoSize = true;
			this.checkBox_ID.Location = new System.Drawing.Point(12, 107);
			this.checkBox_ID.Name = "checkBox_ID";
			this.checkBox_ID.Size = new System.Drawing.Size(59, 16);
			this.checkBox_ID.TabIndex = 5;
			this.checkBox_ID.Text = "ID（＝）";
			this.checkBox_ID.UseVisualStyleBackColor = true;
			this.checkBox_ID.CheckedChanged += new System.EventHandler(this.checkBox_ID_CheckedChanged);
			// 
			// checkBox_Name_E
			// 
			this.checkBox_Name_E.AutoSize = true;
			this.checkBox_Name_E.Location = new System.Drawing.Point(12, 142);
			this.checkBox_Name_E.Name = "checkBox_Name_E";
			this.checkBox_Name_E.Size = new System.Drawing.Size(77, 16);
			this.checkBox_Name_E.TabIndex = 6;
			this.checkBox_Name_E.Text = "Name（＝）";
			this.checkBox_Name_E.UseVisualStyleBackColor = true;
			this.checkBox_Name_E.CheckedChanged += new System.EventHandler(this.checkBox_Name_E_CheckedChanged);
			// 
			// checkBox_Message_E
			// 
			this.checkBox_Message_E.AutoSize = true;
			this.checkBox_Message_E.Location = new System.Drawing.Point(12, 267);
			this.checkBox_Message_E.Name = "checkBox_Message_E";
			this.checkBox_Message_E.Size = new System.Drawing.Size(93, 16);
			this.checkBox_Message_E.TabIndex = 7;
			this.checkBox_Message_E.Text = "Message（＝）";
			this.checkBox_Message_E.UseVisualStyleBackColor = true;
			this.checkBox_Message_E.CheckedChanged += new System.EventHandler(this.checkBox_Message_E_CheckedChanged);
			// 
			// checkBox_Name_R
			// 
			this.checkBox_Name_R.AutoSize = true;
			this.checkBox_Name_R.Location = new System.Drawing.Point(12, 164);
			this.checkBox_Name_R.Name = "checkBox_Name_R";
			this.checkBox_Name_R.Size = new System.Drawing.Size(113, 16);
			this.checkBox_Name_R.TabIndex = 8;
			this.checkBox_Name_R.Text = "Name（正規表現）";
			this.checkBox_Name_R.UseVisualStyleBackColor = true;
			this.checkBox_Name_R.CheckedChanged += new System.EventHandler(this.checkBox_Name_R_CheckedChanged);
			// 
			// checkBox_Message_R
			// 
			this.checkBox_Message_R.AutoSize = true;
			this.checkBox_Message_R.Location = new System.Drawing.Point(12, 289);
			this.checkBox_Message_R.Name = "checkBox_Message_R";
			this.checkBox_Message_R.Size = new System.Drawing.Size(129, 16);
			this.checkBox_Message_R.TabIndex = 9;
			this.checkBox_Message_R.Text = "Message（正規表現）";
			this.checkBox_Message_R.UseVisualStyleBackColor = true;
			this.checkBox_Message_R.CheckedChanged += new System.EventHandler(this.checkBox_Message_R_CheckedChanged);
			// 
			// textBox_Mes_R
			// 
			this.textBox_Mes_R.Location = new System.Drawing.Point(141, 278);
			this.textBox_Mes_R.Name = "textBox_Mes_R";
			this.textBox_Mes_R.Size = new System.Drawing.Size(285, 19);
			this.textBox_Mes_R.TabIndex = 11;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(351, 341);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Cansel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(270, 341);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 13;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox_Sorce
			// 
			this.comboBox_Sorce.FormattingEnabled = true;
			this.comboBox_Sorce.Location = new System.Drawing.Point(141, 10);
			this.comboBox_Sorce.Name = "comboBox_Sorce";
			this.comboBox_Sorce.Size = new System.Drawing.Size(285, 20);
			this.comboBox_Sorce.TabIndex = 14;
			// 
			// comboBox_ToChange
			// 
			this.comboBox_ToChange.FormattingEnabled = true;
			this.comboBox_ToChange.Location = new System.Drawing.Point(195, 315);
			this.comboBox_ToChange.Name = "comboBox_ToChange";
			this.comboBox_ToChange.Size = new System.Drawing.Size(231, 20);
			this.comboBox_ToChange.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(116, 318);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 16;
			this.label1.Text = "変更先";
			// 
			// checkAddSenderE
			// 
			this.checkAddSenderE.AutoSize = true;
			this.checkAddSenderE.Location = new System.Drawing.Point(12, 200);
			this.checkAddSenderE.Name = "checkAddSenderE";
			this.checkAddSenderE.Size = new System.Drawing.Size(72, 16);
			this.checkAddSenderE.TabIndex = 17;
			this.checkAddSenderE.Text = "備考（＝）";
			this.checkAddSenderE.UseVisualStyleBackColor = true;
			this.checkAddSenderE.CheckedChanged += new System.EventHandler(this.checkAddSenderE_CheckedChanged);
			// 
			// checkAddSenderR
			// 
			this.checkAddSenderR.AutoSize = true;
			this.checkAddSenderR.Location = new System.Drawing.Point(12, 223);
			this.checkAddSenderR.Name = "checkAddSenderR";
			this.checkAddSenderR.Size = new System.Drawing.Size(108, 16);
			this.checkAddSenderR.TabIndex = 18;
			this.checkAddSenderR.Text = "備考（正規表現）";
			this.checkAddSenderR.UseVisualStyleBackColor = true;
			this.checkAddSenderR.CheckedChanged += new System.EventHandler(this.checkAddSenderR_CheckedChanged);
			// 
			// textAddSender
			// 
			this.textAddSender.Location = new System.Drawing.Point(141, 210);
			this.textAddSender.Name = "textAddSender";
			this.textAddSender.Size = new System.Drawing.Size(285, 19);
			this.textAddSender.TabIndex = 19;
			// 
			// check_AddsorceE
			// 
			this.check_AddsorceE.AutoSize = true;
			this.check_AddsorceE.Location = new System.Drawing.Point(12, 45);
			this.check_AddsorceE.Name = "check_AddsorceE";
			this.check_AddsorceE.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.check_AddsorceE.Size = new System.Drawing.Size(96, 16);
			this.check_AddsorceE.TabIndex = 17;
			this.check_AddsorceE.Text = "追加情報（＝）";
			this.check_AddsorceE.UseVisualStyleBackColor = true;
			this.check_AddsorceE.CheckedChanged += new System.EventHandler(this.check_AddsorceE_CheckedChanged);
			// 
			// check_Addsorce_R
			// 
			this.check_Addsorce_R.AutoSize = true;
			this.check_Addsorce_R.Location = new System.Drawing.Point(12, 68);
			this.check_Addsorce_R.Name = "check_Addsorce_R";
			this.check_Addsorce_R.Size = new System.Drawing.Size(132, 16);
			this.check_Addsorce_R.TabIndex = 18;
			this.check_Addsorce_R.Text = "追加情報（正規表現）";
			this.check_Addsorce_R.UseVisualStyleBackColor = true;
			this.check_Addsorce_R.CheckedChanged += new System.EventHandler(this.check_Addsorce_R_CheckedChanged);
			// 
			// textAddSrc
			// 
			this.textAddSrc.Location = new System.Drawing.Point(141, 55);
			this.textAddSrc.Name = "textAddSrc";
			this.textAddSrc.Size = new System.Drawing.Size(285, 19);
			this.textAddSrc.TabIndex = 19;
			// 
			// ConditionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 377);
			this.Controls.Add(this.textAddSrc);
			this.Controls.Add(this.check_Addsorce_R);
			this.Controls.Add(this.textAddSender);
			this.Controls.Add(this.check_AddsorceE);
			this.Controls.Add(this.checkAddSenderR);
			this.Controls.Add(this.checkAddSenderE);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_ToChange);
			this.Controls.Add(this.comboBox_Sorce);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_Mes_R);
			this.Controls.Add(this.checkBox_Message_R);
			this.Controls.Add(this.checkBox_Name_R);
			this.Controls.Add(this.checkBox_Message_E);
			this.Controls.Add(this.checkBox_Name_E);
			this.Controls.Add(this.checkBox_ID);
			this.Controls.Add(this.textBox_Name_R);
			this.Controls.Add(this.textBox_ID);
			this.Controls.Add(this.checkBox_sorce);
			this.Name = "ConditionForm";
			this.Text = "ConditionForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.CheckBox checkBox_sorce;
		public System.Windows.Forms.TextBox textBox_ID;
		public System.Windows.Forms.TextBox textBox_Name_R;
		public System.Windows.Forms.CheckBox checkBox_ID;
		public System.Windows.Forms.CheckBox checkBox_Name_E;
		public System.Windows.Forms.CheckBox checkBox_Message_E;
		public System.Windows.Forms.CheckBox checkBox_Name_R;
		public System.Windows.Forms.CheckBox checkBox_Message_R;
		public System.Windows.Forms.TextBox textBox_Mes_R;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox comboBox_Sorce;
		public System.Windows.Forms.ComboBox comboBox_ToChange;
		public System.Windows.Forms.CheckBox checkAddSenderE;
		public System.Windows.Forms.CheckBox checkAddSenderR;
		public System.Windows.Forms.TextBox textAddSender;
		public System.Windows.Forms.CheckBox check_AddsorceE;
		public System.Windows.Forms.CheckBox check_Addsorce_R;
		public System.Windows.Forms.TextBox textAddSrc;
	}
}