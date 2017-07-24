using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossConducter;
using System.Runtime.InteropServices;
using VoiceRoidCore;

namespace Out_Aoi
{
    public class OutAoi : VoiRoCore
	{
		public OutAoi() : base ("VOICEROID＋ 琴葉葵")
		{

		}

		public override void init()
		{
		}

		public override string getPluginName()
		{
			return "Aoi";
		}

		//private VoiceroidConfigForm.VoiceroidConfigForm form;

		//public void init()
		//{
		//	form = new VoiceroidConfigForm.VoiceroidConfigForm();
		//}

		//public string getPluginName()
		//{
		//	return "Aoi";
		//}

		//public void close()
		//{
		//}

		//public bool isBusy()
		//{
		//	string tag = GetAoiButtenStat();
		//	if (tag == " 再生" | tag == "")
		//		return false;
		//	else
		//		return true;
		//}

		//public bool isEnable()
		//{
		//	if (GetYukariMainWindow() == IntPtr.Zero)
		//	{
		//		return false;
		//	}
		//	return true;
		//}

		//public void output(string mes,int speed)
		//{
		//	SendMessage(GetAoiTextWindow(), 0x000c, 0, new StringBuilder(mes));
		//	SendMessage(GetAoiButten(), 0x00f5, 0, 0);
		//	SendMessage(GetAoiTextWindow(), 0x000c, 0, new StringBuilder(""));
		//}

		//[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		//public static extern IntPtr FindWindow(
		//	string lpClassName, string lpWindowName);

		//[DllImport("user32.dll", SetLastError = true)]
		//static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		//[DllImport("user32.dll", CharSet = CharSet.Auto)]
		//static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, StringBuilder lParam);

		//[DllImport("user32.dll", CharSet = CharSet.Auto)]
		//static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

		//private IntPtr GetYukariMainWindow()
		//{
		//	IntPtr r = FindWindow(form.config.mainclassname, form.config.titlename);

		//	if (r == IntPtr.Zero)
		//	{
		//		r = FindWindow(form.config.mainclassname, form.config.titlename+"*");
		//	}

		//	return r;
		//}

		//private IntPtr GetAoiTextWindow()
		//{
		//	IntPtr child = FindWindowEx(GetYukariMainWindow(), IntPtr.Zero, form.config.mainclassname, null);

		//	IntPtr buf = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);
		//	child = FindWindowEx(child, buf, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	return FindWindowEx(child, IntPtr.Zero, form.config.richtextclassname, null);
		//}

		//private IntPtr GetAoiButten()
		//{
		//	IntPtr child = FindWindowEx(GetYukariMainWindow(), IntPtr.Zero, form.config.mainclassname, null);

		//	IntPtr buf = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);
		//	child = FindWindowEx(child, buf, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	buf = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

		//	child = FindWindowEx(child, buf, form.config.mainclassname, null);
		//	return FindWindowEx(child, IntPtr.Zero, form.config.buttenclassname, null);
		//}

		//private string GetAoiButtenStat()
		//{
		//	StringBuilder sb = new StringBuilder(256);

		//	SendMessage(GetAoiButten(), 0x000d, sb.Capacity, sb);

		//	return sb.ToString();
		//}

		//public void openConfig()
		//{
		//	form.ShowDialog();
		//}
	}
}
