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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CSharpCreateDLL;


namespace CSharpCallDLL
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
		//引入dll
		[DllImport(@"../../../Release/CppCreateDLL.dll", EntryPoint = "test01", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
		extern static int test01(int a, int b, int c);

		[DllImport(@"../../../Release/CppCreateDLL.dll", EntryPoint = "test02", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
		extern static int test02(int a, int b);

		//调用CPP创建的DLL进行加法运算
		private void CppSum(object sender, RoutedEventArgs e)
		{
			var a = this.a.Text;
			var b = this.b.Text;
			var c = this.c.Text;
			int r1 = test01(int.Parse(a), int.Parse(b), int.Parse(c));
			this.sum.Text = r1.ToString();
		}

		//调用CPP创建的DLL进行的减法运算
		private void CppDiffer(object sender, RoutedEventArgs e)
		{
			var d = this.d.Text;
			var e1 = this.e.Text;
			int r2 = test02(int.Parse(d), int.Parse(e1));
			this.difference.Text = r2.ToString();
		}

		//调用C#创建的DLL进行加法运算
		private void CSSum(object sender, RoutedEventArgs e)
		{
			Class1 CSDLL = new Class1();
			var f = this.f.Text;
			var g = this.g.Text;
			int r3 = CSDLL.Add(int.Parse(f), int.Parse(g));
			this.CSsum.Text = r3.ToString();
		}

		//跳转到使用windows操作系统提供的DLL，实现对注册表的操作
		private void toTest1(object sender, RoutedEventArgs e)
		{
			Test1 test1 = new Test1();
			test1.Show();
			this.Close();
		}
	}
}
