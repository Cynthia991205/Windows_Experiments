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
namespace pipeServer
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
			NamedPipeClientStream pipeServer = new NamedPipeClientStream("127.0.0.1", "testpipe", PipeDirection.In);
			pipeServer.Connect();
			StreamReader sr = new StreamReader(pipeServer);
			textBox.Text = sr.ReadToEnd();
		}
	}
}
