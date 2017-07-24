using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossConducter;
using FNF.Utility;
using System.Runtime.Remoting;

namespace Out_Bouyomi
{
    public class OutBouyomi : CCOutputInterface
	{
		private BouyomiChanClient bcc;

		public void init()
		{
			try
			{
				bcc = new BouyomiChanClient();
			}
			catch
			{
				bcc = null;
			}
		}

		public string getPluginName()
		{
			return "Bouyomi";
		}

		public void close()
		{
			bcc.Dispose();
		}

		public bool isBusy()
		{
			bool r = false;
			try
			{
				r = bcc.NowPlaying;
			}
			catch { }
			return r;
		}

		public bool isEnable()
		{
			bool r = true;
			try
			{
				int i = bcc.TalkTaskCount;
			}
			catch
			{
				r = false;
			}
			return r;
		}

		public void output(string mes, int speed)
		{
			try
			{
				bcc.AddTalkTask(mes,speed,-1,VoiceType.Default);
			}
			catch { }
		}

		public void openConfig()
		{

		}
	}	
}
