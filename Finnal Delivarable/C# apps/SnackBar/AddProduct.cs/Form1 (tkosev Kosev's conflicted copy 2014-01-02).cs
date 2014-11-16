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
using Phidgets;
using Phidgets.Events;



namespace BarApp.cs
{
    public partial class Form1 : Form
    {
        //fields
        private BarApp bar; private DataHelper connection; private Client client; private RFID myRfidReader;
        Snack s; Drink d; private Order order; private OrderLine orderLine; string myRfid; bool toPay;
        double totalprice = 0; String holder1; double holder2; int quanTextbox; int produrcID;
          

        
        public Form1()
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
            bar.GetAllDrinks();
            bar.GetAllSnacks();
            getAllSnackFromDb();
            getAllDrinksFromDb();
            toPay = false;
           
            
           
        }
        private void RfidReaderTag(object sender, TagEventArgs e)
        {
            myRfid = Convert.ToString(e.Tag);
            client = bar.SearchClient(myRfid);
            if (listBox1.Items.Count != 0)
            {
                toPay = true;
            }
            else
            {
                toPay = false;
            }

            

                if (this.toPay)
                {
                    if (client.MoneyBalance >= order.orderGetTotalPrice())
                    {
                       
                        bar.MakeOrder(order, client.AccountNumber, order.orderGetTotalPrice());
                        foreach (OrderLine item in order.getAllOrderLines())
                        {
                            bar.MakeOrderLine(item);
                            bar.buyProduct(item.Product.ProductId, item.Quantity);
                        }
                        bar.ReduceMoneyBalance(myRfid, order.orderGetTotalPrice());
                        bar.Pay(client.AccountNumber);

                        pictureBox1.BackColor = Color.Green;
                        this.toPay = false;

                        MessageBox.Show("You have payed");
                        label2.Text = "Balance: €" + (Convert.ToDouble(client.MoneyBalance) - order.orderGetTotalPrice()).ToString();
                        label1.Text = "Account: " + client.AccountNumber;
                        order.getAllOrderLines().Clear();
                        listBox1.Items.Clear();
                        order = new Order();
                    }
                    else
                    {

                        pictureBox1.BackColor = Color.Black;
                        MessageBox.Show("Nothing to pay");
                        toPay = false;
                        order.getAllOrderLines().Clear();
                        listBox1.Items.Clear();
                        label1.Text = "Account: ";
                        label2.Text = "Balance: €";

                    }
                }
            }
        




            
        private void ReadChip()
        {
            try
            {
                myRfidReader.open();
                myRfidReader.waitForAttachment(3000);
                MessageBox.Show("RFID reader is found and open");
                myRfidReader.Antenna = true;
                myRfidReader.LED = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID reader found");
            }
        }
        
        private void btnPay_Click(object sender, EventArgs e)
        {
            bar.Pay(client.AccountNumber);
            bar.ReduceMoneyBalance(myRfid, bar.PayOrderPrice(client.AccountNumber));
            MessageBox.Show("You have paid !");
            pictureBox1.BackColor = Color.Green;
          
            listBox1.Items.Clear();
            label1.Text = "Account: ";
            label2.Text = "Ballance : ";
            label4.Text = "Total : 0";
            toPay = false;

        }
        public  void getAllSnackFromDb()
        {
            int counter = 0;
            MyButton my = new MyButton();
            MyButton[] snacksButtons = new MyButton[100];
            int wOfButton = 110; //width
            int hOfButton = 100; //hight
            Point xy = new Point(10, 10);
            int space = 130;
            int maxPossition= 4;
            List<Snack> tempSnackList = bar.GetAllSnacks();
            int possition;
            
            for (int y = 0; y < 3; y++)
            {   
                
                for (int x = 0; x < maxPossition; x++)
                {
                    possition = (y * (maxPossition) + x);
                    snacksButtons[possition] = new MyButton();
                    snacksButtons[possition].Location = xy;
                    snacksButtons[possition].Price = tempSnackList[possition].Price;
                    snacksButtons[possition].Text = tempSnackList[possition].Name;
                    snacksButtons[possition].ProductId1 = tempSnackList[possition].ProductId;
                  //  snacksButtons[possition].Image = imageList1.Images[counter];
                    snacksButtons[possition].Image = imageList1.Images[tempSnackList[possition].ProductId - 1];
                    snacksButtons[possition].Size = new System.Drawing.Size(wOfButton, hOfButton);
                    tabPage1.Controls.Add(snacksButtons[possition]);
                    snacksButtons[possition].Click += new EventHandler(onClick);
                    xy.X += space;
                    counter++;
                    if (counter >=12)
                    {
                        counter = 0;
                    }
                }
                xy.Y += space;
                xy.X = 10;
                
            }
        
        }
        public  void getAllDrinksFromDb()
        {
            int counter = 0;
            MyButton[] drinksButtons = new MyButton[100];
            int wOfButton = 110; //width
            int hOfButton = 100; //hight
            Point xy = new Point(10, 10);
            int space = 130;
            int maxPossition = 4;
            List<Drink> tempDrinksList = bar.GetAllDrinks();
            int possition;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < maxPossition; x++)
                {
                    possition = (y * (maxPossition) + x);
                    drinksButtons[possition] = new MyButton();
                    drinksButtons[possition].Location = xy;
                    drinksButtons[possition].Price = tempDrinksList[possition].Price;
                    drinksButtons[possition].Text = tempDrinksList[possition].Name;
                    drinksButtons[possition].ProductId1 = tempDrinksList[possition].ProductId;
                    drinksButtons[possition].Image = imageList2.Images[(tempDrinksList[possition].ProductId -13)  ];
                    drinksButtons[possition].Size = new System.Drawing.Size(wOfButton, hOfButton);
                    tabPage2.Controls.Add(drinksButtons[possition]);
                    drinksButtons[possition].Click += new EventHandler(onClick);
                    xy.X += space;
                    counter++;
                    if (counter >= 12)
                    {
                        counter = 0;
                    }
                }
                xy.Y += space;
                xy.X = 10;
            }
        }

        private void onClick(object sender, EventArgs e)
        {
          
          quanTextbox = Convert.ToInt16(numericUpDown1.Value);
          holder1 = ((MyButton)sender).Text;
          holder2 = ((MyButton)sender).Price;
          produrcID = ((MyButton)sender).ProductId1;
          
          //client = bar.SearchClient(myRfid);

          if (tabControl1.SelectedTab == tabPage1)
          {
              s = new Snack(produrcID, holder1, quanTextbox, holder2, true, "");
              orderLine = new OrderLine(holder1, quanTextbox, s);
              order.AddOrderLine(orderLine);
              listBox1.Items.Add(orderLine.AsString());
              double p = 0;
              foreach (OrderLine item in order.getAllOrderLines())
              {
                  p += item.Price * item.Quantity;
              }
              label4.Text = "Total: € " + p;
          }
          else if (tabControl1.SelectedTab == tabPage2)
          {
              d = new Drink(produrcID, holder1, quanTextbox, holder2, false, "");
              orderLine = new OrderLine(d.Name, quanTextbox, d);
              order.AddOrderLine(orderLine);
              listBox1.Items.Add(orderLine.AsString());
              double p = 0;
              foreach (OrderLine item in order.getAllOrderLines())
              {
                  p += item.Price * item.Quantity;
              }
              label4.Text = "Total: € " + p;
          }
          
          
          // bar.MakeOrderLine(orderLine);
          
              
        }
        private void btnx_Click(object sender, EventArgs e)
        {

            totalprice = 0;
            try
            {
                int i = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(i);
                order.RemoveOrderLine(i);
                foreach (OrderLine item in order.getAllOrderLines())
                {
                    totalprice += item.OrderLineTotal();
                }
                label4.Text = "Total: €" + totalprice.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Please select which orderline to remove.");
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Balance: €";
            label1.Text = "Account: " ;
            label4.Text = "Total: €";
            order.getAllOrderLines().Clear();
            listBox1.Items.Clear();
            pictureBox1.BackColor = Color.Gray;
            order = new Order();
        }
       
    }
}
