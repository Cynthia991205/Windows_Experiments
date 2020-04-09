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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace WPFMysql
{
    /// <summary>
    /// SignInWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        public void connect()
        {
            string databaseName = "commerce";
            string server = "localhost";
            string username;
            string password;

            try
            {
                if (!String.IsNullOrEmpty(UsertextBox.Text.ToString()))
                {
                    username = UsertextBox.Text.ToString();
                }
                else
                {
                    throw new System.Exception("You have input null username!!");
                }

                if (!String.IsNullOrEmpty(passwordBox.Password.ToString()))
                {
                    password = passwordBox.Password.ToString();
                }
                else
                {
                    throw new System.Exception("You have input null password!!");
                }

                if (GlobalVariables.conn != null)
                {
                    GlobalVariables.conn.Close();
                }

                GlobalVariables.conn.ConnectionString = String.Format("Server={0}; UserId={1}; password={2}; database={3}; pooling=true", server, username, password, databaseName);
            }
            catch(Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }

            try
            {
                GlobalVariables.conn.Open();
                MessageBox.Show("Connected");
                MainWindow main = new MainWindow();
				
				main.Show();
				this.Close();
				GlobalVariables.conn.Close();
            }
            catch(Exception exce)
            {
                MessageBox.Show("Connection have some problem!!");
                UsertextBox.Clear();
                passwordBox.Clear();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            connect();
        }
    }
}
