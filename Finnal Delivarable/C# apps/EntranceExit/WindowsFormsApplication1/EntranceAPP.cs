using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace WindowsFormsApplication1
{
    public partial class EntranceAPP : Form
    {

        private RFID myRFIDReader;
        private DBhelper connecting;
        private Entrance entran;
        private Order order;
        private OrderLine orderline;
        private Client c;
        
        int total;
        int counter = 5;

        public EntranceAPP()
        {
           
            connecting = new DBhelper();
            entran = new Entrance();
            c = new Client("s","c",777777,1);
            InitializeComponent();
            connecting.connect();

            try
            {
                // Creating RFID reader and adding the events needed
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
                
            }
            catch (PhidgetException) 
            {
                MessageBox.Show("error at start-up."); 
            }

            // running readchip
            readchip();
        }

        private void readchip()
        {
            // Readchip is method for detecting RFID chips 
            try
            {
                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                //MessageBox.Show("an RFID-reader is found and opened.");
                myRFIDReader.Antenna = true;
                myRFIDReader.LED = true;
            }
            catch (PhidgetException) 
            {
                MessageBox.Show("no RFID-reader opened."); 
            }            
         }


        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            //showing if RFID scanners are attached
            
        }

        private void ShowWhoIsDetached(object sender, DetachEventArgs e)
        {
            //showing if RFID scaners are detached
            
        }

        private void ProcessThisTag(object sender, TagEventArgs e)
        {
        //    // show current RFID tag to label
            timer1.Stop();
            
            string MyRFID = Convert.ToString(e.Tag);
            //MessageBox.Show(MyRFID);
            c = entran.SearchClient(MyRFID);


            if (c == null)
            {
                pbox1.Image = imageList1.Images[4];
                label6.Text = "There is no client with this rfid.";
            }
            else
            {

                
                labelNumber.Text = Convert.ToString(c.AccountNumber);
                label7.Text = c.First_name + " " + c.Last_name;
                label8.Text = "Money Balance: " + c.MoneyBalance.ToString();

                if (c.MoneyBalance <= 0)
                {
                    label5.Text = (Math.Abs(Convert.ToDouble(c.MoneyBalance))).ToString();
                }
                else
                {
                    label5.Text = "0";
                }
                int total = Convert.ToInt32(label5.Text) + Convert.ToInt32(numericUpDown1.Value);
                label2.Text = "Total :" + total.ToString();




                if (c.MoneyBalance >= 0)
                {
                    if (entran.CheckInEvent(c.AccountNumber) == 1)
                    {
                        
                        if (entran.getAllOrdersNotPayed(c.AccountNumber).Count == 0)
                        {
                            timer1.Start();
                            timer2.Start();
                            c.InEvent = false;
                            entran.ChangeInEvent(c.AccountNumber, 0);
                            label6.Text = "Bye";
                            pbox1.Image = imageList1.Images[0];
                        }
                        else
                        {
                            listBox1.Items.Clear();
                            pbox1.Image = imageList1.Images[2];
                            label6.Text = "You have to pay before leave!";
                            listBox1.Items.Add("You must go return and pay the things you got from the \"Material Stand\" :");
                            foreach (OrderLine item in entran.getAllOrdersNotPayed(c.AccountNumber))
                            {
                                listBox1.Items.Add(item.AsString());
                            }
                           
                        }
                        

                    }
                    else
                    {
                        timer1.Start();
                        timer2.Start();
                        c.InEvent = true;
                        entran.ChangeInEvent(c.AccountNumber, 1);
                        pbox1.Image = imageList1.Images[1];
                        label6.Text = "Hello";

                    }

                }
                else
                {
                    c.InEvent = false;
                    entran.ChangeInEvent(c.AccountNumber, 0);
                    pbox1.Image = imageList1.Images[2];
                    label6.Text = "Pay";
                }



            }
            
            
        }

        private void buttonpay_Click(object sender, EventArgs e)
        {


            total = Convert.ToInt32(richTextBox1.Text);
            entran.Recharge(total,c.AccountNumber);
            MessageBox.Show("You have recharged account:" + c.AccountNumber + "and your money balance now is:" + (c.MoneyBalance + total) );
                
            
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
        }

        private void EntranceAPP_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            total = Convert.ToInt32(label5.Text) + Convert.ToInt32(numericUpDown1.Value);
            label2.Text = "Total :" + total.ToString();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            listBox1.Items.Clear();
            label9.Text = "Time left :";
            labelNumber.Text = "00000000";
            pbox1.Image = imageList1.Images[3];
            label7.Text = "";
            label8.Text = "Money Balance :";
            label5.Text = "0";
            numericUpDown1.Value = 0;
            label2.Text = "= Total";
            label6.Text = "Next!";
            c = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelNumber.Text = "00000000";
            pbox1.Image = imageList1.Images[3];
            label7.Text = "";
            label8.Text = "Money Balance :";
            label5.Text = "0";
            numericUpDown1.Value = 0;
            label2.Text = "= Total";
            label6.Text = "Next!";
            c = null;
            timer1.Stop();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                counter = 5;
                timer2.Stop();
                label9.Text = "Time left : 0";
            }
            else
            {
                label9.Text = "Time left : " + counter.ToString();
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            counter = 30;
            timer2.Start();
        }
    }
}
