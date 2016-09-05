using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace CrossConducter
{
	public class Tasker : TaskAdderInterface, TaskListDataInterface
	{
		private Queue<YomiageTask> queue;
		private Thread workThread;
		private List<CCInputInterface> inputers = new List<CCInputInterface>();
		private List<CCOutputInterface> outputers = new List<CCOutputInterface>();
		private List<CCTaskControllInterface> taskcontrollers = new List<CCTaskControllInterface>();
		private YomiageTask nowtask;
		public Stack<YomiageTask> log = new Stack<YomiageTask>();

		public YomiageTask NowTask
		{
			get { return nowtask; }
		}

		public void init()
		{
			queue = new Queue<YomiageTask>();
			loadPlugins();

			workThread = new Thread(new ThreadStart(outputLoop));
			workThread.Start();
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
				nowtask.LogTime = DateTime.Now;
				log.Push(nowtask);
				nowtask.DoOutput();
								
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
			YomiageTask ntask = new YomiageTask(message, autherID, autherName, def,adder.getPluginName());

			foreach(CCTaskControllInterface e in taskcontrollers)
			{
				e.TaskCheck(ntask);
			}

			queue.Enqueue(ntask);
		}

		public void addTaskTester(string message, string autherID, string autherName,string adder,CCOutputInterface outer)
		{
			YomiageTask ntask = new YomiageTask(message, autherID, autherName, outer, adder);
			queue.Enqueue(ntask);
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

		public YomiageTask(string mes, string id, string name, CCOutputInterface def,string f)
		{
			enable = true;
			message = mes;
			authorID = id;
			authorName = name;
			outputter = def;
			from = f;
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

		public void DoOutput()
		{
			if (!outputter.isEnable())
				return;

			while(outputter.isBusy())
			{
				Thread.Sleep(1000);
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
