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


namespace MateriaStand.cs
{
    public partial class Form1 : Form
    {
        private RFID myRfidReader;
        private DataHelper connection;
        private MaterialStand material;
        private Material myMaterial;
        private Order order;
        private OrderLine orderline;
        bool ToBorrow;
        bool ToPay;
        bool Chek;
        string myRfid;
        private Client client;
        double toOther;


        public Form1()
        {
            connection = new DataHelper();
            InitializeComponent();
            DateTime d = new DateTime(1999, 6, 1);
            material = new MaterialStand();
            connection.connect();
            getAllDrinksFromDb();
            ToBorrow = false;
            ToPay = false;
            Chek = true;
            btnx.Enabled = false;
           // 
            if (material.CheckEmpty() == 0)
            {
                material.InitializeOrder(order, 777777,0);
            }
            try
            {
                myRfidReader = new RFID();
                myRfidReader.Tag += new TagEventHandler(MyRfidReader_Tag);
            }
            catch (PhidgetException e)
            {
               MessageBox.Show(e.Message);

            }
            ReadChip();
            
            connection = new DataHelper();
        }

        private void ReadChip()
        {
            try
            {
                myRfidReader.open();
                myRfidReader.waitForAttachment(3000);
                //MessageBox.Show("RFID scanner is found and open");
                myRfidReader.Antenna = true;
                myRfidReader.LED = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID scanner found");
            }
        }
        private void MyRfidReader_Tag(object sender, TagEventArgs e)
        {
            
            
            myRfid = Convert.ToString(e.Tag);
            client = material.SearchClient(myRfid);
            double pprice = 0;


            if (this.ToBorrow)
            {

                material.MakeOrder(order, client.AccountNumber, order.orderGetTotalPrice());
                foreach (OrderLine item in order.getAllOrderLines())
                {

                    material.MakeOrderLine(item);
                    material.BorrowMaterial(item.Material.Material_id, 1);

                }
                pictureBox1.BackColor = Color.Green;
                this.ToBorrow = false;
                label4.Text = "Total: " + (order.orderGetTotalPrice()).ToString();
                label1.Text = "Account: " + client.AccountNumber.ToString();
                label2.Text = "Balance: " + client.MoneyBalance.ToString();

            }
            else
            {
                if (material.PayOrderPrice(client.AccountNumber) == 0 && material.IsMaterial(client.AccountNumber))
                {
                    pictureBox1.BackColor = Color.Green;
                    MessageBox.Show("Nothing to pay");
                    button1.Enabled = false;
                    ToPay = false;
                }
                else
                {

                    listBox1.Items.Clear();
                    foreach (OrderLine item in material.getAllOrdersNotPayed(client.AccountNumber))
                    {
                        listBox1.Items.Add(item.AsString());
                        pprice += item.Price;

                    }
                    label1.Text = "Account: " + client.AccountNumber.ToString();
                    label2.Text = "Balance: " + client.MoneyBalance.ToString();
                    label4.Text = "Total price: " + pprice.ToString();
                    pictureBox1.BackColor = Color.Red;
                    toOther = pprice;
                    ToPay = true;
                    button1.Enabled = true;

                }


            }

                

        
        }

        public void getAllDrinksFromDb()
        {
            int counter = 0;
            MyButton[] materialButtons = new MyButton[100];
            int wOfButton = 110; //width
            int hOfButton = 100; //hight
            Point xy = new Point(10, 10);
            int space = 130;
            int maxPossition = 4;
            List<Material> tempMaterialList = material.getAllMaterials();
            int possition;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < maxPossition; x++)
                {
                    possition = (y * (maxPossition) + x);
                    materialButtons[possition] = new MyButton();
                    materialButtons[possition].Location = xy;
                    materialButtons[possition].Price = tempMaterialList[possition].Price;
                    materialButtons[possition].Text = tempMaterialList[possition].Name + "--" + tempMaterialList[possition].Description;
                    materialButtons[possition].Material_id = tempMaterialList[possition].Material_id;
                    materialButtons[possition].Image = imageList1.Images[counter];
                    materialButtons[possition].Description = tempMaterialList[possition].Description;
                    materialButtons[possition].Size = new System.Drawing.Size(wOfButton, hOfButton);
                    tabPage1.Controls.Add(materialButtons[possition]);
                    materialButtons[possition].Click += new EventHandler(onClick);
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
           int material_id = ((MyButton)sender).Material_id;
           string name = ((MyButton)sender).Name;
           string holder1 = ((MyButton)sender).Text;
           double price = ((MyButton)sender).Price;
           DateTime today = DateTime.Today;
           string description = ((MyButton)sender).Description;
          
               if (tabControl1.SelectedTab == tabPage1)
               {
                   if (Chek)
                   {
                       order = new Order();
                       this.ToBorrow = true;
                       btnx.Enabled = true;
                       Chek = false;
                   }
                   

                   myMaterial = new Material(material_id, name, price, today, null, description);
                   orderline = new OrderLine(description, myMaterial.Price, myMaterial);
                   order.AddOrderLine(orderline);
                   listBox1.Items.Add(myMaterial.ToString());
                   label4.Text = "Total: € " + order.orderGetTotalPrice().ToString();

               }
           
           
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            if (client.MoneyBalance > toOther && material.IsMaterial(client.AccountNumber))
                {
                   
                    material.ReduceMoneyBalance(myRfid, toOther);
                    material.Pay(client.AccountNumber);
                    foreach (OrderLine item in material.getAllOrdersNotPayed(client.AccountNumber))
                    {


                        material.ReturnMaterial(item.Material.Material_id, 0);

                    }
                    button1.Enabled = false;
                    ToPay = false;
                    listBox1.Items.Clear();
                    pictureBox1.BackColor = Color.Green;
                    label1.Text = "Account: " + client.AccountNumber;
                    label2.Text = "Ballance : "+ (client.MoneyBalance - toOther).ToString();
                    label4.Text = "You have payed : " + toOther.ToString();
                }
                else
                {
                    MessageBox.Show("Reacherge before trying to pay");
                }
                
                
                  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            label1.Text = "Account: ";
            label2.Text = "Ballance : ";
            label4.Text = "Total : 0";
            btnx.Enabled = false;
            Chek = true;
            ToBorrow = false;
            pictureBox1.BackColor = Color.Gray;
            listBox1.Items.Clear();
            order = null;
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            double total = 0;
            try
            {
                int i = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(i);
                order.RemoveOrderLine(i);
                foreach (OrderLine item in order.getAllOrderLines())
                {
                    total += item.Price;
                }
                label4.Text = "Total: €" + total.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Please select which orderline to remove.");
            }

        }

    }
}