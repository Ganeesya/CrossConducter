using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeReader
{
	public partial class ConfigForm : Form
	{
		private configs copy;
		public configs Copy
		{
			set {
				copy = value;
				this.textBoxChannel.Text = value.ChannnelID;
				this.textBoxApiKey.Text = value.APIKey;
				this.checkBox_OnlySuperChat.Checked = value.OnlySuperchat;
			}
			get { return this.copy; }
		}

		public ConfigForm()
		{
			InitializeComponent();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			copy.APIKey = textBoxApiKey.Text;
			copy.ChannnelID = textBoxChannel.Text;
			copy.OnlySuperchat = checkBox_OnlySuperChat.Checked;
			this.Close();
		}

		private void buttonCansel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
