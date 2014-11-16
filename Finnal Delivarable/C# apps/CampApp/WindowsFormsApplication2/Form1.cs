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


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Point[] road;  // points for drawing road (red line)
        Point[] housePoints; // points for creating houses housesRects 
        Rectangle[] housesRects; // Rectangls for Drowing house pictures on the map
        Pen roadPen;                // pen for drawing road
        static Image house;         // house picture
        Rectangle houseRect;        
        static Size houseSize= new Size(60,60);//house size

        private RFID ConnectedRFIDReader;  
        string theRFIDstring;           //RFID String
        DBhelper connectionDB;
        Client tempClient;
        CampHost tempCampHost;          //tempValue
        CampSpotGuest tempCampSpotGuest;//tempValue
        bool assignOtherGuests;         //if Client is Host value = true   else false
        List<CampHost> tempCampHostList;  //list with all clients who bought camping spot
        public Form1()
        {
            InitializeComponent();
            AssignHouseRects();


            try
            {
                // Creating RFID reader and adding the events needed
                ConnectedRFIDReader = new RFID();
                ConnectedRFIDReader.Attach += new AttachEventHandler(IsAttached);
                ConnectedRFIDReader.Detach += new DetachEventHandler(IsDetached);
                ConnectedRFIDReader.Tag += new TagEventHandler(ProcessThisTag);

            }
            catch (PhidgetException)
            {
                MessageBox.Show("error at start-up.");
            }
            // running readchip
            connectionDB = new DBhelper();
            tempCampHostList = connectionDB.AllCampHost();
            assignOtherGuests = false;
            readchip();

        }
        public void AssignHouseRects()
        {
            houseRect = new Rectangle(new Point(9, 80), houseSize);
            house = Bitmap.FromFile("../../pic/HouseBlack.png");

            roadPen = new Pen(Color.Brown, 12);
            road = new Point[]
            {new Point(0,280),
            new Point(100,280),
            new Point(100,80),
            new Point(540,80),
            new Point(540,450),
            new Point(100,450),
            new Point(100,280)
            };
            housePoints = new Point[] 
            { 
                new Point(10,100),
                new Point(10,10),
                new Point(100,10),
                new Point(190,10),
                new Point(280,10),
                new Point(370,10),
                new Point(460,10),
                new Point(550,10),
                new Point(550,100),
                new Point(550,190),
                new Point(550,280),
                new Point(550,370),
                new Point(550,460),
                new Point(460,460),
                new Point(370,460),
                new Point(280,460),
                new Point(190,460),
                new Point(100,460),
                new Point(10,460),
                new Point(10,370),
                new Point(10,286),

            };
            int iii = 0;
            housesRects = new Rectangle[housePoints.GetLength(0)];
            foreach (Point p in housePoints)
            {
                housesRects[iii] = new Rectangle(p, houseSize);
                iii++;
            }
        }
        

        private void readchip()
        {
            // Readchip is method for detecting RFID chips 
            try
            {
                ConnectedRFIDReader.open();
                ConnectedRFIDReader.waitForAttachment(1500);
                //set an action
                //System.Windows.Forms.MessageBox.Show("an RFID-reader is found and opened.");

                ConnectedRFIDReader.Antenna = true;
                ConnectedRFIDReader.LED = true;
            }
            catch (PhidgetException) 
            {
                labelRFID.Text = "RFID detached!!!";
            }            
         }

        private void IsAttached(object sender, AttachEventArgs e)
        {
            //showing if RFID scanners are attached
           // MessageBox.Show("RFIDReader attached!");
            labelRFID.Text = "RFID attached";
            readchip();
        }

        private void IsDetached(object sender, DetachEventArgs e)
        {
            //showing if RFID scaners are detached
            //MessageBox.Show("RFIDReader detached!");
            labelRFID.Text = "RFID detached!!!";
        }

        public void ProcessThisTag(object sender, TagEventArgs e)
        {
            // show current RFID tag to label
            theRFIDstring = Convert.ToString(e.Tag);
            // just test
            tempClient = null;
            tempCampSpotGuest = null;

            if ((tempClient = connectionDB.SearchClient(theRFIDstring)) != null) // if RFID is assigned 
            { 
                if (!assignOtherGuests) // if assigning other guest
                {
                    tempCampHost = null;
                    
                    if ((tempCampHost = connectionDB.SearchCampHost(tempClient.AccountNumber)) != null) // check if Client payed for camp spot
                    {
                        groupBox1.BackColor = Color.Green;
                        groupBox2.BackColor = Color.Gray;
                        HostName.Text = "Name: " + tempClient.First_name;
                        NrOfGuest.Text = "Guest to assign :" + tempCampHost.NumberOfGuests.ToString();
                        CampSpotNumber.Text = "Number: " + tempCampHost.Camp_id.ToString();

                        if (tempCampHost.numberOfGuests > 0)                // checks if he stil have some guest to assign
                        {
                            assignOtherGuests = true;       // next rfid (if in db) will be assigned to same camp spot as HOST
                            LatterButton.Visible = true;
                        }
                        

                    }
                    else if ((tempCampSpotGuest = connectionDB.SearchCampGuest(tempClient.AccountNumber)) != null) //checks if client is assigned to any camp spot
                    {
                        groupBox1.BackColor = Color.Yellow;
                        HostName.Text = "Name: " + tempClient.First_name;
                        NrOfGuest.Text = " ";
                        groupBox2.BackColor = Color.Green;
                        CampSpotNumber.Text = "Number: " + tempCampSpotGuest.CampId;
                    }
                    else {    // Client is in db but not assiged to any camp spot ar have payed for one
                        groupBox1.BackColor = Color.Red;
                        groupBox2.BackColor = Color.Red;

                        HostName.Text = "..";
                        NrOfGuest.Text = "..";
                        CampSpotNumber.Text = "..";
                        MessageBox.Show(tempClient.First_name+ " is not assignet to any Camp Spot Or had payed for one!");
                        }
                }
                else 
                {
                    if (tempCampHost.numberOfGuests > 0) { //check if there is still guest left to assign
                connectionDB.AssignGuest(tempCampHost, tempClient.AccountNumber);
                groupBox1.BackColor = Color.Gray;
                HostName.Text = "Name: " + tempClient.First_name;
                groupBox2.BackColor = Color.Green;
                CampSpotNumber.Text = "Number: " + tempCampHost.Camp_id;
                tempCampHost.numberOfGuests --;
                NrOfGuest.Text = tempCampHost.numberOfGuests.ToString();}
                    else                
                    {
                    assignOtherGuests = false;
                    LatterButton.Visible = false; }
                
                }
            }
            else // rfid is not assigned to any client
            {
                groupBox1.BackColor = Color.Red;
                groupBox2.BackColor = Color.Red;
                HostName.Text = "RFID is not registered!";
                NrOfGuest.Text = "...";
                CampSpotNumber.Text = "..";
                MessageBox.Show("RFID is not registered!"); 
            }

            MapPictureBox.Refresh();
            

        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            assignOtherGuests = false;
            LatterButton.Visible = false;
            tempCampHost = null;
           // MapPictureBox.Refresh();
        }

        private void MapPictureBox_Paint(object sender, PaintEventArgs e)
        {

            if (tempCampHost!=null)
            { e.Graphics.DrawRectangle(roadPen, housesRects[tempCampHost.Camp_id-1]); }
            if (tempCampSpotGuest != null)
            { e.Graphics.DrawRectangle(roadPen, housesRects[tempCampSpotGuest.CampId - 1]); }

                int i = 0;
                e.Graphics.DrawLines(roadPen,road);
                e.Graphics.DrawString("YOU ARE HERE", SystemFonts.StatusFont, Brushes.Red, new Rectangle(40, 200,40,50));
                foreach (Rectangle rec in housesRects) 
                {i++;
                    e.Graphics.DrawImage(house, rec);
                    e.Graphics.DrawString(i.ToString(), SystemFonts.MenuFont, Brushes.Black, rec.Location);
                }
                Point guests;
                foreach (CampHost campH in tempCampHostList)
                {
                    guests = new Point((housesRects[campH.Camp_id - 1].Location.X)+50,housesRects[campH.Camp_id - 1].Location.Y );
                    e.Graphics.DrawString(campH.numberOfGuests.ToString(), SystemFonts.MenuFont, Brushes.Red, guests); }

            
        }
    }
}
