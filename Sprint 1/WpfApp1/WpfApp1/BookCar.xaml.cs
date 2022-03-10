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
    /// Interaction logic for BookCar.xaml
    /// </summary>
    public partial class BookCar : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        int uid;
        public BookCar()
        {
            InitializeComponent();
        }
        public bool BookACar()
        {
            con.Open();
            int crid = Convert.ToInt32(BcCrID.Text);
            DateTime st = DateTime.Parse(BcSt.Text);
            DateTime ed = DateTime.Parse(BcEd.Text);
            string qr7 = "select Count(*) from Cars where CarID  = " + crid + ";";
            SqlCommand cmd7 = new SqlCommand(qr7, con);
            int flag = Convert.ToInt32(cmd7.ExecuteScalar());
            con.Close();
            if (flag == 0)
            {
                MessageBox.Show("Entered Car ID is Invalid");
                return false;
            }
            else
            {
                con.Open();
                string qr6 = "select Car_status from Cars where CarId = " + crid + ";";
                SqlCommand cmd6 = new SqlCommand(qr6, con);
                string result = Convert.ToString(cmd6.ExecuteScalar());
                if (result == "Available")
                {
                    string qr1 = "select datediff(hour , '" + st + "','" + ed + "')";
                    SqlCommand cmd1 = new SqlCommand(qr1, con);
                    int hrs = Convert.ToInt32(cmd1.ExecuteScalar());
                    string qr2 = "select CarPricePerHour from Cars where CarID = '" + crid + "'";
                    SqlCommand cmd2 = new SqlCommand(qr2, con);
                    int pr = Convert.ToInt32(cmd2.ExecuteScalar());
                    int totalprice = pr * hrs;
                    // Insert values
                    string qr3 = "insert into Rental values('" + crid + "','" + Global.UserID + "','" + st + "','" + ed + "','" + totalprice + "')";
                    SqlCommand cmd3 = new SqlCommand(qr3, con);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show($"CAR BOOKED,\nTotal Price : {totalprice}");
                    string qr5 = "update Cars set Car_Status = 'Rented' where CarID = " + crid + "";
                    SqlCommand cmd5 = new SqlCommand(qr5, con);
                    cmd5.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("This car is already Booked");
                    return false;
                }
            }
        }

        private void GBK_Click(object sender, RoutedEventArgs e)
        {
            UserAction Ua = new UserAction();
            Ua.SendData(Convert.ToInt32(uid));
            Ua.Show();
            this.Close();
        }
        private void BookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookACar();
        }
    }
}
