namespace CrossConducter
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.listView4 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.messageQueue1 = new System.Messaging.MessageQueue();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel_input = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_task = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_out = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_queue = new System.Windows.Forms.ToolStripStatusLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView4
			// 
			this.listView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader2});
			this.listView4.Location = new System.Drawing.Point(12, 12);
			this.listView4.Name = "listView4";
			this.listView4.Size = new System.Drawing.Size(753, 274);
			this.listView4.TabIndex = 3;
			this.listView4.UseCompatibleStateImageBehavior = false;
			this.listView4.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ソース";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "名前";
			this.columnHeader5.Width = 68;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "ID";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "メッセージ";
			this.columnHeader7.Width = 352;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "読み上げ";
			// 
			// messageQueue1
			// 
			this.messageQueue1.MessageReadPropertyFilter.LookupId = true;
			this.messageQueue1.SynchronizingObject = this;
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_input,
            this.toolStripStatusLabel_task,
            this.toolStripStatusLabel_out,
            this.toolStripStatusLabel_queue});
			this.statusStrip1.Location = new System.Drawing.Point(0, 318);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(777, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel_input
			// 
			this.toolStripStatusLabel_input.IsLink = true;
			this.toolStripStatusLabel_input.Name = "toolStripStatusLabel_input";
			this.toolStripStatusLabel_input.Size = new System.Drawing.Size(38, 17);
			this.toolStripStatusLabel_input.Text = "input:";
			this.toolStripStatusLabel_input.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
			// 
			// toolStripStatusLabel_task
			// 
			this.toolStripStatusLabel_task.IsLink = true;
			this.toolStripStatusLabel_task.Name = "toolStripStatusLabel_task";
			this.toolStripStatusLabel_task.Size = new System.Drawing.Size(51, 17);
			this.toolStripStatusLabel_task.Text = "checker:";
			this.toolStripStatusLabel_task.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripStatusLabel_task.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
			// 
			// toolStripStatusLabel_out
			// 
			this.toolStripStatusLabel_out.IsLink = true;
			this.toolStripStatusLabel_out.Name = "toolStripStatusLabel_out";
			this.toolStripStatusLabel_out.Size = new System.Drawing.Size(46, 17);
			this.toolStripStatusLabel_out.Text = "output:";
			this.toolStripStatusLabel_out.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
			// 
			// toolStripStatusLabel_queue
			// 
			this.toolStripStatusLabel_queue.Name = "toolStripStatusLabel_queue";
			this.toolStripStatusLabel_queue.Size = new System.Drawing.Size(45, 17);
			this.toolStripStatusLabel_queue.Text = "Queue:";
			this.toolStripStatusLabel_queue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(12, 292);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(398, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "アウトプットテスト";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(341, 292);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(424, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "過去ログ";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "備考";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "追加情報";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 340);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.listView4);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListView listView4;
		private System.Messaging.MessageQueue messageQueue1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_input;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_task;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_out;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_queue;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}

