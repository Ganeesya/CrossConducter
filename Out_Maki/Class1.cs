using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CrossConducter;
using System.Runtime.InteropServices;
using VoiceRoidCore;

namespace Out_Maki
{
    public class OutMaki : VoiRoCore
	{
		public OutMaki() : base ("VOICEROID＋ 民安ともえ EX")
		{

		}

		public override void init()
		{
		}

		public override string getPluginName()
		{
			return "Maki";
		}

		//StringBuilder oldSpeed = new StringBuilder(256);
		//public void init()
		//{
		//	GetSpeedBox();
		//}

		//public string getPluginName()
		//{
		//	return "Maki";
		//}

		//public void close()
		//{
		//}

		//public bool isBusy()
		//{
		//	string tag = GetMakiButtenStat();
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

		//public void output(string mes, int speed)
		//{
		//	SendMessage(GetSpeedBox(), 0x000d, oldSpeed.Capacity, oldSpeed);

		//	SendMessage(GetSpeedBox(), 0x000c, 0, new StringBuilder((speed/100.0).ToString("N1")));
		//	SendMessage(GetSpeedBox(), 0x0100, 0xd, 0x11c0001);
		//	SendMessage(GetSpeedBox(), 0x0102, 0xd, 0x11c0001);
		//	SendMessage(GetSpeedBox(), 0x0101, 0xd, 0x11C0001);

		//	//StringBuilder sbc = new StringBuilder(256);
		//	//do
		//	//{
		//	//	SendMessage(GetSpeedBox(), 0x000d, sbc.Capacity, sbc);

		//	//} while (sbc.Length == 3);

		//	SendMessage(GetMakiTextWindow(), 0x000c, 0, new StringBuilder(mes));
		//	SendMessage(GetMakiButten(), 0x00f5, 0, 0);
		//	SendMessage(GetMakiTextWindow(), 0x000c, 0, new StringBuilder(""));


		//	SendMessage(GetSpeedBox(), 0x000c, 0, oldSpeed);

		//	Thread rt = new Thread(new ThreadStart(ReturnSpeedSet));
		//	rt.Start();		
		//}

		//public void ReturnSpeedSet()
		//{
		//	WINDOWINFO wi = new WINDOWINFO();
		//	do
		//	{
		//		GetWindowInfo(GetSpeedBox(), ref wi);
		//	} while ((wi.dwStyle & 0x08000000L) != 0);

		//	SendMessage(GetSpeedBox(), 0x0100, 0xd, 0x11c0001);
		//	SendMessage(GetSpeedBox(), 0x0102, 0xd, 0x11c0001);
		//	SendMessage(GetSpeedBox(), 0x0101, 0xd, 0x11C0001);
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

		//[StructLayout(LayoutKind.Sequential)]
		//public struct RECT
		//{
		//	public int Left, Top, Right, Bottom;			
		//}

		//[StructLayout(LayoutKind.Sequential)]
		//struct WINDOWINFO
		//{
		//	public uint cbSize;
		//	public RECT rcWindow;
		//	public RECT rcClient;
		//	public uint dwStyle;
		//	public uint dwExStyle;
		//	public uint dwWindowStatus;
		//	public uint cxWindowBorders;
		//	public uint cyWindowBorders;
		//	public ushort atomWindowType;
		//	public ushort wCreatorVersion;

		//	public WINDOWINFO(Boolean? filler) : this()   // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
		//	{
		//		cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
		//	}
		//}
		//	[return: MarshalAs(UnmanagedType.Bool)]
		//[DllImport("user32.dll", SetLastError = true)]
		//private static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

		//private string mainclassname = "WindowsForms10.Window.8.app.0.378734a";

		//private string richtextclassname = "WindowsForms10.RichEdit20W.app.0.378734a";

		//private string buttenclassname = "WindowsForms10.BUTTON.app.0.378734a";

		//private IntPtr GetYukariMainWindow()
		//{
		//	IntPtr r = FindWindow(mainclassname, "VOICEROID＋ 民安ともえ EX");

		//	if (r == IntPtr.Zero)
		//	{
		//		r = FindWindow(mainclassname, "VOICEROID＋ 民安ともえ EX*");
		//	}

		//	return r;
		//}

		//private IntPtr GetMakiTextWindow()
		//{
		//	IntPtr child = FindWindowEx(GetYukariMainWindow(), IntPtr.Zero, mainclassname, null);

		//	IntPtr buf = FindWindowEx(child, IntPtr.Zero, mainclassname, null);
		//	child = FindWindowEx(child, buf, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	return FindWindowEx(child, IntPtr.Zero, richtextclassname, null);
		//}

		//private IntPtr GetMakiButten()
		//{
		//	IntPtr child = FindWindowEx(GetYukariMainWindow(), IntPtr.Zero, mainclassname, null);

		//	IntPtr buf = FindWindowEx(child, IntPtr.Zero, mainclassname, null);
		//	child = FindWindowEx(child, buf, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	buf = FindWindowEx(child, IntPtr.Zero, mainclassname, null);

		//	child = FindWindowEx(child, buf, mainclassname, null);
		//	return FindWindowEx(child, IntPtr.Zero, buttenclassname, null);
		//}

		//private string GetMakiButtenStat()
		//{
		//	StringBuilder sb = new StringBuilder(256);

		//	SendMessage(GetMakiButten(), 0x000d, sb.Capacity, sb);

		//	return sb.ToString();
		//}

		//private IntPtr GetSpeedBox()
		//{
		//	IntPtr c = FindWindowEx(GetYukariMainWindow(), IntPtr.Zero, mainclassname, null);
		//	IntPtr cc = FindWindowEx(c, IntPtr.Zero, mainclassname, null);
		//	IntPtr cc2 = FindWindowEx(c, cc, mainclassname, null);
		//	IntPtr cc2c = FindWindowEx(cc2, IntPtr.Zero, mainclassname, null);
		//	IntPtr cc2cc = FindWindowEx(cc2c, IntPtr.Zero, mainclassname, null);
		//	IntPtr cc2cc2 = FindWindowEx(cc2c, cc2cc, mainclassname, null);
		//	IntPtr tab = FindWindowEx(cc2cc2, IntPtr.Zero, "WindowsForms10.SysTabControl32.app.0.378734a", null);
		//	if (tab == IntPtr.Zero)
		//	{
		//		return IntPtr.Zero;
		//	}
		//	IntPtr tabc = FindWindowEx(tab, IntPtr.Zero, mainclassname, "音声効果");
		//	while(tabc == IntPtr.Zero)
		//	{
		//		SendMessage(tab, 0x0201, 0x1, 0x800b7);
		//		Thread.Sleep(100);
		//		tabc = FindWindowEx(tab, IntPtr.Zero, mainclassname, "音声効果");
		//	}
		//	IntPtr tabc2c = FindWindowEx(tabc, IntPtr.Zero, mainclassname, null);
		//	IntPtr edit1 = FindWindowEx(tabc2c, IntPtr.Zero, "WindowsForms10.EDIT.app.0.378734a", null);
		//	IntPtr edit2 = FindWindowEx(tabc2c, edit1, "WindowsForms10.EDIT.app.0.378734a", null);
		//	IntPtr edit3 = FindWindowEx(tabc2c, edit2, "WindowsForms10.EDIT.app.0.378734a", null);

		//	return edit3;
		//}

		//public void openConfig()
		//{

		//}
	}
}
