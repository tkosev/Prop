using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class DBconnect
    {
        public MySqlConnection abc;
        client client;

        public void connect()
        {
            string connectionString = "server=athena01.fhict.local;" +
                                          "database=dbi275231;" +
                                          "user id=dbi275231;" +
                                          "password=uJOaHhNP6c;" +
                                          "connect timeout=30;";

            abc = new MySqlConnection(connectionString);
        }

        public client SearchClient(int RFID)
        {
            string sql = "SELECT first_name, last_name FROM client WHERE RFID=" + RFID + ";";
            MySqlCommand command = new MySqlCommand(sql, abc);

            try
            {
                abc.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string first_name = Convert.ToString(reader["First_Name"]);
                    string last_name = Convert.ToString(reader["Last_Name"]);
                    //int accountNr = Convert.ToInt32(reader["AccountNumber"]);
                    client = new client(first_name, last_name, 123);
                }
                
            }
            
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                abc.Close();
            }
            return client;
        }
    }
    }
}
