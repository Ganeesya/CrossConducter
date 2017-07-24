using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CrossConducter
{
	public partial class LogForm : Form
	{
		private bool showed = false;
		private DateTime lastAdd = DateTime.Now;
		public Tasker copy;

		public LogForm()
		{
			InitializeComponent();
			listView1.GetType().InvokeMember(
					   "DoubleBuffered",
					   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
					   null,
					   listView1,
					   new object[] { true });//*/
			listView1.ListViewItemSorter = new ListViewItemComparer(0);
		}

		private void toolStripStatusLabel_Queue_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				toolStripStatusLabel_Queue.Text = listView1.Items.Count + "(クリックでログクリア)";

				listView1.BeginUpdate();
				foreach (YomiageTask ele in copy.log)
				{
					if(lastAdd < ele.LogTime)
					{
						addLog(ele);
					}
				}
				lastAdd = DateTime.Now;
				foreach (ListViewItem ele in listView1.Items)
				{
					ele.SubItems[0].Text = (DateTime.Now - ((YomiageTask)ele.Tag).LogTime).ToString(@"%h\:mm\:ss");
				}
				listView1.EndUpdate();
			}
			catch
			{

			}
		}

		public void addLog(YomiageTask ntask)
		{
			ListViewItem nitem = new ListViewItem(new string[8] {
						"-" +(DateTime.Now - ntask.LogTime).ToString(@"%h\:mm\:ss")
						, ntask.AuthorName
						, ntask.AuthorID
						, ntask.authorAddinfo
						, ntask.Message
						, ntask.Outputer.getPluginName()
						, ntask.Src
						, ntask.srcAddinfo});
			nitem.Tag = ntask;
			listView1.Items.Add(nitem);
		}

		public bool TogleOpen()
		{
			if (showed)
			{
				Hide();
				timer1.Enabled = false;
				showed = false;
			}
			else
			{
				Show();
				timer1.Enabled = true;
				showed = true;
			}

			return showed;
		}

		private void LogForm_Load(object sender, EventArgs e)
		{
		}

		private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			
		}

		private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try {
				ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
				Clipboard.SetText(info.SubItem.Text);
			}
			catch { }
		}
	}

	public class ListViewItemComparer : IComparer
	{
		private int _column;

		/// <summary>
		/// ListViewItemComparerクラスのコンストラクタ
		/// </summary>
		/// <param name="col">並び替える列番号</param>
		public ListViewItemComparer(int col)
		{
			_column = col;
		}

		//xがyより小さいときはマイナスの数、大きいときはプラスの数、
		//同じときは0を返す
		public int Compare(object x, object y)
		{
			//ListViewItemの取得
			ListViewItem itemx = (ListViewItem)x;
			ListViewItem itemy = (ListViewItem)y;

			//xとyを文字列として比較する
			return string.Compare(itemx.SubItems[_column].Text,
				itemy.SubItems[_column].Text);
		}
	}
}
