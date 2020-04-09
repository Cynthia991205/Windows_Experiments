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
using System.Windows.Shapes;

namespace WPFMysql
{
    /// <summary>
    /// DeleteWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();

            if(GlobalVariables.currentWindow.Equals("customer"))
            {
                comboBox.ItemsSource = null;
                comboBox.Items.Clear();

                DataTable dt = GlobalVariables.dataset.Tables["customer"];
                comboBox.ItemsSource = GlobalVariables.getTableList(dt, "CustomerName");
                comboBox.SelectedIndex = 0;
            }
            else if(GlobalVariables.currentWindow.Equals("ordering"))
            {
                comboBox.ItemsSource = null;
                comboBox.Items.Clear();

                DataTable dt = GlobalVariables.dataset.Tables["ordering"];
                comboBox.ItemsSource = GlobalVariables.getTableList(dt, "OrderID");
                comboBox.SelectedIndex = 0;
            }
            else if(GlobalVariables.currentWindow.Equals("product"))
            {
                comboBox.ItemsSource = null;
                comboBox.Items.Clear();

                DataTable dt = GlobalVariables.dataset.Tables["product"];
                comboBox.ItemsSource = GlobalVariables.getTableList(dt, "ProductName");
                comboBox.SelectedIndex = 0;
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox.SelectedValue != null)
            {
                // 暂时存储临时表
                DataTable dataTable = new DataTable("DeleteTables");
                dataTable = GlobalVariables.dataset.Tables[GlobalVariables.currentWindow].Clone();
                string value = comboBox.SelectedValue.ToString();
                DataRow specialRow = GlobalVariables.dataset.Tables[GlobalVariables.currentWindow].Rows.Find(value);

                if (dataTable.IsInitialized)
                {
                    dataTable.Clear();
                    dataTable.Rows.Add(specialRow.ItemArray);

                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string value = comboBox.SelectedValue.ToString();
            GlobalVariables.dataset.Tables[GlobalVariables.currentWindow].Rows.Find(value).Delete();

            MySqlCommandBuilder cn = new MySqlCommandBuilder(GlobalVariables.myadapter);
            try
            {
                GlobalVariables.myadapter.DeleteCommand = cn.GetDeleteCommand();
                GlobalVariables.myadapter.Update(GlobalVariables.dataset, GlobalVariables.currentWindow);
                GlobalVariables.conn.Close();
            }
            catch(Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }

            this.Close();
        }
    }
}
