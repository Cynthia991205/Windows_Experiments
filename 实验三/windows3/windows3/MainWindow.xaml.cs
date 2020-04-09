using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace windows3
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void getMac(object sender, RoutedEventArgs e)
		{

			string strCmd = "getmac";
			RedirectCMD(strCmd);


		}
		private void shutDown(object sender, RoutedEventArgs e)
		{
			string strCmd = "shutdown";
			RedirectCMD(strCmd);
		}

		// 调用CMD命令并重定向
		private void RedirectCMD(string command)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			// 是否使用外壳程序   
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			// 重定向输入输出流  
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			
			try
			{
				process.Start();
				process.StandardInput.WriteLine(command);
				process.StandardInput.WriteLine("exit");
				//  Console.WriteLine("开始执行");
				process.OutputDataReceived += (s, _e) => AppendResult(_e.Data);
				// 退出时的回调函数，恢复按钮
				process.Exited += (s, _e) => getmac.Dispatcher.BeginInvoke(new Action(() => getmac.IsEnabled = true));
				process.EnableRaisingEvents = true;
				process.BeginOutputReadLine();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private void AppendResult(string data)
		{
			result.Dispatcher.BeginInvoke(new Action(() => result.AppendText(data + "\n")));
		}

		
	}
}
