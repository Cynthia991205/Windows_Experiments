using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

using System.Windows.Threading;

namespace WpfProducerConsumer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
		static readonly int bufferSize = 10;
		static int number = 0;//产品数量
		Mutex mutex;
		Semaphore fullBuffer;
		Semaphore emptyBuffer;

		public MainWindow()
        {
            InitializeComponent();
			mutex = new Mutex();
			fullBuffer = new Semaphore(0, bufferSize);
			emptyBuffer = new Semaphore(bufferSize, bufferSize);
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			int producerNum = Convert.ToInt32(textProducer.Text);
			int consumerNum = Convert.ToInt32(textConsumer.Text);

			for (int i = 0; i < producerNum; i++)
			{
				Thread produceth = new Thread(Produce);
				produceth.Name = "生产者" + (i + 1).ToString();
				produceth.Start();

			}
			for (int i = 0; i < consumerNum; i++)
			{
				Thread consumerth = new Thread(Consume);
				consumerth.Name = "消费者" + (i + 1).ToString();
				consumerth.Start();

			}
		}

		private void Produce()
		{
			while (true)
			{
				// 还有生产权限时，进入下面的代码
				emptyBuffer.WaitOne();
				mutex.WaitOne();
				// 将产品放入buffer中
				number++;
				Console.WriteLine(Thread.CurrentThread.Name + "生产了一个产品，当前产品量：" + number.ToString() + "\n");
				Dispatcher.BeginInvoke(DispatcherPriority.Normal, new updateTextDelegate(setProducerText), Thread.CurrentThread.Name, number);
				//Dispatcher.BeginInvoke(DispatcherPriority.Normal, new updateTextDelegate(setProducerText), number);
				mutex.ReleaseMutex();
				// 释放一个拿去权限
				fullBuffer.Release();
				Thread.Sleep(TimeSpan.FromSeconds(2));
			}
		}

		private void Consume()
		{
			while (true)
			{
				// 等待一个拿去权限
				fullBuffer.WaitOne();
				mutex.WaitOne();
				// 移除一个物品
				number--;
				Console.WriteLine(Thread.CurrentThread.Name + "消费了一个产品，当前产品量：" + number.ToString() + "\n");
				Dispatcher.BeginInvoke(new updateTextDelegate(setConsumerText), Thread.CurrentThread.Name, number);
				mutex.ReleaseMutex();
				// 释放一个生产权限
				emptyBuffer.Release();
				Thread.Sleep(TimeSpan.FromSeconds(3));
			}
		}


		//更改text内容
		public delegate void updateTextDelegate(string name, int number);//定义委托
		public void setConsumerText(string name, int number)//执行这个算法，并且更新文本框内容
		{
			textState.Text += name + "消费了一个产品，当前产品量：" + number.ToString() + "\n";
		}
		public void setProducerText(string name, int number)//执行这个算法，并且更新文本框内容
		{
			textState.Text += name + "生产了一个产品，当前产品量：" + number.ToString() + "\n";
		}
	}

}
