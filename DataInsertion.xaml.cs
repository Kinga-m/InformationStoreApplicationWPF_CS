using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace InfoStore
{
    /// <summary>
    /// Interaction logic for DataInsertion.xaml
    /// </summary>
    public partial class DataInsertion : Window
    {
        private object dataGrid;

        public DataInsertion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                string connectionString = ConfigurationManager.ConnectionStrings["InfoStore.Properties.Settings.StorageConnectionString"].ConnectionString;
                string query = "INSERT INTO store VALUES (@Name, @Email, @PhoneNumber, @Location)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Name", name.Text);
                    command.Parameters.AddWithValue("@Email", email.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber.Text);
                    command.Parameters.AddWithValue("@Location", location.Text);

                    command.ExecuteNonQuery();
                }
                /*
                CloseMainWindowNow();
                var win = new MainWindow();
                win.Show();
                */
                Close();
            
         
       }/*
        public void CloseMainWindowNow()
        {
         
                var mainWindow = (Application.Current.MainWindow as MainWindow);
                if (mainWindow != null)
                {
                    mainWindow.Close();
                }
         
            
        }*/
        
    }
}
