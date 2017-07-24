using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossConducter;
using NLua;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;

namespace Task_Lua
{
    public class Task_Lua: CCTaskControllInterface
	{
		public configs configdata;
		LuaDebug ddig = new LuaDebug();
		TaskListDataInterface tasker;
		Lua lua = new Lua();

		List<YomiageTask> addlist = new List<YomiageTask>();

		public void init(TaskListDataInterface t)
		{
			ddig.parent = this;
			configdata = configs.Load("TaskLua.config");
			ddig.updateFilename();

			tasker = t;

			lua.RegisterFunction("addTask", this, GetType().GetMethod("addTask"));
			lua.RegisterFunction("addTaskBefore", this, GetType().GetMethod("addTaskBefore"));
		}

		public string getPluginName()
		{
			return "LuaScript";
		}

		public void TaskCheck(YomiageTask ntask)
		{
			if(configdata.fileTarget == "")
			{
				return;
			}

			try
			{
				lua.DoString("task="+ toLuaTable(ntask));

				lua.DoString("list={}");
				int i = 1;
				foreach(YomiageTask ele in tasker.GetTaskList())
				{
					lua.DoString("list[" + i++ + "]=" + toLuaTable(ele));
				}
			}
			catch( NLua.Exceptions.LuaException e)
			{
				callDebudUp("precode\n"+e.Message, Color.Red);
				ddig.textBox_debug.Text = e.Message;
				ddig.textBox_debug.ForeColor = System.Drawing.Color.Red;
				return;
			}

			try
			{
				lua.DoFile(configdata.fileTarget);
			}
			catch(NLua.Exceptions.LuaException e)
			{
				callDebudUp(e.Message, Color.Red);
				//ddig.textBox_debug.Text = e.Message;
				//ddig.textBox_debug.ForeColor = System.Drawing.Color.Red;
				return;
			}

			updateTask(ntask);
			
			callDebudUp("done", Color.Black);

			//ddig.textBox_debug.Text = "done";
			//ddig.textBox_debug.ForeColor = System.Drawing.Color.Black;
		}

		private void callDebudUp(string txt, Color c)
		{
			if( ddig.InvokeRequired )
			{
				ddig.Invoke(ddig.updateDebugDel,new object[2]{ txt,c});
			}
			else
			{
				ddig.updateDebug(txt, c);
			}
		}

		private string toLuaTable(YomiageTask ntask)
		{
			return "{" +
			"srcAddinfo = \"" + ntask.srcAddinfo + "\"," +
			"authorAddinfo = \"" + ntask.authorAddinfo + "\"," +
			"AuthorID = \"" + ntask.AuthorID + "\"," +
			"AuthorName = \"" + ntask.AuthorName + "\"," +
			"Enable = \"" + ntask.Enable.ToString() + "\"," +
			"isDead = \"" + ntask.isDead.ToString() + "\"," +
			"LogTime = \"" + ntask.LogTime.ToString() + "\"," +
			"Message = \"" + Encoding.GetEncoding(932).GetString(Encoding.UTF8.GetBytes( ntask.Message)) + "\"," +
			"Outputer = \"" + ntask.Outputer.getPluginName() + "\"," +
			"QueueNum = \"" + ntask.QueueNum.ToString() + "\"," +
			"Src = \"" + ntask.Src + "\"}";
		}

		private void updateTask(YomiageTask target)
		{
			target.authorAddinfo = lua.GetString("task.authorAddinfo");
			target.Enable = lua.GetString("task.Enable") == "True";
			target.isDead = lua.GetString("task.isDead") == "True";
			target.Message = lua.GetString("task.Message");
			target.srcAddinfo = lua.GetString("task.srcAddinfo");

			foreach (CCOutputInterface e in tasker.GetOutputList())
			{
				if (e.getPluginName() == lua.GetString("task.Outputer"))
				{
					target.Outputer = e;
					break;
				}
			}
		}

		public void addTask(string mes, string id, string name, string auAd, string outCall, string srcAd)
		{
			CCOutputInterface outI = tasker.GetOutputList().First();
			foreach (CCOutputInterface e in tasker.GetOutputList())
			{
				if (e.getPluginName() == outCall)
				{
					outI = e;
					break;
				}
			}
			tasker.addTaskAfter(mes, id, name, auAd, getPluginName(), srcAd, outI);
			//addlist.Add(new YomiageTask(mes,id,name,auAd, outI, "LuaSYSTEM",srcAd,-1));
		}

		public void addTaskBefore(string mes, string id, string name, string auAd, string outCall, string srcAd)
		{
			CCOutputInterface outI = tasker.GetOutputList().First();
			foreach (CCOutputInterface e in tasker.GetOutputList())
			{
				if (e.getPluginName() == outCall)
				{
					outI = e;
					break;
				}
			}
			tasker.addTaskBefore(mes, id, name, auAd, getPluginName(), srcAd, outI);
			//addlist.Add(new YomiageTask(mes,id,name,auAd, outI, "LuaSYSTEM",srcAd,-1));
		}

		public void openConfig()
		{
			ddig.Show();
		}

		public void updateConfigTarget(string fname)
		{
			configdata.fileTarget = fname;
			configdata.Save("TaskLua.config");
		}

		public void close()
		{
			ddig.Close();
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
