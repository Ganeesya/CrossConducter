using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrossConducter;

namespace Task_Yomikae
{
	public partial class configForm : Form
	{
		public ConditonList cList;

		public TaskListDataInterface tasker;

		public configForm()
		{
			InitializeComponent();
			cList = ConditonList.Load("Task_Yomikae.config");

			foreach(Condition e in cList.clist)
			{
				ListViewItem additem = new ListViewItem(e.ToString());
				additem.Tag = e;
				listView1.Items.Add(additem);
			}
		}
		
		private void buttonSet_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			Condition select = (Condition)listView1.SelectedItems[0].Tag;

			ConditionForm cf = new ConditionForm(tasker);
			cf.checkBox_ID.Checked = select.b_ID;
			cf.checkBox_Message_E.Checked = select.b_Mes_E;
			cf.checkBox_Message_R.Checked = select.b_Mes_R;
			cf.checkBox_Name_E.Checked = select.b_Name_E;
			cf.checkBox_Name_R.Checked = select.b_Name_R;
			cf.checkBox_sorce.Checked = select.b_Sorse;

			cf.textBox_ID.Text = select.d_ID;
			cf.textBox_Mes_R.Text = select.d_Mes;
			cf.textBox_Name_R.Text = select.d_Name;

			cf.comboBox_Sorce.Text = select.d_Sorse;
			cf.comboBox_ToChange.Text = select.toChange;

			cf.ShowDialog();

			if (cf.res == DialogResult.OK)
			{
				select.b_ID = cf.checkBox_ID.Checked;
				select.b_Mes_E = cf.checkBox_Message_E.Checked;
				select.b_Mes_R = cf.checkBox_Message_R.Checked;
				select.b_Name_E = cf.checkBox_Name_E.Checked;
				select.b_Name_R = cf.checkBox_Name_R.Checked;
				select.b_Sorse = cf.checkBox_sorce.Checked;

				select.d_ID = cf.textBox_ID.Text;
				select.d_Mes = cf.textBox_Mes_R.Text;
				select.d_Name = cf.textBox_Name_R.Text;
				select.d_Sorse = cf.comboBox_Sorce.Text;
				select.toChange = cf.comboBox_ToChange.Text;
				
				cList.Save("Task_Yomikae.config");
			}
		}
		
		private void configForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void buttonSub_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			cList.clist.Remove((Condition)listView1.SelectedItems[0].Tag);
			listView1.Items.Remove(listView1.SelectedItems[0]);
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{

			ConditionForm cf = new ConditionForm(tasker);
			cf.ShowDialog();
			if (cf.res == DialogResult.OK)
			{
				Condition add = new Condition();
				add.b_ID = cf.checkBox_ID.Checked;
				add.b_Mes_E = cf.checkBox_Message_E.Checked;
				add.b_Mes_R = cf.checkBox_Message_R.Checked;
				add.b_Name_E = cf.checkBox_Name_E.Checked;
				add.b_Name_R = cf.checkBox_Name_R.Checked;
				add.b_Sorse = cf.checkBox_sorce.Checked;

				add.d_ID = cf.textBox_ID.Text;
				add.d_Mes = cf.textBox_Mes_R.Text;
				add.d_Name = cf.textBox_Name_R.Text;
				add.d_Sorse = cf.comboBox_Sorce.Text;
				add.toChange = cf.comboBox_ToChange.Text;

				cList.clist.Add(add);
				cList.Save("Task_Yomikae.config");

				ListViewItem additem = new ListViewItem(add.ToString());
				additem.Tag = add;

				listView1.Items.Add(additem);
			}
		}

		private void button_UP_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			if (listView1.SelectedItems[0].Index == 0)
				return;

			int viewpoint = listView1.SelectedItems[0].Index - 1;
			ListViewItem temp = listView1.SelectedItems[0];

			listView1.Items.Remove(temp);
			listView1.Items.Insert(viewpoint, temp);

			int listpoint = cList.clist.IndexOf((Condition)temp.Tag) - 1;

			cList.clist.Remove((Condition)temp.Tag);
			cList.clist.Insert(listpoint, (Condition)temp.Tag);
			cList.Save("Task_Yomikae.config");
		}

		private void button_Down_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			if (listView1.SelectedItems[0].Index == listView1.Items.Count - 1)
				return;

			int viewpoint = listView1.SelectedItems[0].Index + 1;
			ListViewItem temp = listView1.SelectedItems[0];

			listView1.Items.Remove(temp);
			listView1.Items.Insert(viewpoint, temp);

			int listpoint = cList.clist.IndexOf((Condition)temp.Tag) + 1;

			cList.clist.Remove((Condition)temp.Tag);
			cList.clist.Insert(listpoint, (Condition)temp.Tag);
			cList.Save("Task_Yomikae.config");
		}
	}
}
