using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPFMysql
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MySqlCommand cmdTables = new MySqlCommand(String.Format("show tables from commerce;"), GlobalVariables.conn);
            MySqlDataAdapter adapterTables = new MySqlDataAdapter(cmdTables);
            adapterTables.Fill(GlobalVariables.dataset, "Tables");
            cmdTables.Dispose();
            adapterTables.Dispose();

            MySqlCommand cmdTable1 = new MySqlCommand(String.Format("Select * from Customer;"), GlobalVariables.conn);
            MySqlDataAdapter adapterTable1 = new MySqlDataAdapter(cmdTable1);
            adapterTable1.Fill(GlobalVariables.dataset, "Customer");
            cmdTable1.Dispose();
            adapterTable1.Dispose();

            // 这里把首行设为主键
            GlobalVariables.dataset.Tables["Customer"].PrimaryKey = new DataColumn[] { GlobalVariables.dataset.Tables["Customer"].Columns["CustomerName"]};


            MySqlCommand cmdTable2 = new MySqlCommand(String.Format("Select * from Product;"), GlobalVariables.conn);
            MySqlDataAdapter adapterTable2 = new MySqlDataAdapter(cmdTable2);
            adapterTable2.Fill(GlobalVariables.dataset, "Product");
            cmdTable2.Dispose();
            adapterTable2.Dispose();

            // 这里把首行设为主键
            GlobalVariables.dataset.Tables["Product"].PrimaryKey = new DataColumn[] { GlobalVariables.dataset.Tables["Product"].Columns["ProductName"] };
            

            MySqlCommand cmdTable3 = new MySqlCommand(String.Format("Select * from Ordering;"), GlobalVariables.conn);
            MySqlDataAdapter adapterTable3 = new MySqlDataAdapter(cmdTable3);
            adapterTable3.Fill(GlobalVariables.dataset, "Ordering");
            cmdTable3.Dispose();
            adapterTable3.Dispose();

            // 这里把首行设为主键
            GlobalVariables.dataset.Tables["Ordering"].PrimaryKey = new DataColumn[] { GlobalVariables.dataset.Tables["Ordering"].Columns["OrderID"]};
          

            DataTable tables = GlobalVariables.dataset.Tables["Tables"];

            comboBox.ItemsSource = GlobalVariables.getTableList(tables, "Tables_in_Commerce");
            comboBox.SelectedIndex = 0;

            GlobalVariables.conn.Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox.SelectedValue != null)
            {
                string name = comboBox.SelectedValue.ToString();
                MessageBox.Show(name);
                GlobalVariables.currentWindow = name;
                MySqlCommand cmd = new MySqlCommand(String.Format("Select * from {0};", name), GlobalVariables.conn);
                GlobalVariables.myadapter = new MySqlDataAdapter(cmd);

                dataGrid.ItemsSource = GlobalVariables.dataset.Tables[name].DefaultView;
            }
        }

        private void Modifybutton_Click(object sender, RoutedEventArgs e)
        {
            ModifyWindow modify = new ModifyWindow();
            modify.Show();
        }

        private void Insertbutton_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow insert = new InsertWindow();
            insert.Show();
        }
        private void Deletebutton_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow delete = new DeleteWindow();
            delete.Show();
        }

		
	}

	public static class GlobalVariables
    {
        public static MySqlConnection conn = new MySqlConnection();
        public static DataSet dataset = new DataSet();
        public static MySqlDataAdapter myadapter;
        public static string currentWindow;

        public static List<string> getTableList(DataTable dataTable, string columnName)
        {
            List<string> tableList = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                string tableName = row[columnName].ToString();
                tableList.Add(tableName);
            }
            return tableList;
        } 
    }

}
