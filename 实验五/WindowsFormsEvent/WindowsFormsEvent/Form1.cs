using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEvent
{
	public partial class Form1 : Form
	{
		Publisher publisher;
		public Form1()
		{
			InitializeComponent();
			publisher = new Publisher();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			publisher.myEvent += new Publisher.MyEventHandler(test);
			textBox1.Text += "注册test函数\r\n";
		}
		private void test()
		{
			textBox1.Text += "执行test\r\n";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox1.Text += "事件被触发了!\r\n";
			publisher.myEventReached();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			publisher.myEvent -= new Publisher.MyEventHandler(test);
			textBox1.Text += "删除test函数\r\n";
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
}
