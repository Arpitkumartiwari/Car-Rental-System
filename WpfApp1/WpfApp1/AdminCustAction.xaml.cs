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
using System.Text.RegularExpressions;
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
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if(match.Success)
            {
                string querry = "insert into Customers values('" + usrname + "','" + lncno + "','" + pass + "','" + phno + "','" + email + "')";
                SqlCommand cmd = new SqlCommand(querry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show($"New User {usrname} inserted into table");
                ClearData();
            }
            else
            {
                MessageBox.Show("Email ID : "+email+" is not valid !");
            }
            con.Close();
        }
        public void DeleteCustomer()
        {
            try
            {
                con.Open();
                string qr1 = "Select Count(*) from Customers where UserID = '" + DelCustUserId.Text + "';";
                SqlCommand cm = new SqlCommand(qr1, con);
                int res = Convert.ToInt32(cm.ExecuteScalar());
                if (res == 1)
                {
                    string qr = "delete from Customers where UserID = " + DelCustUserId.Text + "";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"{DelCustUserId.Text} was deleted from database !!");
                }
                else
                {
                    MessageBox.Show("This user Id does not exist ,Please input correct User ID ");
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
