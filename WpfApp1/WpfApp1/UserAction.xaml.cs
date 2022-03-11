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
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserAction.xaml
    /// </summary>
    public partial class UserAction : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        int usrData;
        public UserAction()
        {
            InitializeComponent();
            Greeting();
        }
        public void ReturnCar()
        {
            con.Open();
            int crid = Convert.ToInt32(CarId.Text);
            string q = "select UserID from Rental where CarID = '" + crid + "'";
            SqlCommand cm = new SqlCommand(q, con);
            string res = Convert.ToString(cm.ExecuteScalar());
            if (res == Global.UserID)
            {
                string qr = "delete from Rental where CarID = " + crid + "";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Car Returned !!");
                con.Close();
                UpdateCarStatus(crid);
            }
            else
            {
                MessageBox.Show("You have not booked this car !");
            }
        }
        public void UpdateCarStatus(int crid)
        {
            con.Open();
            string qr = "update Cars set Car_Status = 'Available' where CarID = " + crid + "";
            SqlCommand cmd = new SqlCommand(qr, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void LoadCarsData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Cars", con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            UserDG1.ItemsSource = dt.DefaultView;
            UserDG1.Items.Refresh();
            con.Close();
        }
        public void LoadCatData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            UserDG1.ItemsSource = dt.DefaultView;
            UserDG1.Items.Refresh();
            con.Close();
        }
        public void SendData(int data)
        {
            usrData = data;
        }
        public void Greeting()
        {
            con.Open();
            string qr = "select UserName from Customers where UserID = '" + Global.UserID + "'";
            SqlCommand cmd = new SqlCommand(qr, con);
            string name = Convert.ToString(cmd.ExecuteScalar());
            welcome.Text = $" Welcome  {name} !";
            con.Close();
        }
        public void LoadRentalData()
        {
            con.Open();
            UserSide us = new UserSide();
            string qr4 = "select * from Rental where UserID = '"+Global.UserID+"'";
            SqlCommand cmd4 = new SqlCommand(qr4, con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd4.ExecuteReader();
            dt.Load(sdr);
            UserDG1.ItemsSource = dt.DefaultView;
            UserDG1.Items.Refresh();
            con.Close();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ViewCarBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadCarsData();
        }

        private void ViewCatBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadCatData();
        }

        private void BookCarBtn_Click(object sender, RoutedEventArgs e)
        {
            BookCar bc = new BookCar();
            bc.Show();
            this.Close();
        }

        private void ReturnCarBtn1_Click(object sender, RoutedEventArgs e)
        {
            ReturnCar();
            LoadCarsData();
        }

        private void MyBooking_Click(object sender, RoutedEventArgs e)
        {
            LoadRentalData();
        }

        private void UsrLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User Succesfully Logged Out");
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
