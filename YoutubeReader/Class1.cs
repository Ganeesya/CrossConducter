using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CrossConducter;
using System.Net;
using System.Text.RegularExpressions;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Xml.Serialization;
using System.IO;

namespace YoutubeReader
{
	public class YoutubeReader : CCInputInterface
	{
		TaskAdderInterface tai;
		Thread readloop;
		DateTime lasttime;
		configs configdata;
		ConfigForm cform;

		public void init(TaskAdderInterface taskadder)
		{
			tai = taskadder;
			lasttime = DateTime.Now;

			readloop = new Thread(new ThreadStart(ReadingLoop));
			readloop.Start();

			configdata = configs.Load("YoutubeReader.config");

			cform = new ConfigForm();
			cform.Copy = configdata;
		}

		public string getPluginName()
		{
			return "YoutubeLiveReader";
		}

		private void ReadingLoop()
		{
			while (true)
			{

				string videoID = "";
				try
				{
					using (WebClient webClient = new WebClient())
					{
						string str = webClient.DownloadString("https://www.youtube.com/channel/" + configdata.ChannnelID + "/videos?flow=list&live_view=501&view=2");
						//Console.Write(str);
						Match mc = Regex.Match(str, "watch\\?v=([^\\\\\\\"]+)");
						videoID = mc.Value.Replace("watch?v=", "");
					}



					var youtubeService = new YouTubeService(new BaseClientService.Initializer()
					{
						ApiKey = configdata.APIKey,
						ApplicationName = this.GetType().ToString()
					});


					var chatIDReq = youtubeService.Videos.List("liveStreamingDetails");

					chatIDReq.Id = videoID;

					var chatIDans = chatIDReq.Execute();

					var mesReq = youtubeService.LiveChatMessages.List(chatIDans.Items[0].LiveStreamingDetails.ActiveLiveChatId, "snippet");
					mesReq.MaxResults = 200;
					var mesAns = mesReq.Execute();
					

					//textBox1.Text = channelans.ToString();
					
					foreach (var e in mesAns.Items)
					{
						if (DateTime.Parse(e.Snippet.PublishedAtRaw) > lasttime)
						{
							lasttime = DateTime.Parse(e.Snippet.PublishedAtRaw);
							if (e.Snippet.TextMessageDetails != null)
							{
								var nameReq = youtubeService.Channels.List("brandingSettings");
								nameReq.Id = e.Snippet.AuthorChannelId;
								var name = nameReq.Execute();
								tai.addTask(e.Snippet.TextMessageDetails.MessageText, e.Snippet.AuthorChannelId, name.Items[0].BrandingSettings.Channel.Title,"", this,"");
							}
							else if(e.Snippet.SuperChatDetails != null)
							{
								var nameReq = youtubeService.Channels.List("brandingSettings");
								nameReq.Id = e.Snippet.AuthorChannelId;
								var name = nameReq.Execute();
								tai.addTask(e.Snippet.SuperChatDetails.UserComment, e.Snippet.AuthorChannelId, name.Items[0].BrandingSettings.Channel.Title, e.Snippet.SuperChatDetails.AmountDisplayString, this, "SuperChat");
							}
						}
					}
				}
				catch { }
				Thread.Sleep(5000);
			}
		}

		public void close()
		{
			readloop.Abort();
		}

		public void openConfig()
		{
			cform.ShowDialog();
			configdata = cform.Copy;
			configdata.Save("YoutubeReader.config");
		}		
	}

	[Serializable]
	public class configs
	{
		public string ChannnelID;
		public string APIKey;

		public configs()
		{
			ChannnelID = "放送のあるチャンネルIDを入力してください";
			APIKey = "アクセス用のGoogleAPIキーを入力してください";
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
