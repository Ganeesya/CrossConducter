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
					Thread.Sleep(10);
					break;
				}
				nowtask = queue.Dequeue();
				if (nowtask == null)
				{
					continue;
				}
				if (!nowtask.Enable)
				{
					continue;
				}
				nowtask.listviewlinkitem.BackColor = System.Drawing.Color.Pink;
				nowtask.LogTime = DateTime.Now;
				log.Push(nowtask);
				nowtask.DoOutput();
				nowtask.isDead = true;

				nowtask = null;
				break;
			}
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

		public void addTask(string message, string autherID, string autherName, CCInputInterface adder)
		{
			CCOutputInterface def = null;
			if(outputers.Count > 0)
			{
				def = outputers[0];
			}
			YomiageTask ntask = new YomiageTask(message, autherID, autherName, def,adder.getPluginName(),lastQueueCode++);

			foreach(CCTaskControllInterface e in taskcontrollers)
			{
				e.TaskCheck(ntask);
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
			//taskListv.Items.Add(ntask.listviewlinkitem);
		}

		public void addTaskTester(string message, string autherID, string autherName,string adder,CCOutputInterface outer)
		{
			YomiageTask ntask = new YomiageTask(message, autherID, autherName, outer, adder,lastQueueCode++);
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
		private string from;
		private DateTime logtime;
		private long queuenum;
		public ListViewItem listviewlinkitem;
		public bool isDead;

		public YomiageTask(string mes, string id, string name, CCOutputInterface def,string f,long qnum)
		{
			enable = true;
			message = mes;
			authorID = id;
			authorName = name;
			outputter = def;
			from = f;
			queuenum = qnum;
			listviewlinkitem = new ListViewItem(new string[5]{ "1","2","3","4","5"});
			isDead = false;
		}



		public void updateListItem()
		{
			listviewlinkitem.SubItems[0].Text = from;
			listviewlinkitem.SubItems[1].Text = authorName;
			listviewlinkitem.SubItems[2].Text = authorID;
			listviewlinkitem.SubItems[3].Text = message;
			listviewlinkitem.SubItems[4].Text = outputter.getPluginName();
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

			outputter.output(message);

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

		public string From
		{
			get { return from; }
		}

		public DateTime LogTime
		{
			set { logtime = value; }
			get { return logtime; }
		}
	}
}
