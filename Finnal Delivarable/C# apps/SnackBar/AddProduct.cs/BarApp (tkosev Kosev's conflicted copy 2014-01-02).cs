using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarApp.cs
{
    class BarApp
    {
        private DataHelper dataHelper;
        private Client client;
        private List<Order> Orderlist;
        
        private MySqlConnection MySqlconnection;
        private List<Drink> drinksList;
        private List<Snack> snackList;
        public  List<Drink> DrinksList { get { return drinksList; } set { drinksList = value; } }
        public  List<Snack> SnackList { get { return snackList; } set { snackList = value; }}
        public  List<OrderLine> listOfOrders;

        public BarApp()
        {
           
            dataHelper = new DataHelper();
            MySqlconnection = new MySqlConnection(dataHelper.SqlString);
            listOfOrders = new List<OrderLine>();
        }
        
        public Client SearchClient(string RFID)
        {
            string sql = "SELECT first_name, last_name,AccountNumber,MoneyBalance,InEvent,RFID FROM client WHERE RFID =\"" + RFID + "\";";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string first_name = Convert.ToString(reader["First_Name"]);
                    string last_name = Convert.ToString(reader["Last_Name"]);
                    int accountNr = Convert.ToInt32(reader["AccountNumber"]);
                    double Moneybalance = Convert.ToDouble(reader["MoneyBalance"]);
                    client = new Client(first_name, last_name,accountNr,Moneybalance);

                }

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return client;
        }
        public bool ReduceMoneyBalance(string RFID, double amount)
        {
            string balance = "Select MoneyBalance From client WHERE RFID = '" + RFID + "' ;";
            MySqlCommand command = new MySqlCommand(balance, MySqlconnection);
            double money = 0; // -1
            //int accountNr;
            
            MySqlconnection.Close();
            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    money = Convert.ToDouble(reader["MoneyBalance"]);
                    
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message);
            }
            finally
            {
                MySqlconnection.Close();
            }


            if (money > amount)
            {

                string sql = "UPDATE client SET MoneyBalance = MoneyBalance - " + amount + " WHERE RFID = '" + RFID + "'";
                MySqlCommand command1 = new MySqlCommand(sql, MySqlconnection);

                try
                {
                    MySqlconnection.Open();
                    command1.ExecuteNonQuery();
                }

                catch (MySqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("bad " + ex.Message);
                }
                finally
                {
                    MySqlconnection.Close();
                }

            }
           

            return true;

        }
        public void buyProduct(int producId, int quanlity)  
        {

            string sql = "UPDATE Product SET quantity = (quantity - " + quanlity + ") WHERE Prioduct_id = " + producId + ";";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
           
            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
               
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                MySqlconnection.Close();
            }
            

           
        }
        public List<Snack> GetAllSnacks()
        {
            string sql = "SELECT * FROM Product WHERE IsItSnack = \"1\";";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            snackList = new List<Snack>();

            try
            {

                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Snack snack;

                int productId;
                String name;
                int quantity;
                double price;
                bool isItSnack;
                string pathstring;
                while (reader.Read())
                {

                    productId = Convert.ToInt32(reader[0]);
                    name = Convert.ToString(reader[1]);
                    quantity = Convert.ToInt32(reader[2]);
                    price = Convert.ToDouble(reader[3]);
                    isItSnack = Convert.ToBoolean(reader[4]);
                    pathstring = Convert.ToString(reader[5]);
                    snack = new Snack(productId, name, quantity, price, isItSnack,pathstring);

                    snackList.Add(snack);
                }


            }
            catch (MySqlException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                MySqlconnection.Close();
            }
            return snackList;
        }
        public List<Drink> GetAllDrinks()
        {
            string sql = "SELECT * FROM Product WHERE IsItSnack = \"0\";";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            drinksList = new List<Drink>();

            try
            {
                
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Drink drink;

                int productId;
                String name;
                int quantity;
                double price;
                bool isItSnack;
                string pathstring;
                while (reader.Read())
                {

                    productId = Convert.ToInt32(reader[0]);
                    name = Convert.ToString(reader[1]);
                    quantity = Convert.ToInt32(reader[2]);
                    price = Convert.ToDouble(reader[3]);
                    isItSnack = Convert.ToBoolean(reader[4]);
                    pathstring = Convert.ToString(reader[5]);
                    drink = new Drink(productId, name, quantity, price, isItSnack,pathstring);

                    drinksList.Add(drink);
                }


            }
            catch (MySqlException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                MySqlconnection.Close();
            }
            return drinksList;
        }
        public void MakeOrderLine(OrderLine neworder)
        {
            string sql = "INSERT INTO `dbi275231`.`order_line` (`Order_line_id`, `name`, `quantity`, `price`, `Order_Order_id`, `Product_Prioduct_id`) VALUES (NULL,'" + neworder.Name + "','" + neworder.Quantity + "','" + neworder.Price + "','" + neworder.Order_id + "','" + neworder.Product.ProductId + "');";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            
        }
        public void MakeOrder(Order newOrd, int account,double totalprice)
        {
            string asdat = DateTime.Now.ToString("yyyy-MM-dd");
            string sqll = "INSERT INTO `dbi275231`.`order` (`Order_id`, `TotalPrice`, `Date`, `Client_AccountNumber`) VALUES (NULL, '" + totalprice + "', '" + asdat + "', '" + account + "');";
            MySqlCommand command = new MySqlCommand(sqll, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
        
        }
        public int GetOrderID()
        {

            string sql = "SELECT MAX(Order_id) FROM `order`";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            int result = 0;
            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = (Convert.ToInt32(reader["MAX(Order_id)"])) + 1;
                }

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return result;
        }
        public void Pay(int accountnr)
        {
            string sqll = "UPDATE `order` SET `Payed`= 1  WHERE `Client_AccountNumber` =" + accountnr + ";";
            MySqlCommand command = new MySqlCommand(sqll, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
        }
        public List<Order> getAllOrdersNotPayed(int accountnumber)
        {
            string sql = "SELECT *  FROM `order` WHERE `Client_AccountNumber` =" + accountnumber + " AND `Payed` = 0;";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            Orderlist = new List<Order>();

            try
            {

                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Order orderTopayed;

                int order_id;
                double Total_price;
                string date;
                int clientAccount;
                int payed;
                while (reader.Read())
                {

                    order_id = Convert.ToInt32(reader[0]);
                    Total_price = Convert.ToDouble(reader[1]);
                    date = Convert.ToString(reader[2]);
                    clientAccount = Convert.ToInt32(reader[3]);
                    payed = Convert.ToInt16(reader[4]);
                    orderTopayed = new Order(order_id, Total_price, date, clientAccount, payed);

                    Orderlist.Add(orderTopayed);
                }


            }
            catch (MySqlException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                MySqlconnection.Close();
            }
            return Orderlist;


        }
        public double PayOrderPrice(int accountnumber)
        {

            string sqll = "SELECT sum(TotalPrice) as price FROM `order` WHERE `Client_AccountNumber` =" + accountnumber + " AND `Payed` = 0;";
            MySqlCommand command = new MySqlCommand(sqll, MySqlconnection);
            double orderTobePayedPrice = 0;
            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.IsDBNull(reader.GetOrdinal("price")))
                    {
                        orderTobePayedPrice = 0;
                    }
                    else
                    {
                        orderTobePayedPrice = Convert.ToDouble(reader["price"]);
                    }


                }

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return orderTobePayedPrice;

        }
        public void InitializeOrder(Order newOrd, int account, double totalprice)
        {
            string asdat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sqll = "INSERT INTO `dbi275231`.`order` (`Order_id`, `TotalPrice`, `Date`, `Client_AccountNumber`, `Payed`) VALUES ('1', '" + totalprice + "', '" + asdat + "', '" + account + "', '" + 0 + "');";
            MySqlCommand command = new MySqlCommand(sqll, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }

        }
        public int CheckEmpty()
        {

            string sqll = "SELECT Order_id  FROM `order`;";
            MySqlCommand command = new MySqlCommand(sqll, MySqlconnection);
            int order_id = 0;
            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    order_id = Convert.ToInt16(reader["Order_id"]);

                }

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return order_id;

        }
    }
}
