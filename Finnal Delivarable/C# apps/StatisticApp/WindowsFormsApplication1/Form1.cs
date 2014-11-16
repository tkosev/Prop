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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        DBhelper connectionDB;
        Statistics stats; //Object with information about statistics
        
        List<Client> temClientList;
        private RFID ConnectedRFIDReader;
        string theRFIDstring;
        bool assignRFID; // if next rfid will be assigned for first user in the list where RFID is null

        public Form1()
        {
            InitializeComponent();
            connectionDB = new DBhelper();
            GetClientsWithNoRFIDInListBox();
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
            readchip();
            assignRFID = false;

        }
        private void readchip()
        {
            // Readchip is method for detecting RFID chips 
            try
            {
                ConnectedRFIDReader.open();
                ConnectedRFIDReader.waitForAttachment(1500);
                //set an action

                ConnectedRFIDReader.Antenna = true;
                ConnectedRFIDReader.LED = true;
            }
            catch (PhidgetException)
            {
                labelRFID.Text = "RFID detached!!!";
            }
        }
        private void IsDetached(object sender, DetachEventArgs e)
        {
            //showing if RFID scaners are detached
            
            labelRFID.Text = "RFID detached!!!";
        }
        private void IsAttached(object sender, AttachEventArgs e)
        {
            //showing if RFID scanners are attached
            
            labelRFID.Text = "RFID attached";
            readchip();
        }

        public void ProcessThisTag(object sender, TagEventArgs e)
        {
            if (assignRFID == true)
            {
                // show current RFID tag to label
                theRFIDstring = Convert.ToString(e.Tag);
                // just test
                //tempClient = null;
                connectionDB.AssignRFID(temClientList[0].AccountNumber, theRFIDstring);
                assignRFID = false;
                button1.Visible = true;
                GetClientsWithNoRFIDInListBox();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void buttonGetStatistics_Click(object sender, EventArgs e) //get statistic info and Draw charts
        {
            stats = connectionDB.AskForStatistics();

            this.chartVisits.Series["visits"].Points.Clear();
            this.chartVisits.Series["visits"].Points.AddXY("In Event", stats.VisitorsInEvent);
            this.chartVisits.Series["visits"].Points.AddXY("Not InEvent ", stats.VisitorsTotal - stats.VisitorsInEvent);
            this.labelInEvent.Text = " Total Visitors " + stats.VisitorsTotal+ ", in event "+stats.VisitorsInEvent  ;


            

            this.ChartMoney.Series["Money In Accounts"].Points.AddXY(DateTime.Now.ToString("HH:mm:ss tt"), stats.TotalMoney);
            this.ChartMoney.Series["Money Spent"].Points.AddXY("Spent", stats.MoneySpend);
            this.labelMoney.Text = "Money in accounts: " + stats.TotalMoney+", already spend: "+stats.MoneySpend;

            this.ChartMaleFemale.Series["Male/Female"].Points.Clear();
            this.ChartMaleFemale.Series["Male/Female"].Points.Clear();
            this.ChartMaleFemale.Series["Male/Female"].Points.AddXY("Male", stats.maleFemale);
            this.ChartMaleFemale.Series["Male/Female"].Points.AddXY("Female",stats.VisitorsTotal-stats.maleFemale);
            this.labelMaleFemale.Text = "Totaly " + stats.maleFemale +" Male registered  and " +(stats.VisitorsTotal - stats.maleFemale)+ "  Female Registered: " ;
        }

        private void GetClientsWithNoRFIDInListBox()  // gets List of Clients who is not assigned to any RFID 
        
        {
            temClientList = connectionDB.SearchClientWithNoRFID();
            listBox1.Items.Clear();
            foreach (Client c in temClientList) 
            {
                listBox1.Items.Add(c.AccountNumber +" " +c.Last_name +" "+ c.First_name  );
            }
            label1.Text = temClientList[0].AccountNumber + " " + temClientList[0].Address; 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            assignRFID = true;
            button1.Visible = false;
        }

    }
}
