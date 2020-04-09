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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Pipes;
using System.IO;

namespace pipe
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

		private void button_Click(object sender, RoutedEventArgs e)
		{
			NamedPipeServerStream pipeClient = new NamedPipeServerStream("testpipe", PipeDirection.Out);
			pipeClient.WaitForConnection();

			try
			{
				StreamWriter sw = new StreamWriter(pipeClient);
				sw.AutoFlush = true;
				sw.WriteLine("Message passed by pipeline");
				sw.WriteLine("11111");
				sw.WriteLine("22222");
				sw.WriteLine("33333");
				sw.Close();
				textBox.Text += "连接成功，消息已经发送";
			}
			catch (IOException error)
			{
				MessageBox.Show(error.ToString());

			}
		}
	}
}
