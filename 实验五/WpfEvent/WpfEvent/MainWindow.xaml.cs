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

namespace WpfEvent
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		Publisher publisher;
		public MainWindow()
		{
			InitializeComponent();
			publisher = new Publisher();
		}
		private void btnTest_Click(object sender, RoutedEventArgs e)
		{
			publisher.myEvent += new Publisher.MyEventHandler(test);
			textBox1.Text += "注册test函数\r\n";
		}

		private void test()
		{
			textBox1.Text += "执行test\r\n";
		}

		private void btnDeleteTest_Click(object sender, RoutedEventArgs e)
		{
			publisher.myEvent -= new Publisher.MyEventHandler(test);
			textBox1.Text += "删除test函数\r\n";
		}

		private void btnReach_Click(object sender, RoutedEventArgs e)
		{
			textBox1.Text += "事件被触发了!\r\n";
			publisher.myEventReached();
		}
	}

	class Publisher
	{
		public delegate void MyEventHandler();

		public event MyEventHandler myEvent;
		


		public void myEventReached()
		{
			if (myEvent != null)
			{
				myEvent();//触发事件
			}
			else
			{
				MessageBox.Show("未注册函数");
			}

		}

	}

}

