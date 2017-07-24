using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CrossConducter;
using System.Runtime.InteropServices;
using VoiceroidConfigForm;

namespace VoiceRoidCore
{
    abstract public class VoiRoCore : CCOutputInterface
	{
		StringBuilder oldSpeed = new StringBuilder(256);
		VoiceroidConfigForm.VoiceroidConfigForm form;

		public VoiRoCore(string title)
		{
			form = new VoiceroidConfigForm.VoiceroidConfigForm(title);
		}

		abstract public void init();

		abstract public string getPluginName();

		public void close()
		{
		}

		public bool isBusy()
		{
			string tag = GetButtenStat();
			if (tag == " 再生" | tag == "")
				return false;
			else
				return true;
		}

		public bool isEnable()
		{
			if (GetMainWindow() == IntPtr.Zero)
			{
				return false;
			}
			return true;
		}

		public void output(string mes, int speed)
		{
			SendMessage(GetSpeedBox(), 0x000d, oldSpeed.Capacity, oldSpeed);

			SendMessage(GetSpeedBox(), 0x000c, 0, new StringBuilder((speed / 100.0).ToString("N1")));
			SendMessage(GetSpeedBox(), 0x0100, 0xd, 0x11c0001);
			SendMessage(GetSpeedBox(), 0x0102, 0xd, 0x11c0001);
			SendMessage(GetSpeedBox(), 0x0101, 0xd, 0x11C0001);
			
			SendMessage(GetTextWindow(), 0x000c, 0, new StringBuilder(mes));
			SendMessage(GetButten(), 0x00f5, 0, 0);
			SendMessage(GetTextWindow(), 0x000c, 0, new StringBuilder(""));

			SendMessage(GetSpeedBox(), 0x000c, 0, oldSpeed);

			Thread rt = new Thread(new ThreadStart(ReturnSpeedSet));
			rt.Start();
		}

		public void ReturnSpeedSet()
		{
			WINDOWINFO wi = new WINDOWINFO();
			do
			{
				GetWindowInfo(GetSpeedBox(), ref wi);
			} while ((wi.dwStyle & 0x08000000L) != 0);

			SendMessage(GetSpeedBox(), 0x0100, 0xd, 0x11c0001);
			SendMessage(GetSpeedBox(), 0x0102, 0xd, 0x11c0001);
			SendMessage(GetSpeedBox(), 0x0101, 0xd, 0x11C0001);
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

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left, Top, Right, Bottom;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct WINDOWINFO
		{
			public uint cbSize;
			public RECT rcWindow;
			public RECT rcClient;
			public uint dwStyle;
			public uint dwExStyle;
			public uint dwWindowStatus;
			public uint cxWindowBorders;
			public uint cyWindowBorders;
			public ushort atomWindowType;
			public ushort wCreatorVersion;

			public WINDOWINFO(Boolean? filler) : this()   // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
			{
				cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
			}
		}
		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

		//private string mainclassname = "WindowsForms10.Window.8.app.0.378734a";

		//private string richtextclassname = "WindowsForms10.RichEdit20W.app.0.378734a";

		//private string buttenclassname = "WindowsForms10.BUTTON.app.0.378734a";

		private IntPtr GetMainWindow()
		{
			IntPtr r = FindWindow(form.config.mainclassname, form.config.titlename);

			if (r == IntPtr.Zero)
			{
				r = FindWindow(form.config.mainclassname, form.config.titlename+"*");
			}

			return r;
		}

		private IntPtr GetTextWindow()
		{
			IntPtr child = FindWindowEx(GetMainWindow(), IntPtr.Zero, form.config.mainclassname, null);

			IntPtr buf = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);
			child = FindWindowEx(child, buf, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			return FindWindowEx(child, IntPtr.Zero, form.config.richtextclassname, null);
		}

		private IntPtr GetButten()
		{
			IntPtr child = FindWindowEx(GetMainWindow(), IntPtr.Zero, form.config.mainclassname, null);

			IntPtr buf = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);
			child = FindWindowEx(child, buf, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			buf = FindWindowEx(child, IntPtr.Zero, form.config.mainclassname, null);

			child = FindWindowEx(child, buf, form.config.mainclassname, null);
			return FindWindowEx(child, IntPtr.Zero, form.config.buttenclassname, null);
		}

		private string GetButtenStat()
		{
			StringBuilder sb = new StringBuilder(256);

			SendMessage(GetButten(), 0x000d, sb.Capacity, sb);

			return sb.ToString();
		}

		private IntPtr GetSpeedBox()
		{
			IntPtr c = FindWindowEx(GetMainWindow(), IntPtr.Zero, form.config.mainclassname, null);
			IntPtr cc = FindWindowEx(c, IntPtr.Zero, form.config.mainclassname, null);
			IntPtr cc2 = FindWindowEx(c, cc, form.config.mainclassname, null);
			IntPtr cc2c = FindWindowEx(cc2, IntPtr.Zero, form.config.mainclassname, null);
			IntPtr cc2cc = FindWindowEx(cc2c, IntPtr.Zero, form.config.mainclassname, null);
			IntPtr cc2cc2 = FindWindowEx(cc2c, cc2cc, form.config.mainclassname, null);
			IntPtr tab = FindWindowEx(cc2cc2, IntPtr.Zero, form.config.tabclassname, null);
			if (tab == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			IntPtr tabc = FindWindowEx(tab, IntPtr.Zero, form.config.mainclassname, "音声効果");
			while (tabc == IntPtr.Zero)
			{
				SendMessage(tab, 0x0201, 0x1, 0x800b7);
				Thread.Sleep(100);
				tabc = FindWindowEx(tab, IntPtr.Zero, form.config.mainclassname, "音声効果");
			}
			IntPtr tabc2c = FindWindowEx(tabc, IntPtr.Zero, form.config.mainclassname, null);
			IntPtr edit1 = FindWindowEx(tabc2c, IntPtr.Zero, form.config.editboxclassname, null);
			IntPtr edit2 = FindWindowEx(tabc2c, edit1, form.config.editboxclassname, null);
			IntPtr edit3 = FindWindowEx(tabc2c, edit2, form.config.editboxclassname, null);

			return edit3;
		}

		public void openConfig()
		{
			form.Show();
		}
	}
}
