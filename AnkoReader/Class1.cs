using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossConducter;
using System.Threading;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.IO;

namespace AnkoReader
{
    public class AnkoReader : CCInputInterface
	{
		TaskAdderInterface adder;
		Thread tcploop;
		configs config;
		TcpListener server;

		bool enable = true;

		public void init(TaskAdderInterface taskadder)
		{
			config = configs.Load("AnkoReader.config");
			adder = taskadder;

			tcploop = new Thread(new ThreadStart(TcpListenLoop));
			tcploop.Start();
		}

		public void Enable(bool val)
		{
			if (!enable & val & !tcploop.IsAlive)
			{
				tcploop = new Thread(new ThreadStart(TcpListenLoop));
				tcploop.Start();
			}
			enable = val;
		}

		private void TcpListenLoop()
		{
			while(enable)
			{
				try
				{
					server = new TcpListener(System.Net.IPAddress.Any, config.port);

					server.Start();

					TcpClient adept = server.AcceptTcpClient();

					NetworkStream ns = adept.GetStream();
					ns.ReadTimeout = 1000;
					ns.WriteTimeout = 1000;

					AnkoData ndata = AnkoData.Load(ns);
					/*
					MemoryStream ms = new MemoryStream();
					byte[] resByte = new byte[256];
					int rsize = 0;
					do
					{
						rsize = ns.Read(resByte, 0, resByte.Length);
						if (rsize == 0)
						{
							break;
						}
						ms.Write(resByte, 0, rsize);
					} while (ns.DataAvailable || resByte[rsize - 1] != '\n');
					
					string resMsg = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);//*/

					adder.addTask(ndata.Message, ndata.AuthorID, ndata.AuthorName,"", this,"");

					//ms.Close();

					ns.Close();

					adept.Close();

					server.Stop();
				}
				catch { }
			}
		}

		public string getPluginName()
		{
			return "Anko";
		}

		public void close()
		{
			server.Stop();
			tcploop.Abort();
		}

		public void openConfig()
		{
			configForm cform = new configForm();
			cform.OpenSetting(config);
			config.Save("AnkoReader.config");
		}
	}

	[Serializable]
	public class AnkoData
	{
		public string AuthorID { set; get; }
		public string AuthorName { set; get; }
		public string Message { set; get; }

		public AnkoData()
		{
			this.AuthorID = "";
			this.AuthorName = "";
			this.Message = "";
		}
		
		public static AnkoData Load(Stream stream)
		{
			AnkoData configData = null;
			try
			{
				System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(AnkoData));
				configData = xs.Deserialize(stream) as AnkoData;
			}
			catch { }

			return configData != null ? configData : new AnkoData();
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
	}


	[Serializable]
	public class configs
	{
		public int port { set; get; }

		configs()
		{
			this.port = 6579;
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
