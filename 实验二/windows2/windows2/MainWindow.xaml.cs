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
using System.Runtime.InteropServices;
using System.Reflection;
using MyCom;
using System.IO;

namespace windows2
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		//private const string CLSID = "9908C3F1-7AC0-4CF2-9D9E-0638D99826B8";
		
		public MainWindow()
		{
			InitializeComponent();

		}

		private void buttonAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				int opcode1 = Convert.ToInt32(textBox.Text);
				int opcode2 = Convert.ToInt32(textBox1.Text);


				Class1 wo = new Class1();
				var result= wo.Add(opcode1,opcode2);

				textBox8.Text = result.ToString();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
		}

		private void buttonSub_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int opcode1 = Convert.ToInt32(textBox2.Text);
				int opcode2 = Convert.ToInt32(textBox3.Text);
				Class1 wo = new Class1();
				var result = wo.Subtract(opcode1, opcode2);

				textBox9.Text = result.ToString();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
		}

		private void buttonMul_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				int opcode1 = Convert.ToInt32(textBox4.Text);
				int opcode2 = Convert.ToInt32(textBox5.Text);
				Class1 wo = new Class1();
				var result = wo.Multiply(opcode1, opcode2);

				textBox10.Text = result.ToString();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
		}

		private void buttonDiv_Click(object sender, RoutedEventArgs e)
		{
			try
			{
	
				double opcode1 = Convert.ToDouble(textBox6.Text);
				double opcode2 = Convert.ToDouble(textBox7.Text);
				Class1 wo = new Class1();
				var result = wo.Divide(opcode1, opcode2);

				textBox11.Text = result.ToString();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
		}



	}
}
