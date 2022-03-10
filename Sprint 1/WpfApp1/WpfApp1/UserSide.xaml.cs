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
    /// Interaction logic for UserSide.xaml
    /// </summary>
    class Global
    {
        public static string UserID;
    }
    public partial class UserSide : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        public UserSide()
        {
            InitializeComponent();
        }
        public void Register()
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
            string qr = "select UserID from Customers where Email = '"+email+"';";
            SqlCommand cmd1 = new SqlCommand(qr,con);
            int usrid = Convert.ToInt32(cmd1.ExecuteScalar());
            MessageBox.Show($"Hi {usrname}, your User ID is {usrid} !\nRemember Your Details");
            ClearData();
            con.Close();
        }
        public void ClearData()
        {
            UserName.Clear();
            Password.Clear();
            PhoneNumber.Clear();
            EmailId.Clear();
            LicenceNumber.Clear();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }
        public int Login()
        {
            con.Open();
            Global.UserID = LgnUsrName.Text;
            string ps = LgnPassword.Password;
            string qr = "select Count(*) from Customers where UserID = " + Global.UserID + " and UserPassword = '" + ps + "';";
            SqlCommand cmd = new SqlCommand(qr, con);
            int res = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return res;
        }
        private void LgnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Login() == 1)
            {
                UserAction ua = new UserAction();
                ua.SendData(Convert.ToInt32(LgnUsrName.Text));
                ua.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed, Please Try Again !!");
            }
        }
        private void GBK_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
