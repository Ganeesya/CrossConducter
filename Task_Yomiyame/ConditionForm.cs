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

namespace Task_Yomiyame
{
	public partial class ConditionForm : Form
	{
		public DialogResult res = DialogResult.None;
		public ConditionForm(TaskListDataInterface tasker)
		{
			InitializeComponent();
			ReEnable();
			foreach(CCInputInterface e in tasker.GetInputList())
			{
				comboBox_Sorce.Items.Add(e.getPluginName());
			}			
		}

		private void checkBox_Message_R_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void checkBox_sorce_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void checkBox_ID_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void checkBox_Name_E_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void checkBox_Name_R_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void checkBox_Message_E_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void ReEnable()
		{
			comboBox_Sorce.Enabled = checkBox_sorce.Checked;
			textBox_ID.Enabled = checkBox_ID.Checked;
			textBox_Name_R.Enabled = checkBox_Name_R.Checked | checkBox_Name_E.Checked ;
			checkBox_Name_E.Enabled = !checkBox_Name_R.Checked;
			textBox_Mes_R.Enabled = checkBox_Message_R.Checked | checkBox_Message_E.Checked;
			checkBox_Message_E.Enabled = !checkBox_Message_R.Checked;

			textAddSrc.Enabled = check_AddsorceE.Checked | check_Addsorce_R.Checked;
			check_AddsorceE.Enabled = !check_Addsorce_R.Checked;

			textAddSender.Enabled = checkAddSenderE.Checked | checkAddSenderR.Checked;
			checkAddSenderE.Enabled = !checkAddSenderR.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			res = DialogResult.OK;
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			res = DialogResult.Cancel;
			Close();
		}

		private void check_AddsorceE_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void check_Addsorce_R_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void checkAddSenderE_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}

		private void checkAddSenderR_CheckedChanged(object sender, EventArgs e)
		{
			ReEnable();
		}
	}
}
