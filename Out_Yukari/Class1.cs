using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossConducter;
using System.Runtime.InteropServices;

namespace Out_Yukari
{
    public class OutYukari : CCOutputInterface
	{
		public void init()
		{
		}

		public string getPluginName()
		{
			return "Yukari";
		}

		public void close()
		{
		}

		public bool isBusy()
		{
			string tag = GetYukariButtenStat();
			if (tag == " 再生" | tag == "")
				return false;
			else
				return true;
		}

		public bool isEnable()
		{
			if (GetYukariMainWindow() == IntPtr.Zero)
			{
				return false;
			}
			return true;
		}

		public void output(string mes)
		{
			SendMessage(GetYukariTextWindow(), 0x000c, 0, new StringBuilder(mes));
			SendMessage(GetYukariButten(), 0x00f5, 0, 0);
			SendMessage(GetYukariTextWindow(), 0x000c, 0, new StringBuilder(""));
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr FindWindow(
			string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, StringBuilder lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

		private string mainclassname = "WindowsForms10.Window.8.app.0.378734a";

		private string richtextclassname = "WindowsForms10.RichEdit20W.app.0.378734a";

		private string buttenclassname = "WindowsForms10.BUTTON.app.0.378734a";

		private IntPtr GetYukariMainWindow()
		{
			IntPtr r = FindWindow(mainclassname, "VOICEROID＋ 結月ゆかり EX");

			if (r == IntPtr.Zero)
			{
				r = FindWindow(mainclassname, "VOICEROID＋ 結月ゆかり EX*");
			}

			return r;
		}

		private IntPtr GetYukariTextWindow()
		{
			IntPtr child = FindWindowEx(GetYukariMainWindow(), IntPtr.Zero, mainclassname, null);

			IntPtr buf = FindWindowEx(child, IntPtr.Zero, mainclassname, null);
			child = FindWindowEx(child, buf, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			return FindWindowEx(child, IntPtr.Zero, richtextclassname, null);
		}

		private IntPtr GetYukariButten()
		{
			IntPtr child = FindWindowEx(GetYukariMainWindow(), IntPtr.Zero, mainclassname, null);

			IntPtr buf = FindWindowEx(child, IntPtr.Zero, mainclassname, null);
			child = FindWindowEx(child, buf, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			buf = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

			child = FindWindowEx(child, buf, mainclassname, null);
			return FindWindowEx(child, IntPtr.Zero, buttenclassname, null);
		}

		private string GetYukariButtenStat()
		{
			StringBuilder sb = new StringBuilder(256);

			SendMessage(GetYukariButten(), 0x000d, sb.Capacity, sb);

			return sb.ToString();
		}

		public void openConfig()
		{
			
		}
	}
}
