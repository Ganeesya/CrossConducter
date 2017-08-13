using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace CrossConducter
{
	public class Tasker : TaskAdderInterface, TaskListDataInterface
	{
		private Queue<YomiageTask> queue;
		private long lastQueueCode = 0;
		private Thread workThread;
		private List<CCInputInterface> inputers = new List<CCInputInterface>();
		private List<CCOutputInterface> outputers = new List<CCOutputInterface>();
		private List<CCTaskControllInterface> taskcontrollers = new List<CCTaskControllInterface>();
		private YomiageTask nowtask;
		public Stack<YomiageTask> log = new Stack<YomiageTask>();

		private List<YomiageTask> afterAddTasks;

		delegate void addingTaskDelegate(ListViewItem adder);

		internal void addingTask(ListViewItem adder)
		{
			taskListv.Items.Add(adder);
		}

		private ListView taskListv;

		public YomiageTask NowTask
		{
			get { return nowtask; }
		}

		public void init(ListView taskListview)
		{
			queue = new Queue<YomiageTask>();
			afterAddTasks = new List<YomiageTask>();

			loadPlugins();

			workThread = new Thread(new ThreadStart(outputLoop));
			workThread.Start();

			taskListv = taskListview;
		}

		private void loadPlugins()
		{
			foreach (string dll in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll"))
			{
				try
				{
					System.Reflection.Assembly asm =
						System.Reflection.Assembly.LoadFile(dll);
					
					foreach (Type t in asm.GetTypes())
					{
						if (t.IsClass && t.IsPublic && !t.IsAbstract &&
							t.GetInterface(typeof(CCInputInterface).FullName) != null)
						{
							CCInputInterface iplug = (CCInputInterface)asm.CreateInstance(t.FullName);
							iplug.init(this);
							inputers.Add(iplug);
						}
						if (t.IsClass && t.IsPublic && !t.IsAbstract &&
							t.GetInterface(typeof(CCOutputInterface).FullName) != null)
						{
							CCOutputInterface oplug = (CCOutputInterface)asm.CreateInstance(t.FullName);
							oplug.init();
							outputers.Add(oplug);
						}
						if (t.IsClass && t.IsPublic && !t.IsAbstract &&
							t.GetInterface(typeof(CCTaskControllInterface).FullName) != null)
						{
							CCTaskControllInterface tplug = (CCTaskControllInterface)asm.CreateInstance(t.FullName);
							tplug.init(this);
							taskcontrollers.Add(tplug);
						}
					}
				}
				catch (Exception e)
				{
					//System.IO.File.AppendAllText("loadlog.txt", "catch error" + e.Message + "\n");
				}
			}
		}

		private void outputLoop()
		{
			while(true)
			{
				doOutput();
			}
		}

		private void doOutput()
		{
			while (true)
			{
				if(queue.Count == 0 )
				{
					Thread.Sleep(100);
					break;
				}
				nowtask = queue.Dequeue();
				if (nowtask == null)
				{
					continue;
				}

				nowtask.listviewlinkitem.BackColor = System.Drawing.Color.Pink;
				nowtask.LogTime = DateTime.Now;
				foreach (CCTaskControllInterface e in taskcontrollers)
				{
					e.TaskCheck(nowtask, true);
				}

				if (!nowtask.Enable)
				{
					logPushing(nowtask);
					nowtask.isDead = true;
					continue;
				}
				logPushing(nowtask);
				nowtask.DoOutput();
				nowtask.isDead = true;

				nowtask = null;
				break;
			}
		}

		private void logPushing(YomiageTask ntask)
		{
			using (StreamWriter sw = new StreamWriter("log.txt", true))
			{
				sw.WriteLine(ntask.makeLog());
			}
			log.Push(ntask);
		}

		public void close()
		{
			foreach (CCInputInterface e in inputers)
			{
				e.close();
			}
			foreach (CCOutputInterface e in outputers)
			{
				e.close();
			}
			foreach (CCTaskControllInterface e in taskcontrollers)
			{
				e.close();
			}
			workThread.Abort();
		}

		public void addTask(string message, string autherID, string autherName, string autherAddinfo, CCInputInterface adder, string adderAddinfo)
		{
			CCOutputInterface def = null;


			if(outputers.Count > 0)
			{
				def = outputers[0];
			}
			string srcName = "";
			if (adder != null)
				srcName = adder.getPluginName();
			
			YomiageTask ntask = new YomiageTask(message, autherID, autherName, autherAddinfo, def, srcName, adderAddinfo,lastQueueCode++);

			foreach(CCTaskControllInterface e in taskcontrollers)
			{
				e.TaskCheck(ntask,false);
			}

			ntask.updateListItem();
			queue.Enqueue(ntask);

			if (taskListv.InvokeRequired)
			{
				taskListv.Invoke(new addingTaskDelegate(addingTask), ntask.listviewlinkitem);
			}
			else
			{
				taskListv.Items.Add(ntask.listviewlinkitem);
			}

			afterStackExcute();
			//taskListv.Items.Add(ntask.listviewlinkitem);
		}

		private void afterStackExcute()
		{
			foreach(var ele in afterAddTasks)
			{
				ele.updateListItem();
				queue.Enqueue(ele);

				if (taskListv.InvokeRequired)
				{
					taskListv.Invoke(new addingTaskDelegate(addingTask), ele.listviewlinkitem);
				}
				else
				{
					taskListv.Items.Add(ele.listviewlinkitem);
				}
			}

			afterAddTasks.Clear();
		}

		public void addTaskAfter(string message, string autherID, string autherName, string auAd, string src, string srcAdd, CCOutputInterface outer)
		{

			YomiageTask ntask = new YomiageTask(message, autherID, autherName, auAd, outer, src, srcAdd, lastQueueCode++);

			afterAddTasks.Add(ntask);
		}

		public void addTaskBefore(string message, string autherID, string autherName, string auAd, string src, string srcAdd, CCOutputInterface outer)
		{
			YomiageTask ntask = new YomiageTask(message, autherID, autherName, auAd, outer, src, srcAdd, lastQueueCode++);
			ntask.updateListItem();
			queue.Enqueue(ntask);

			if (taskListv.InvokeRequired)
			{
				taskListv.Invoke(new addingTaskDelegate(addingTask), ntask.listviewlinkitem);
			}
			else
			{
				taskListv.Items.Add(ntask.listviewlinkitem);
			}
		}

		public void addTaskTester(string message, string autherID, string autherName, string auAd, string src,string srcAdd,CCOutputInterface outer)
		{
			YomiageTask ntask = new YomiageTask(message, autherID, autherName, auAd, outer, src, srcAdd, lastQueueCode++);
			ntask.updateListItem();
			queue.Enqueue(ntask);

			if (taskListv.InvokeRequired)
			{
				taskListv.Invoke(new addingTaskDelegate(addingTask), ntask.listviewlinkitem);
			}
			else
			{
				taskListv.Items.Add(ntask.listviewlinkitem);
			}
			//taskListv.Items.Add(ntask.listviewlinkitem);
		}

		public List<CCOutputInterface> GetOutputList()
		{
			return outputers;
		}

		public List<CCInputInterface> GetInputList()
		{
			return inputers;
		}

		public List<CCTaskControllInterface> GetTaskControllList()
		{
			return taskcontrollers;
		}

		public List<YomiageTask> GetTaskList()
		{
			return queue.ToList();
		}
	}

	public class YomiageTask
	{
		private bool enable;
		private string message;
		private string authorID;
		private string authorName;
		private CCOutputInterface outputter;
		private string src;
		private DateTime logtime;
		private long queuenum;
		public ListViewItem listviewlinkitem;
		public bool isDead;
		public string authorAddinfo;
		public string srcAddinfo;
		public int Speed;

		public YomiageTask(string mes, string id, string name,string auAd, CCOutputInterface def,string fromsrc,string srcaddinfo,long qnum)
		{
			enable = true;
			message = mes;
			authorID = id;
			authorName = name;
			outputter = def;
			src = fromsrc;
			queuenum = qnum;
			listviewlinkitem = new ListViewItem(new string[7]{ "1","2","3","4","5","6","7"});
			isDead = false;
			authorAddinfo = auAd;
			srcAddinfo = srcaddinfo;
			Speed = 100;
		}

		public string makeLog()
		{
			return (enable ? "!" : "#") + src + "(" + srcAddinfo + ")\t>>\t" + logtime.ToString() + "\tsay(" +outputter.getPluginName() + ")\t"+ authorName + "(" + authorID + "):" + authorAddinfo + "\t" + message;
		}

		public void updateListItem()
		{
			listviewlinkitem.SubItems[0].Text = src;
			listviewlinkitem.SubItems[1].Text = srcAddinfo;
			listviewlinkitem.SubItems[2].Text = authorName;
			listviewlinkitem.SubItems[3].Text = authorID;
			listviewlinkitem.SubItems[4].Text = authorAddinfo;
			listviewlinkitem.SubItems[5].Text = message;
			listviewlinkitem.SubItems[6].Text = outputter.getPluginName();
			listviewlinkitem.Tag = this;
		}

		public bool Enable
		{
			set { this.enable = value; }
			get { return this.enable; }
		}
		public string Message
		{
			set { this.message = value; }
			get { return this.message; }
		}
		public string AuthorID
		{
			get { return this.authorID; }
		}
		public string AuthorName
		{
			get { return this.authorName; }
		}
		public CCOutputInterface Outputer
		{
			set { this.outputter = value; }
			get { return this.outputter; }
		}
		public long QueueNum
		{
			get { return this.queuenum; }
		}

		public void DoOutput()
		{
			if (!outputter.isEnable())
				return;

			while(outputter.isBusy())
			{
				Thread.Sleep(500);
			}

			outputter.output(message,Speed);

			DateTime starttime = DateTime.Now;

			while (!outputter.isBusy())
			{
				Thread.Sleep(100);
				if(starttime.AddSeconds(2) < DateTime.Now)
				{
					break;
				}
			}

			while (outputter.isBusy())
			{
				Thread.Sleep(100);
			}
		}

		public string Src
		{
			get { return src; }
		}

		public DateTime LogTime
		{
			set { logtime = value; }
			get { return logtime; }
		}
	}
}
