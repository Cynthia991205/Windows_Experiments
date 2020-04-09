using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ExcelDataReader;
using System.Windows.Data;

namespace ExcelSQL
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

		private void Readbutton_Click(object sender, RoutedEventArgs e)
		{
			DataSet dataset;
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.Filter = "Excel Workbook|*.xlsx";
			dlg.ValidateNames = true;

			Students studentList = new Students();
			Nullable<bool> result = dlg.ShowDialog();

			if (result == true)
			{
				FileStream fs = File.Open(dlg.FileName, FileMode.Open, FileAccess.Read);
				IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs);
				dataset = reader.AsDataSet(new ExcelDataSetConfiguration()
				{
					ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
					{
						UseHeaderRow = true
					}
				});

				foreach (DataRow row in dataset.Tables[0].Rows)  // 选择sheet1表单
				{
					Student stu = new Student();
					int id = Convert.ToInt32(row[0]);
					string name = Convert.ToString(row[1]);
					string phone = Convert.ToString(row[2]);
					string address = Convert.ToString(row[3]);

					stu.ID = id;
					stu.Name = name;
					stu.PhoneNumber = phone;
					stu.Address = address;

					studentList.Add(stu);
				}
				dataGrid.ItemsSource = studentList;
			}
		}

		private void Savebutton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				//实例化exporttoexcel对象 
				ExportToExcel<Student, Students> exporttoexcel = new ExportToExcel<Student, Students>();

				ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
				exporttoexcel.DataToPrint = (Students)view.SourceCollection;
				exporttoexcel.GenerateReport();
			}
			catch (Exception exce)
			{
				MessageBox.Show(exce.Message.ToString());
			}

		}
	}
}
