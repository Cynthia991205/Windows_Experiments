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
    /// ModifyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyWindow : Window
    {
        public ModifyWindow()
        {
            InitializeComponent();

            if(GlobalVariables.currentWindow.Equals("customer"))
            {
                comboBox.ItemsSource = null;
                comboBox.Items.Clear();

                label1.Content = "CustomerName";
                label2.Content = "CustomerID";
                label3.Content = "Address";
                label4.Content = "PhoneNumber";
                label5.Content = "EmailAddress";

                DataTable dataTable = GlobalVariables.dataset.Tables["customer"];
                comboBox.ItemsSource = GlobalVariables.getTableList(dataTable, "CustomerName");
                comboBox.SelectedIndex = 0;
            }
            else if(GlobalVariables.currentWindow.Equals("ordering"))
            {
                comboBox.ItemsSource = null;
                comboBox.Items.Clear();

                label1.Content = "OrderID";
                label2.Content = "CustomerName";
                label3.Content = "ProductName";
                label4.Content = "OrderTime";
                label5.Content = "OrderAmount";

                DataTable dataTable = GlobalVariables.dataset.Tables["ordering"];
                comboBox.ItemsSource = GlobalVariables.getTableList(dataTable, "OrderID");
                comboBox.SelectedIndex = 0;
            }
            else if(GlobalVariables.currentWindow.Equals("product"))
            {
                comboBox.ItemsSource = null;
                comboBox.Items.Clear();

                label1.Content = "ProductName";
                label2.Content = "ProductID";
                label3.Content = "Factory";
                label4.Content = "ModelNumber";
                label5.Content = "Price";

                DataTable dataTable = GlobalVariables.dataset.Tables["product"];
                comboBox.ItemsSource = GlobalVariables.getTableList(dataTable, "ProductName");
                comboBox.SelectedIndex = 0;
            }
            else
            {
                throw new System.Exception("No such Tables!!");
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox.SelectedValue != null)
            {
                DataTable table = new DataTable("ModifyTable");
                string currentWindow = GlobalVariables.currentWindow;
                table = GlobalVariables.dataset.Tables[currentWindow].Clone();
                string value = comboBox.SelectedValue.ToString();
                DataRow dataRow = GlobalVariables.dataset.Tables[currentWindow].Rows.Find(value);

                if(table.IsInitialized)
                {
                    table.Clear();
                    table.Rows.Add(dataRow.ItemArray);
                    label.Content = dataRow[0];
                    textBox1.Text = dataRow[1].ToString();
                    textBox2.Text = dataRow[2].ToString();
                    textBox3.Text = dataRow[3].ToString();
                    textBox4.Text = dataRow[4].ToString();
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string column1 = label.Content.ToString();
            string column2 = textBox1.Text;
            string column3 = textBox2.Text;
            string column4 = textBox3.Text;
            string column5 = textBox4.Text;

            DataRow dataRow = GlobalVariables.dataset.Tables[GlobalVariables.currentWindow].Rows.Find(column1);
            try
            {
                dataRow[1] = column2;
                dataRow[2] = column3;
                dataRow[3] = column4;
                dataRow[4] = column5;
            }
            catch(Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }

            MySqlCommandBuilder cn = new MySqlCommandBuilder(GlobalVariables.myadapter);
            try
            {
                GlobalVariables.myadapter.UpdateCommand = cn.GetUpdateCommand();

                // 将增加的dataset写入数据库
                GlobalVariables.myadapter.Update(GlobalVariables.dataset, GlobalVariables.currentWindow);

                GlobalVariables.conn.Close();
            }
            catch(Exception exce)
            {
               // MessageBox.Show(exce.ToString());
				Console.WriteLine(exce.ToString());
            }

            this.Close();
        }
    }
}
