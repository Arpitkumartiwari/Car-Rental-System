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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AdminSide.xaml
    /// </summary>
    public partial class AdminSide : Window
    {
        public string AdminID = "Admin";
        public string AdminPass = "Admin";
        public AdminSide()
        {
            InitializeComponent();
        }

        private void AdLgnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AdID.Text == AdminID && AdPass.Password==AdminPass)
            {
                AdminAction ac = new AdminAction();
                ac.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Admin Credentials\n Please Try Again ");
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
