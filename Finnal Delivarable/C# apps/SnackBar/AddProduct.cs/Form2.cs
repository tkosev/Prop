using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using MySql.Data.MySqlClient;

namespace BarApp.cs
{
    public partial class Form2 : Form
    {

        private BarApp bar; private DataHelper connection; private Client client; private RFID myRfidReader;
        Snack s; Drink d; private Order order; private OrderLine orderLine; string myRfid; bool toPay;
        double totalprice = 0; String holder1; double holder2; int quanTextbox; int produrcID;

        public Form2()
        {
            InitializeComponent();
            try
            {
                myRfidReader = new RFID();
                myRfidReader.Tag += new TagEventHandler(RfidReaderTag);
            }
            catch (PhidgetException e)
            {
                MessageBox.Show(e.Message);

            }
            ReadChip();
            bar = new BarApp();
            connection = new DataHelper();
            order = new Order();
            connection.connect();
        }




        private void ReadChip()
        {
            try
            {
                
                myRfidReader.open();
                myRfidReader.waitForAttachment(3000);
                myRfidReader.Antenna = true;
                myRfidReader.LED = true;
                MessageBox.Show("RFID reader is found and open");
                
            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID reader found");
            }
        }


        private void RfidReaderTag(object sender, TagEventArgs e)
        {
            myRfid = Convert.ToString(e.Tag);
            client = bar.SearchClient(myRfid);
            MessageBox.Show(myRfid);
            //bar.Recharge(Convert.ToInt32(textBox1.Text),client.AccountNumber);
            //label1.Text = "Account:" + client.AccountNumber;
            //label2.Text = "MoneyBalance" + client.MoneyBalance;
            
        }









        private void button2_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            var form1 = new Form1();
            form1.Show();
        }
    }
}
