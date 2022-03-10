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
    /// Interaction logic for AdminManageCars.xaml
    /// </summary>
    public partial class AdminManageCars : Window
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        public AdminManageCars()
        {
            InitializeComponent();
        }
        public void AddCar()
        {
            con.Open();
            string querry = "insert into Cars values ('" + AddBrName.Text + "','" + AddMdName.Text + "','" + AddCatId.Text + "','" + AddCarStatus.Text + "','" + AddFlTp.Text + "','" + AddPrice.Text + "');";
            SqlCommand cmd = new SqlCommand(querry, con);
            cmd = new SqlCommand(querry, con);
            int r = cmd.ExecuteNonQuery();
            MessageBox.Show($"{AddBrName.Text} - {AddMdName.Text} inserted into Cars ");
            con.Close();
        }
        private void GBK_Click(object sender, RoutedEventArgs e)
        {
            AdminAction ad = new AdminAction();
            ad.Show();
            this.Close();
        }

        public void UpdateCars()
        {
            con.Open();
            string querry = "update Cars set Brand = '" + UBrand.Text + "', ModelName = '" + UModel.Text + "',CategoryId = '" + UCatID.Text + "',Car_Status = '" + UCarStatus.Text + "',Fuel_Type = '" + Ufuel.Text + "',CarPricePerHour = '" + Uprice.Text + "' where CarId = '" + UCarID.Text + "';";
            SqlCommand cmd1 = new SqlCommand(querry, con);
            cmd1 = new SqlCommand(querry, con);
            cmd1.ExecuteNonQuery();
            MessageBox.Show($"{UBrand.Text} -  {UModel.Text} Was Updated");
            con.Close();
        }

        public void DeleteCar()
        {
            con.Open();
            string qr = "delete from Cars where CarID = '" + DelCarID.Text + "'";
            SqlCommand cmd = new SqlCommand(qr, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"{DelCarID.Text} was deleted");
            con.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCar();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCars();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteCar();
        }
    }
}
