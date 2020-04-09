using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using CopyDataStruct;

namespace WpfMessage
{
	/// <summary>
	/// SubWindow.xaml 的交互逻辑
	/// </summary>
	/// 

	public partial class wpf2 : Window
	{
		const int BM_CLICK = 0xF5;

		[DllImport("User32.dll", EntryPoint = "SendMessage")]
		private static extern int SendMessage(int hWnd, int Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

		[DllImport("User32.dll", EntryPoint = "FindWindow")]
		private static extern int FindWindow(string lpClassName, string lpWindowName);

		public wpf2()
		{
			InitializeComponent();
		}

		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
			source.AddHook(WndProc);
		}

		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			// Handle messages...
			const int BM_CLICK = 0xF5;

			if (msg == BM_CLICK)
			{
				COPYDATASTRUCT cds = new COPYDATASTRUCT();
				Type t = cds.GetType();
				cds = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT)); ;
				string strResult = cds.dwData.ToString() + ":" + cds.lpData;
				message.Text += strResult;
				message.Text += "\r\n";
			}
			return IntPtr.Zero;
		}


		private void SendMessage(string pcReceiveForm)
		{
			int WINDOW_HANDLER = FindWindow(null, pcReceiveForm);
			if (WINDOW_HANDLER != 0)
			{
				try
				{
					byte[] sarr = System.Text.Encoding.Default.GetBytes(stringText.Text);
					int len = sarr.Length;
					COPYDATASTRUCT cds;
					cds.dwData = (IntPtr)Convert.ToInt32(intText.Text);//可以是任意值
					cds.cbData = len + 1;//指定lpData内存区域的字节数
					cds.lpData = stringText.Text;//发送给目标窗口所在进程的数据

					SendMessage(WINDOW_HANDLER, BM_CLICK, IntPtr.Zero, ref cds);
				}
				catch (Exception exce)
				{
					MessageBox.Show(exce.ToString());
				}
			}
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			SendMessage("MainWindow");
		}

	}
}
