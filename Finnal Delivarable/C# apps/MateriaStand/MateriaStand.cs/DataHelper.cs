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

namespace MateriaStand.cs
{
    class DataHelper
    {
        MySqlConnection MySqlconnection;
        string sqlString = "server=athena01.fhict.local;" +
                                          "database=dbi275231;" +
                                          "user id=dbi275231;" +
                                          "password=uJOaHhNP6c;" +
                                          "connect timeout=30;";

        public string SqlString { get { return sqlString; } set { sqlString = value; } }
        public void connect()
        {
            string connectionString = "server=athena01.fhict.local;" +
                                          "database=dbi275231;" +
                                          "user id=dbi275231;" +
                                          "password=uJOaHhNP6c;" +
                                          "connect timeout=30;";
            MySqlconnection = new MySqlConnection(connectionString);
            try
            {
                MySqlconnection = new MySqlConnection(connectionString);
                MySqlconnection.Open();
                //MessageBox.Show("connected");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (MySqlconnection != null)
                    MySqlconnection.Close();
            }
        }
    }
}
