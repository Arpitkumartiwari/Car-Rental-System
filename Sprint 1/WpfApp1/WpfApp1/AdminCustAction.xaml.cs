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
    /// Interaction logic for AdminCustAction.xaml
    /// </summary>
    public partial class AdminCustAction : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        public AdminCustAction()
        {
            InitializeComponent();
        }
        public void ClearData()
        {
            UserName.Clear();
            Password.Clear();
            PhoneNumber.Clear();
            EmailId.Clear();
            LicenceNumber.Clear();
        }
        public void AddCustomer()
        {
            con.Open();
            string usrname = UserName.Text;
            int lncno = int.Parse(LicenceNumber.Text);
            string pass = Password.Text;
            int phno = Convert.ToInt32(PhoneNumber.Text);
            string email = EmailId.Text;
            string querry = "insert into Customers values('" + usrname + "','" + lncno + "','" + pass + "','" + phno + "','" + email + "')";
            SqlCommand cmd = new SqlCommand(querry, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"New User {usrname} inserted into table");
            ClearData();
            con.Close();
        }
        public void DeleteCustomer()
        {
            con.Open();
            string qr = "delete from Customers where UserID = " + DelCustUserId.Text + "";
            SqlCommand cmd = new SqlCommand(qr, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"{DelCustUserId.Text} was deleted from database !!");
            con.Close();
        }
        private void DelCustBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteCustomer();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GBK_Click(object sender, RoutedEventArgs e)
        {
            AdminAction ad = new AdminAction();
            ad.Show();
            this.Close();
        }
    }
}
