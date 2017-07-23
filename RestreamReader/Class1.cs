using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossConducter;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RestreamReader
{
    public class RestreamReader : CCInputInterface
	{
		TaskAdderInterface tai;
		Thread readloop;
		DateTime lasttime;
		configs configdata;
		DateTime logPointTime;

		public void init(TaskAdderInterface taskadder)
		{
			tai = taskadder;
			lasttime = DateTime.Now;
			logPointTime = DateTime.Now;
			configdata = configs.Load("Restream.config");

			readloop = new Thread(new ThreadStart(ReadingLoop));
			readloop.Start();			
		}

		public string getPluginName()
		{
			return "RestreamReader";
		}

		private void ReadingLoop()
		{
			int lastReadLine = 0;
			if (configdata.fileTarget != "")
			{
				using (StreamReader sr = new StreamReader(configdata.fileTarget))
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						lastReadLine++;
					}
				}
			}
			while (true)
			{
				Thread.Sleep(1000);
				if(configdata.fileTarget == "")
				{
					continue;
				}
				using (StreamReader sr = new StreamReader(configdata.fileTarget))
				{
					string line;
					int readLine = 1;
					while ((line = sr.ReadLine()) != null)
					{
						if(lastReadLine < readLine)
						{
							analyzeLine(line);
							lastReadLine = readLine;
						}
						readLine++;
					}
				}
			}
		}

		private void analyzeLine(string line)
		{
			if(line[0] == '[')
			{
				analLogLine(line);
			}
			else
			{
				analLogStart(line);
			}
		}

		private void analLogStart(string line)
		{
			//Log started: 2017/07/20 16:07:23
			MatchCollection mc = Regex.Matches(line, "^Log started: (?<year>\\d\\d\\d\\d)/(?<month>\\d\\d)/(?<day>\\d\\d) (?<hour>\\d\\d):(?<min>\\d\\d):(?<sec>\\d\\d)");

			if( mc.Count > 0 )
			{
				logPointTime = logPointTime.AddYears(int.Parse(mc[0].Groups["year"].Value) - logPointTime.Year);
				logPointTime = logPointTime.AddMonths(int.Parse(mc[0].Groups["month"].Value) - logPointTime.Month);
				logPointTime = logPointTime.AddDays(int.Parse(mc[0].Groups["day"].Value) - logPointTime.Day);
				logPointTime = logPointTime.AddHours(int.Parse(mc[0].Groups["hour"].Value) - logPointTime.Hour);
				logPointTime = logPointTime.AddMinutes(int.Parse(mc[0].Groups["min"].Value) - logPointTime.Minute);
				logPointTime = logPointTime.AddSeconds(int.Parse(mc[0].Groups["sec"].Value) - logPointTime.Second);
			}
		}

		private void analLogLine(string line)
		{
			//[16:19:16] AllChats AllChats, Broadcaster: てす
			MatchCollection mc = Regex.Matches(line, "\\[(?<hour>\\d+):(?<min>\\d+):(?<sec>\\d+)\\] (?<serv>\\S+) (?<servID>[^,]+), (?<auth>[^:]+): (?<mes>[^\n]+)");

			if (mc.Count > 0)
			{
				DateTime nlinetime = new DateTime( logPointTime.Ticks );
				nlinetime = nlinetime.AddHours(int.Parse(mc[0].Groups["hour"].Value) - nlinetime.Hour);
				nlinetime = nlinetime.AddMinutes(int.Parse(mc[0].Groups["min"].Value) - nlinetime.Minute);
				nlinetime = nlinetime.AddSeconds(int.Parse(mc[0].Groups["sec"].Value) - nlinetime.Second);
				
				tai.addTask(mc[0].Groups["mes"].Value, mc[0].Groups["servID"].Value, mc[0].Groups["auth"].Value,"", this, mc[0].Groups["serv"].Value);
			}
		}

		public void close()
		{
			readloop.Abort();
		}

		public void openConfig()
		{
			OpenFileDialog fDig = new OpenFileDialog();
			if (configdata.fileTarget != "")
			{
				fDig.InitialDirectory = Path.GetFullPath(configdata.fileTarget);
			}
			if(fDig.ShowDialog()==DialogResult.OK)
			{
				configdata.fileTarget = fDig.FileName;
				configdata.Save("Restream.config");
			}
		}
	}

	[Serializable]
	public class configs
	{
		public string fileTarget;

		public configs()
		{
			fileTarget = "";
		}

		public static configs Load(string path)
		{
			if (!File.Exists(path))
			{
				return new configs();
			}

			using (FileStream fs = new FileStream(path, FileMode.Open))
			{
				return Load(fs);
			}
		}

		public static configs Load(Stream stream)
		{
			configs configData = null;
			try
			{
				System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(configs));
				configData = xs.Deserialize(stream) as configs;
			}
			catch { }

			return configData != null ? configData : new configs();
		}

		public void Save(Stream stream)
		{
			try
			{
				XmlSerializer xs = new XmlSerializer(this.GetType());
				xs.Serialize(stream, this);
			}
			catch
			{ }
		}

		public void Save(string path)
		{
			try
			{
				using (FileStream fs = new FileStream(path, FileMode.Create))
				{
					Save(fs);
				}
			}
			catch { }
		}
	}
}
