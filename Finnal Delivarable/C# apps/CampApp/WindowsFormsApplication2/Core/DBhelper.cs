using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WindowsFormsApplication2;


namespace WindowsFormsApplication2
{
    class DBhelper
    {
        public MySqlConnection TempConnect;
         Client tempClient;
         CampHost tempCampHost;
         CampSpotGuest tempCampSpotGuest;
         List<CampHost> tempCampHoustList;
        public void connect()
        {
            string connectionString = "server=athena01.fhict.local;" +
                                          "database=dbi275231;" +
                                          "user id=dbi275231;" +
                                          "password=uJOaHhNP6c;" +
                                          "connect timeout=30;";

            TempConnect = new MySqlConnection(connectionString);
        }

        public Client SearchClient(string rfid)
        {
            tempClient = null;
            connect();
            //TempClient = null;
            string sql = "SELECT AccountNumber,first_name FROM client WHERE RFID = '" + rfid + "';";
            MySqlCommand command = new MySqlCommand(sql, TempConnect);
            try
            {
                TempConnect.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                { 
                    int accountNumber = Convert.ToInt32(reader["AccountNumber"]);
                    string firstName = Convert.ToString(reader["First_Name"]);
                    tempClient = new Client(accountNumber, firstName);
                }
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Bad " + ex.Message); ;
            }
            finally
            {
                TempConnect.Close();
            }
            return tempClient;
        }
        public CampHost SearchCampHost(int acc)
        {
            connect();
            string sql = "SELECT Camp_id,NumberOfGuests FROM campingspot WHERE Client_AccountNumber = '" + acc + "';";
            MySqlCommand command = new MySqlCommand(sql, TempConnect);
            tempCampHost = null;
            try
            {
                TempConnect.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int campID = Convert.ToInt32(reader["Camp_id"]);
                    int numberOfGuest = Convert.ToInt32(reader["NumberOfGuests"]);
                    tempCampHost = new CampHost(acc, numberOfGuest, campID);
                }
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Bad " + ex.Message); ;
            }
            finally
            {
                TempConnect.Close();
            }
            return tempCampHost;
        }
        public void AssignGuest(CampHost campH,int acc)
        {
            connect();
            string sql = "Insert into  campingspotguest(CampingSpot_Camp_id,Client_AccountNumber) values("+campH.Camp_id+","+acc+");";
            MySqlCommand command = new MySqlCommand(sql, TempConnect);
            string sql2 = "UPDATE `campingspot` SET `NumberOfGuests`=" + (campH.numberOfGuests - 1) + " where Camp_id="+campH.Camp_id+";";
            MySqlCommand command2 = new MySqlCommand(sql2, TempConnect);
            try
            {
                TempConnect.Open();
                command.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Bad " + ex.Message); ;
            }
            finally
            {
                TempConnect.Close();
            }

            try
            {
                TempConnect.Open();
                command2.ExecuteNonQuery();

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Bad " + ex.Message); ;
            }
            finally
            {
                TempConnect.Close();
            }

        }
        public CampSpotGuest SearchCampGuest(int acc)
        {
            connect();
            string sql = "SELECT CampingSpot_Camp_id FROM  campingspotguest WHERE Client_AccountNumber = '" + acc + "';";
            MySqlCommand command = new MySqlCommand(sql, TempConnect);
            tempCampSpotGuest = null;
            try
            {
                TempConnect.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int campID = Convert.ToInt32(reader["CampingSpot_Camp_id"]);

                    tempCampSpotGuest = new CampSpotGuest(campID, acc);
                }
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Bad " + ex.Message); ;
            }
            finally
            {
                TempConnect.Close();
            }
            return tempCampSpotGuest;
        }
        public List<CampHost> AllCampHost()
        {
            connect();
            tempCampHoustList = new List<CampHost>();
            string sql = "SELECT Camp_id,NumberOfGuests FROM campingspot ;";
            MySqlCommand command = new MySqlCommand(sql, TempConnect);
            tempCampHost = null;
            try
            {
                TempConnect.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int campID = Convert.ToInt32(reader["Camp_id"]);
                    int numberOfGuest = Convert.ToInt32(reader["NumberOfGuests"]);
                    tempCampHost = new CampHost(0, numberOfGuest, campID);
                    tempCampHoustList.Add(tempCampHost);
                }
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Bad " + ex.Message); ;
            }
            finally
            {
                TempConnect.Close();
            }
            return tempCampHoustList;
        }
    }
}
