using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using DotNetOpenAuth.OAuth2;


using System.Diagnostics;
using System.Threading;

namespace CrossConducter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
		}

		private Tasker tasker;

		private LogForm logfrom;

		private PluginConfigs taskConfigForm;
		private PluginConfigs outConfigForm;
		private PluginConfigs inConfigForm;

		private void getList()
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			tasker = new Tasker();
			tasker.init();
			logfrom = new LogForm();
			logfrom.copy = tasker;
			listView4.GetType().InvokeMember(
					   "DoubleBuffered",
					   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
					   null,
					   listView4,
					   new object[] { true });//*/

			toolStripStatusLabel_input.Text = "input:" + tasker.GetInputList().Count.ToString();
			toolStripStatusLabel_task.Text = "checker:" + tasker.GetTaskControllList().Count.ToString();
			toolStripStatusLabel_out.Text = "output:" + tasker.GetOutputList().Count.ToString();

			taskConfigForm = new PluginConfigs("TaskPlugins");
			taskConfigForm.addLists(tasker.GetTaskControllList().ToList<CCPluginInterface>());

			outConfigForm = new PluginConfigs("OutputPlugins");
			outConfigForm.addLists(tasker.GetOutputList().ToList<CCPluginInterface>());

			inConfigForm = new PluginConfigs("InputPlugins");
			inConfigForm.addLists(tasker.GetInputList().ToList<CCPluginInterface>());
		}

		private void updateQueue()
		{
			toolStripStatusLabel_queue.Text = "Queue:" + tasker.GetTaskList().Count.ToString();

			listView4.BeginUpdate();
			listView4.Items.Clear();
			if (tasker.NowTask != null)
			{
				ListViewItem doing = new ListViewItem(new string[5] {
					tasker.NowTask.From, tasker.NowTask.AuthorName, tasker.NowTask.AuthorID, tasker.NowTask.Message,tasker.NowTask.Outputer.getPluginName() });
				doing.BackColor = Color.Pink;
				listView4.Items.Add(doing);
			}
			foreach (YomiageTask e in tasker.GetTaskList())
			{
				
				listView4.Items.Add(new ListViewItem(new string[5] { e.From, e.AuthorName, e.AuthorID, e.Message,e.Outputer.getPluginName() }));
			}
			listView4.EndUpdate();
		}		

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			tasker.close();
		}

		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{
			inConfigForm.Show();
		}

		private void toolStripStatusLabel2_Click(object sender, EventArgs e)
		{
			taskConfigForm.Show();
		}

		private void toolStripStatusLabel3_Click(object sender, EventArgs e)
		{
			outConfigForm.Show();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			foreach(CCOutputInterface ele in tasker.GetOutputList())
			{
				tasker.addTaskTester("アウトプットのテストです", "testID", "テスト", "テストオーナー",ele);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			updateQueue();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			logfrom.TogleOpen();
		}
	}
}
