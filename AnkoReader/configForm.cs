using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnkoReader
{
	public partial class configForm : Form
	{
		DialogResult res = DialogResult.None;

		public configForm()
		{
			InitializeComponent();
		}

		public void OpenSetting(configs datas)
		{
			res = DialogResult.None;
			textBox1.Text = datas.port.ToString();
			ShowDialog();
			if(res == DialogResult.OK)
			{
				try
				{
					datas.port = int.Parse(textBox1.Text);
				}
				catch { }
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			res = DialogResult.OK;
			Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			res = DialogResult.Cancel;
			Hide();
		}
	}
}
