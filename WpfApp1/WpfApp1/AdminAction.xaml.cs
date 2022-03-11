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
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AdminAction.xaml
    /// </summary>
    public partial class AdminAction : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        public AdminAction()
        {
            InitializeComponent();
        }
        public void LoadCarsData()
        {
            SqlCommand cmd = new SqlCommand("select * from Cars", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            AdminDG.ItemsSource = dt.DefaultView;
            AdminDG.Items.Refresh();
        }
        public void LoadCatData()
        {
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            AdminDG.ItemsSource = dt.DefaultView;
            AdminDG.Items.Refresh();
        }
        public void LoadRentalData()
        {
            UserSide us = new UserSide();
            string qr4 = "select * from Rental";
            SqlCommand cmd4 = new SqlCommand(qr4, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd4.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            AdminDG.ItemsSource = dt.DefaultView;
            AdminDG.Items.Refresh();
        }
        public void LoadCustomerData()
        {
            UserSide us = new UserSide();
            string qr4 = "select UserID,UserName,License_Number,PhoneNumber,Email from Customers;";
            SqlCommand cmd4 = new SqlCommand(qr4, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd4.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            AdminDG.ItemsSource = dt.DefaultView;
            AdminDG.Items.Refresh();
        }
        
        private void ViewCustBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomerData();
        }

        private void ViewCatBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadCatData();
        }

        private void ViewCarBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadCarsData();
        }

        private void ViewBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadRentalData();
        }

        private void AddCustBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminCustAction ad = new AdminCustAction();
            ad.Show();
            this.Close();
        }

        private void ManageCarBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminManageCars adcr = new AdminManageCars();
            adcr.Show();
            this.Close();
        }

        private void AdminLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Succesfully Logged Out !!");
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ManageCatBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminManageCat adcat = new AdminManageCat();
            adcat.Show();
            this.Close();
        }
    }
}
