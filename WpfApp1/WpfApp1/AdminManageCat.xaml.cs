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
    /// Interaction logic for AdminManageCat.xaml
    /// </summary>
    public partial class AdminManageCat : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        public AdminManageCat()
        {
            InitializeComponent();
        }

        public void AddCategory()
        {
            con.Open();
            string querry = "insert into Categories values ('" + AddCatName.Text + "' , '" + Convert.ToInt32(AddSeat.Text) + "');";
            SqlCommand cmd = new SqlCommand(querry, con);
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("Number of Rows Affected " + r);
            con.Close();
        }
        public void DeleteCategory()
        {
            try
            {
                con.Open();
                string qr1 = "select Count(*) from Categories where CategoryID = '" + DelCatID.Text + "';";
                SqlCommand cm = new SqlCommand(qr1, con);
                int res = Convert.ToInt32(cm.ExecuteScalar());
                if (res == 1)
                {
                    string qr = "delete from Categories where CategoryId = '" + DelCatID.Text + "'";
                    SqlCommand cmd = new SqlCommand(qr, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"{DelCatID.Text} was deleted");
                }
                else
                {
                    MessageBox.Show("Wrong Category ID, Please input the correct Category ID");
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateCategory()
        {
            con.Open();
            string querry = "update Categories set CategoryName = '" + UpdateCatName.Text + "', SeatingCapacity = '" + UpdateSeat.Text + "' where CategoryID = '" + UpdateCatID.Text + "';";
            SqlCommand cmd1 = new SqlCommand(querry, con);
            cmd1 = new SqlCommand(querry, con);
            cmd1.ExecuteNonQuery();
            MessageBox.Show($"{UpdateCatName.Text} Was Updated");
            con.Close();
        }
        private void GBK_Click(object sender, RoutedEventArgs e)
        {
            AdminAction ad = new AdminAction();
            ad.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCategory();
            MessageBox.Show("New Category Added");
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCategory();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteCategory();
        }
    }
}
