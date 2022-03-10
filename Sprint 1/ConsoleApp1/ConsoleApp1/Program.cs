using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ConsoleApp1
{
    class Connection
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarRentalSystem;Integrated Security=True");
        public SqlConnection Con { get => con; set => con = value; }
    }
    class Auth
    {
        Connection c1 = new Connection();
        public int Login()
        {
            c1.Con.Open();
            Customer cs = new Customer();
            Console.WriteLine("----------------------\nEnter UserID  : ");
            string usrid = Console.ReadLine();
            Console.WriteLine("Enter Password : ");
            string ps = Console.ReadLine();
            string qr = "select Count(*) from Customers where UserID = "+usrid+" and UserPassword = '"+ps+"';";
            SqlCommand cmd = new SqlCommand(qr, c1.Con);
            int res = Convert.ToInt32(cmd.ExecuteScalar());
            c1.Con.Close();
            return res;
        }
    }
    class Admin
    {
        Connection c1 = new Connection();
        public void AddCarintodatabase()
        {
            Car cr = new Car();
            cr.AddCar();
        }
        public void ViewCarfromdatabase()
        {
            Car cr = new Car();
            cr.ViewCar();
        }
        public void AddUserintodatabase()
        {
            Customer cs = new Customer();
            cs.Register();
        }
        public void ViewUserfromdatabase()
        {
            Customer cs = new Customer();
            cs.ViewCustomer();
        }
        public void UpdateCategory()
        {
            c1.Con.Open();
            Category cs = new Category();
            Console.WriteLine("------ Old Entry --------");
            cs.ViewCategory();
            Console.WriteLine("Enter Category Id to Be Updated : ");
            int csid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Category Name : ");
            string categoryname = Console.ReadLine();
            Console.WriteLine("Enter Seating Capacity : ");
            int st = Convert.ToInt32(Console.ReadLine());
            string querry = "update Categories set CategoryName = '" + categoryname + "', SeatingCapacity = '" + st + "' where CategoryID = '" + csid + "';";
            SqlCommand cmd1 = new SqlCommand(querry, c1.Con);
            cmd1 = new SqlCommand(querry, c1.Con);
            cmd1.ExecuteNonQuery();
            Console.WriteLine($"{categoryname} Was Updated");
            Console.WriteLine("--------New Entry-----");
            cs.ViewCategory();
            c1.Con.Close();
        }
        public void UpdateCars()
        {
            Car cs = new Car();
            cs.ViewCar();
            Console.WriteLine("Select CarID to be updated"); 
            int crid = Convert.ToInt32(Console.ReadLine());
            c1.Con.Open();
            string querry1 = "Select * from Cars where CarId = '"+crid+"'";
            SqlCommand cmd = new SqlCommand(querry1, c1.Con);
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1, "Categories");
            Console.WriteLine("-------Old Entry---------");
            foreach (DataRow row in ds1.Tables["Categories"].Rows)
            {
                Console.WriteLine(row[0] + " - " + row[1] + " " + row[2]);
            }
            Category ct = new Category();
            Console.WriteLine("------- Categories --------");
            ct.ViewCategory();
            Console.WriteLine("Please Choose the category to add car");
            int catid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Brand Name : ");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter Model Name : ");
            string modelname = Console.ReadLine();
            Console.WriteLine("Enter Car Status from (Rented / Available)");
            string carstatus = Console.ReadLine();
            Console.WriteLine("Enter Fuel Type (Petrol / Diesel)");
            string fueltype = Console.ReadLine();
            Console.WriteLine("Enter Price Per Hour");
            int priceperhour = Convert.ToInt32(Console.ReadLine());
            string querry = "update Cars set Brand = '" + @brand + "', ModelName = '" + @modelname + "',CategoryId = '" + @catid + "',Car_Status = '" + @carstatus + "',Fuel_Type = '" + @fueltype + "',CarPricePerHour = '" + @priceperhour + "' where CarId = '"+@crid+"';";
            SqlCommand cmd1 = new SqlCommand(querry, c1.Con);
            cmd1 = new SqlCommand(querry, c1.Con);
            cmd1.ExecuteNonQuery();
            Console.WriteLine($"{brand} {modelname} Was Updated");
            Console.WriteLine("------- NEW ENTRY ------");
            cs.ViewCar();
            c1.Con.Close();

        }
        public void DeleteCarsfromDatabase()
        {
            Car cr = new Car();
            cr.DeleteCar();
        }
        public void DeleteCategoryfromdatabase()
        {
            Category ct = new Category();
            ct.DeleteCategory();
        }
        public void DeleteCustomerfromdatabase()
        {
            Customer cs = new Customer();
            cs.DeleteCustomer();
        }
        public void ViewRentalDetails()
        {
            c1.Con.Open();
            string qr4 = "select * from Rental";
            SqlCommand cmd4 = new SqlCommand(qr4, c1.Con);
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd4);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1, "Book");
            foreach (DataRow row in ds1.Tables["Book"].Rows)
            {
                Console.WriteLine(row[0] + "  " + row[1] + " " + row[2] + " " + row[3] + " " + row[4] + " " + row[5]);
            }
            c1.Con.Close();
        }
        public void UpdateCarStatus(int crid)
        {
            c1.Con.Open();
            string qr = "update Cars set Car_Status = 'Available' where CarID = "+crid+"";
            SqlCommand cmd = new SqlCommand(qr,c1.Con);
            cmd.ExecuteNonQuery();
            c1.Con.Close();
        }
        public void ViewCategoryfromdatabase()
        {
            Category ct = new Category();
            ct.ViewCategory();
        }
    }
    class Customer
    {
        Connection c1 = new Connection();
        public void Register()
        {
            c1.Con.Open();
            Console.WriteLine("\n-------------------------\nEnter User Name : ");
           string usrname = Console.ReadLine();
            Console.WriteLine("Enter License Number : ");
           int lncno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Passsword");
            string pass = Console.ReadLine();
            Console.WriteLine("Enter Phone Number ");
            int phno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email ID : ");
            string email = Console.ReadLine();
            string querry = "insert into Customers values('" + usrname + "','" + lncno + "','" + pass + "','" + phno + "','" + email + "')";
            SqlCommand cmd = new SqlCommand(querry, c1.Con);
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine($"New User {usrname} inserted into table");
            c1.Con.Close();
        }
        public void ViewCars()
        {
            Car cr = new Car();
            cr.ViewCar();
        }
        public void ViewCustomer()
        {
            c1.Con.Open();
            string querry1 = "Select * from Customers";
            SqlCommand cmd = new SqlCommand(querry1, c1.Con);
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1, "Categories");
            foreach (DataRow row in ds1.Tables["Categories"].Rows)
            {
                Console.Write("CustomerID : "+row[0] + ", Customer Name : " + row[1] + ", Licence Number " + row[2] + ", Password : ************ "+", Phone Number : " + row[4] + ", EmailId : " + row[5]);
                Console.WriteLine();
            }
            c1.Con.Close();
        }
        public void DeleteCustomer()
        {
            ViewCustomer();
            c1.Con.Open();
            Console.WriteLine("Enter the Customer ID To be deleted !!");
            int cusID = Convert.ToInt32(Console.ReadLine());
            string qr = "delete from Customers where UserID = " + cusID + "";
            SqlCommand cmd = new SqlCommand(qr, c1.Con);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"{cusID} was deleted from database !!");
            c1.Con.Close();
        }
    }
    class Booking
    {
        Connection c1 = new Connection();
        public bool BookACar()
        {
            c1.Con.Open();
            Console.WriteLine("\n---Enter Your Booking Details !! ---\n");
            Console.WriteLine("Enter your User ID ");
            int usrid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter The Car ID you want to book !!");
            int crid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Start Date Time");
            DateTime st = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter End Date Time");
            DateTime ed = DateTime.Parse(Console.ReadLine());
            string qr7 = "select Count(*) from Cars where CarID  = " + crid + ";";
            SqlCommand cmd7 = new SqlCommand(qr7, c1.Con);
            int flag = Convert.ToInt32(cmd7.ExecuteScalar());
            if (flag == 0)
            {
                Console.WriteLine("\n---Entered Car ID is Invalid---\n");
                return false;
            }
            else
            {
                string qr6 = "select Car_status from Cars where CarId = " + crid + ";";
                SqlCommand cmd6 = new SqlCommand(qr6, c1.Con);
                string result = Convert.ToString(cmd6.ExecuteScalar());
                if (result == "Available")
                {
                    string qr1 = "select datediff(hour , '" + st + "','" + ed + "')";
                    SqlCommand cmd1 = new SqlCommand(qr1, c1.Con);
                    int hrs = Convert.ToInt32(cmd1.ExecuteScalar());
                    string qr2 = "select CarPricePerHour from Cars where CarID = '" + crid + "'";
                    SqlCommand cmd2 = new SqlCommand(qr2, c1.Con);
                    int pr = Convert.ToInt32(cmd2.ExecuteScalar());
                    int totalprice = pr * hrs;
                    // Insert values
                    string qr3 = "insert into Rental values('" + crid + "','" + usrid + "','" + st + "','" + ed + "','" + totalprice + "')";
                    SqlCommand cmd3 = new SqlCommand(qr3, c1.Con);
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine("CAR BOOKED\nyour Booking Details !!");
                    string qr4 = "select * from Rental where UserID = '" + usrid + "'";
                    SqlCommand cmd4 = new SqlCommand(qr4, c1.Con);
                    SqlDataAdapter ad1 = new SqlDataAdapter(cmd4);
                    DataSet ds1 = new DataSet();
                    ad1.Fill(ds1, "Book");
                    foreach (DataRow row in ds1.Tables["Book"].Rows)
                    {
                        Console.WriteLine("RentalID : " + row[0] + ", CarID : " + row[1] + ", USerID : " + row[2] + ", StartDateTime : " + row[3] + ", EndDateTime : " + row[4] + ", Price : " + row[5]);
                    }
                    string qr5 = "update Cars set Car_Status = 'Rented' where CarID = " + crid + "";
                    SqlCommand cmd5 = new SqlCommand(qr5, c1.Con);
                    cmd5.ExecuteNonQuery();
                    c1.Con.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("\n---This car is already Booked---\n");
                    return false;
                }
            }
        }
        public void ReturnCar()
        {
            c1.Con.Open();
            Admin ad = new Admin();
            ad.ViewRentalDetails();
            Console.WriteLine("\nEnter Car ID to return !!");
            int crid = Convert.ToInt32(Console.ReadLine());
            string qr = "delete from Rental where CarID = " + crid + "";
            SqlCommand cmd = new SqlCommand(qr,c1.Con);
            cmd.ExecuteNonQuery();
            ad.UpdateCarStatus(crid);
            c1.Con.Close();
        }
    }
    class Car
    {
        Connection c1 = new Connection();
        public void AddCar()
        {
            c1.Con.Open();
            Category ct = new Category();
            ct.ViewCategory();
            Console.WriteLine("Please Choose the category to add car");
            int catid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Brand Name : ");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter Model Name : ");
            string modelname = Console.ReadLine();
            Console.WriteLine("Enter Car Status from (Rented / Available)");
            string carstatus = Console.ReadLine();
            Console.WriteLine("Enter Fuel Type (Petrol / Diesel)");
            string fueltype = Console.ReadLine();
            Console.WriteLine("Enter Price Per Hour");
            int priceperhour = Convert.ToInt32(Console.ReadLine());
            string querry = "insert into Cars values ('"+brand+"','"+modelname+"','"+catid+"','"+carstatus+"','"+fueltype+"','"+priceperhour+"');";
            SqlCommand cmd = new SqlCommand(querry, c1.Con);
            cmd = new SqlCommand(querry, c1.Con);
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine($"{brand} {modelname} inserted into Cars ");
            c1.Con.Close();
        }
        public void ViewCar()
        {
            Console.WriteLine("--------------------\n\nCars Available\n");
            c1.Con.Open();
            string querry1 = "Select * from Cars";
            SqlCommand cmd = new SqlCommand(querry1, c1.Con);
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1, "Categories");
            foreach (DataRow row in ds1.Tables["Categories"].Rows)
            {
                Console.Write("CarID : "+row[0] + ", Brand : " + row[1] + ", Model Name : " + row[2]+", CategoryId : "+row[3]+", Car Status : "+row[4]+", Fuel Type : "+row[5]+", Car Price Per Hour : "+row[6]);
                Console.WriteLine();
            }
            c1.Con.Close();
        }
        public void DeleteCar()
        {
            ViewCar();
            c1.Con.Open();
            Console.WriteLine("Choose the Car Id to be deleted !!!");
            int carid = Convert.ToInt32(Console.ReadLine());
            string qr = "delete from Cars where CarID = '" + carid + "'";
            SqlCommand cmd = new SqlCommand(qr, c1.Con);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"{carid} was deleted");
            c1.Con.Close();
        }
    }
    class Category
    {
        Connection c2 = new Connection();
        public void ViewCategory()
        {
            
            c2.Con.Open();
            string querry1 = "Select * from Categories";
            SqlCommand cmd = new SqlCommand(querry1, c2.Con);
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1, "Categories");
            foreach (DataRow row in ds1.Tables["Categories"].Rows)
            {
                Console.Write("Category ID : "+row[0] + ", Category Name : " + row[1]+", Seating Capacity : "+row[2]);
                Console.WriteLine();
            }
            c2.Con.Close();
        }
        public void AddCategory()
        {
            c2.Con.Open();
            string CatName;
            int Seats;
            Console.WriteLine("Insert Category Name : ");
            CatName = Console.ReadLine();
            Console.WriteLine("Insert Number of Seats : ");
            Seats = Convert.ToInt32(Console.ReadLine());
            string querry = "insert into Categories values ('" + CatName + "' , '" + Seats + "');";
            SqlCommand cmd = new SqlCommand(querry, c2.Con);
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("Number of Rows Affected "+r);
            c2.Con.Close();
        }
        public void DeleteCategory()
        {
            ViewCategory();
            c2.Con.Open();
            Console.WriteLine("Choose the Category Id to be deleted !!!");
            int catid = Convert.ToInt32(Console.ReadLine());
            string qr = "delete from Categories where CategoryId = '" + catid + "'";
            SqlCommand cmd = new SqlCommand(qr, c2.Con);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"{catid} was deleted");
            c2.Con.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Category c = new Category();
            Car cr = new Car();
            Customer cs = new Customer();
            Admin ad = new Admin();
            Auth au = new Auth();
            Booking bk = new Booking();


            while (true)
            { 
                OutLoopMain:
                Console.WriteLine("----------------------------Welcome TO Car Rental System------------------------");
                Console.Write("Want To Login As ? \n1. User \n2. Admin\n3. Exit the portal\nEnter Your Choice : ");
                int option = Convert.ToInt32(Console.ReadLine());
                if(option == 1)
                {
                    while (true)
                    {
                    OutLoopUser:
                        Console.WriteLine("\n----------Hello User---------- \nSelect The Option !!");
                        Console.WriteLine("1. Register Yourself");
                        Console.WriteLine("2. Login");
                        Console.WriteLine("Press 999 to Exit");
                        Console.Write("Enter the number of the option : ");
                        int opt1 = Convert.ToInt32(Console.ReadLine());
                        switch (opt1)
                        {
                            case 1:
                                cs.Register();
                                break;
                            case 2:
                                if (au.Login() == 1)
                                {
                                    Console.WriteLine("\n---Login Successful---\n");
                                    while (true)
                                    {   
                                        UserLoop:
                                        Console.WriteLine("Choose from Options ");
                                        Console.WriteLine("1. View Car");
                                        Console.WriteLine("2. View Category");
                                        Console.WriteLine("3.Book a car ");
                                        Console.WriteLine("4. Return Car");
                                        Console.WriteLine("Presss 999 to exit");
                                        Console.Write("Enter Your Choise : ");
                                        int opt2 = Convert.ToInt32(Console.ReadLine());
                                        switch (opt2)
                                        {
                                            case 1:
                                                cr.ViewCar();
                                                break;
                                            case 2:
                                                c.ViewCategory();
                                                break;
                                            case 3:
                                                if (bk.BookACar() == true)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    goto UserLoop;
                                                }
                                            case 4: bk.ReturnCar();
                                                Console.WriteLine("\n---Car was Returned !!!---\n");
                                                break;
                                            case 999: goto OutLoopUser;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("LOGIN FAILED \nTry Again !!!");
                                    break;
                                }
                            case 999: goto OutLoopMain;
                            default:
                                break;
                        }
                    }
                }
                else if (option == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("--------------------Welcome Admin---------------");
                        Console.WriteLine("Choose from Options !!");
                        Console.WriteLine("1.View Customer From Database");
                        Console.WriteLine("2.Add Customer Into Database");
                        Console.WriteLine("3.Delete Customer From Database");
                        Console.WriteLine("4. View Category");
                        Console.WriteLine("5.Delete Category From Database");
                        Console.WriteLine("6.Update Category");
                        Console.WriteLine("7.View Car From Database");
                        Console.WriteLine("8.Add Car Into Database");
                        Console.WriteLine("9.Delete Cars From Database");
                        Console.WriteLine("10.Update Cars");
                        Console.WriteLine("11.View Rental");

                        Console.WriteLine("Press 999 to exit");
                        Console.Write("Enter Your Choice : ");
                        int opt3 = Convert.ToInt32(Console.ReadLine());
                        switch (opt3)
                        {
                            case 3:
                                ad.DeleteCustomerfromdatabase();
                                break;
                            case 5:
                                ad.DeleteCategoryfromdatabase();
                                break;
                            case 10:
                                ad.UpdateCars();
                                break;
                            case 6:
                                ad.UpdateCategory();
                                break;
                            case 1:
                                ad.ViewUserfromdatabase();
                                break;
                            case 2:
                                ad.AddUserintodatabase();
                                break;
                            case 7:
                                ad.ViewCarfromdatabase();
                                break;
                            case 8:
                                ad.AddCarintodatabase();
                                break;
                            case 11:
                                ad.ViewRentalDetails();
                                break;
                            case 4:
                                Console.WriteLine();
                                ad.ViewCategoryfromdatabase();
                                break;
                            case 9: ad.DeleteCarsfromDatabase();
                                break;
                            case 999: goto OutLoopMain;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
