using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Task_Lua
{
	public partial class LuaDebug : Form
	{
		public Task_Lua parent;

		public delegate void updug(string t, Color c);
		public updug updateDebugDel;

		public LuaDebug()
		{
			InitializeComponent();
			updateDebugDel = new updug(updateDebug);
		}

		public void updateFilename()
		{
			if (parent.configdata.fileTarget == "")
			{
				label_filename.Text = "未指定です";
				textBox_script.Text = "";
			}
			else
			{
				label_filename.Text = parent.configdata.fileTarget;
				textBox_script.Text = File.ReadAllText(parent.configdata.fileTarget);
			}
		}

		private void butten_FileSelect_Click(object sender, EventArgs e)
		{
			OpenFileDialog fDig = new OpenFileDialog();
			if (parent.configdata.fileTarget != "")
			{
				fDig.InitialDirectory = Path.GetFullPath(parent.configdata.fileTarget);
			}
			if (fDig.ShowDialog() == DialogResult.OK)
			{
				parent.updateConfigTarget(fDig.FileName);
				updateFilename();
			}
		}

		private void loadupScript()
		{
			try
			{
				using (StreamReader sr = new StreamReader(parent.configdata.fileTarget))
				{
					textBox_script.Text = sr.ReadToEnd();
				}
			}
			catch { };
		}

		private void LuaDebug_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}


		public void updateDebug(string txt, Color c)
		{
			textBox_debug.Text = txt;
			textBox_debug.ForeColor = System.Drawing.Color.Black;
		}
	}
}
