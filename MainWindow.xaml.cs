using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Project to be completed using Linq
    /// Database must have some several fields like
    /// Id, Name, Email, Phone Number, Location
    /// It just stores the data/information. Never deletes anything, name depicts informationStorage eh ?
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenConnectionAndShow();
        }

        public void OpenConnectionAndShow() {

            string connectionString = ConfigurationManager.ConnectionStrings["InfoStore.Properties.Settings.StorageConnectionString"].ConnectionString;
            string query = "SELECT * FROM store";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter data = new SqlDataAdapter(query, connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGrid.CanUserAddRows = false;
                dataGrid.CanUserDeleteRows = false;
                dataGrid.SelectedValuePath = "Name";
                dataGrid.ItemsSource = dt.DefaultView;
                dataGrid.Items.Refresh();

            }

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataInsertion window = new DataInsertion();
            window.Show();
        }
    }
}
