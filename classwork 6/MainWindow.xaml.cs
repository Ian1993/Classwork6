using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace classwork_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OleDbConnection cn;

        [System.Windows.Localizability(System.Windows.LocalizationCategory.Text)]
        public string Text { get; set; }

        //TextChangedEventArgs e;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Classwork6DB1.accdb");
        }

        private void Assets(object sender, RoutedEventArgs e)
        {
            string query = "select * from AssetList";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();

            string data = "";
            //string data1 = "";
            //string data2 = "";

            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            cn.Close();



            TextBox.Text = data;

            
            
            
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            this.Title = textBox.Text +
                "[Length = " + textBox.Text.Length.ToString() + "]";
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "select * from EmployeeList";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();

            string data = "";
            //string data1 = "";
            //string data2 = "";

            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            cn.Close();



            TextBox.Text = data;
        }
    }
}
