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
    /// InsertWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InsertWindow : Window
    {
        public InsertWindow()
        {
            InitializeComponent();

            if(GlobalVariables.currentWindow.Equals("customer"))
            {
                label1.Content = "CustomerName";
                label2.Content = "CustomerID";
                label3.Content = "Address";
                label4.Content = "PhoneNumber";
                label5.Content = "EmailAddress";
            }
            else if(GlobalVariables.currentWindow.Equals("ordering"))
            {
                label1.Content = "OrderID";
                label2.Content = "CustomerName";
                label3.Content = "ProductName";
                label4.Content = "OrderTime";
                label5.Content = "OrderAmount";
            }
            else if(GlobalVariables.currentWindow.Equals("product"))
            {
                label1.Content = "ProductName";
                label2.Content = "ProductID";
                label3.Content = "Factory";
                label4.Content = "ModelNumber";
                label5.Content = "Price";
            }
            else
            {
                throw new Exception("No such Tables!!");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = GlobalVariables.dataset.Tables[GlobalVariables.currentWindow].NewRow();
            try
            {
                List<TextBox> textBoxs = new List<TextBox> { textBox1, textBox2, textBox3, textBox4, textBox5 };
                for (int i = 0; i < textBoxs.Count; i++)
                {
                    TextBox tb = textBoxs[i];
                    if (!String.IsNullOrEmpty(tb.Text))
                    {
                        newRow[i] = tb.Text;
                    }
                    else
                    {
                        throw new Exception("You have input null!!");
                    }
                }

                // 在dataset执行逻辑增加
                GlobalVariables.dataset.Tables[GlobalVariables.currentWindow].Rows.Add(newRow);
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }

            MySqlCommandBuilder cn = new MySqlCommandBuilder(GlobalVariables.myadapter);
            try
            {
                GlobalVariables.myadapter.InsertCommand = cn.GetInsertCommand();
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
