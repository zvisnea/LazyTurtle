using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LazyTurtle
{
	
	static class Program
	{
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetProcessDPIAware();
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//SetProcessDPIAware(); // too slow
			Application.Run(new Form1());
		}
	}
}
