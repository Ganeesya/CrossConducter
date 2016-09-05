using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossConducter;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace Task_Yomiyame
{
    public class Class1 : CCTaskControllInterface
	{
		configForm cForm;
		TaskListDataInterface tasker;
		public void init(TaskListDataInterface t)
		{
			tasker = t;
			cForm = new configForm();
			cForm.tasker = t;
		}

		public string getPluginName()
		{
			return "Yomiyame";
		}

		public void TaskCheck(YomiageTask ntask)
		{
			cForm.cList.tasking(ntask);
		}

		public void openConfig()
		{
			cForm.Show();
		}

		public void close()
		{
			cForm.Close();
		}
	}

	[Serializable]
	public class Condition
	{
		public bool b_Sorse;
		public string d_Sorse;
		public bool b_ID;
		public string d_ID;
		public bool b_Name_E;
		public bool b_Name_R;
		public string d_Name;
		public bool b_Mes_E;
		public bool b_Mes_R;
		public string d_Mes;		

		public override string ToString()
		{
			return (b_Sorse ? ("Souce=" + d_Sorse + " ") : "")
					+ (b_ID ? ("ID=" + d_ID + " ") : "")
					+ (b_Name_R ? ("Name in (" + d_Name + ") ") : "")
					+ ((b_Name_E & !b_Name_R) ? ("Name=" + d_Name + "") : "")
					+ (b_Mes_R ? ("Message in (" + d_Mes + ") ") : "")
					+ ((b_Mes_E & !b_Mes_R) ? ("Message=" + d_Mes + " ") : "");
		}

		public bool isHit(YomiageTask ntask)
		{
			return isSorceHit(ntask) && isIDHit(ntask) && isNameHit(ntask) && isMessageHit(ntask);
		}

		private bool isSorceHit(YomiageTask ntask)
		{
			if (!b_Sorse | d_Sorse == ntask.From)
				return true;
			return false;
		}

		private bool isIDHit(YomiageTask ntask)
		{
			if (!b_ID | d_ID == ntask.AuthorID)
				return true;
			return false;
		}

		private bool isNameHit(YomiageTask ntask)
		{
			if (b_Name_R & Regex.IsMatch(ntask.AuthorName, d_Name))
				return true;
			if (b_Name_E & !b_Name_R & d_Name == ntask.AuthorName)
				return true;
			if (!b_Name_E & !b_Name_R)
				return true;
			return false;
		}

		private bool isMessageHit(YomiageTask ntask)
		{
			if (b_Mes_R & Regex.IsMatch(ntask.Message, d_Mes))
				return true;
			if (b_Mes_E & !b_Mes_R & d_Mes == ntask.Message)
				return true;
			if (!b_Mes_E & !b_Mes_R)
				return true;
			return false;
		}


		public Condition Load(string path)
		{
			if (!File.Exists(path))
			{
				return new Condition();
			}

			using (FileStream fs = new FileStream(path, FileMode.Open))
			{
				return Load(fs);
			}
		}

		public Condition Load(Stream stream)
		{
			Condition configData = null;
			try
			{
				System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(Condition));
				configData = xs.Deserialize(stream) as Condition;
			}
			catch { }

			return configData != null ? configData : new Condition();
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

	[Serializable]
	public class ConditonList
	{
		public List<Condition> clist;

		public void tasking(YomiageTask ntask)
		{
			foreach (Condition e in clist)
			{
				if (e.isHit(ntask))
				{
					ntask.Enable = false;
					return;
				}
			}
		}

		public ConditonList()
		{
			clist = new List<Condition>();
		}

		public static ConditonList Load(string path)
		{
			if (!File.Exists(path))
			{
				return new ConditonList();
			}

			using (FileStream fs = new FileStream(path, FileMode.Open))
			{
				return Load(fs);
			}
		}

		public static ConditonList Load(Stream stream)
		{
			ConditonList configData = null;
			try
			{
				System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(ConditonList));
				configData = xs.Deserialize(stream) as ConditonList;
			}
			catch { }

			return configData != null ? configData : new ConditonList();
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
