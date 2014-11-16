using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Client
    {
        private int accountNumber;
        private string firstName;
        private string lastName;
        private string address;
        //private double moneyBalance;
        //private bool inEvent;

        public int AccountNumber { get { return accountNumber; } }
        public string First_name { get { return firstName; } }
        public string Last_name { get { return lastName; } }
        public string Address { get { return address; } }
        //public double MoneyBalance { get { return moneyBalance; }}
        //public bool InEvent { get { return inEvent; } }

        public Client(int accountNumber, string firstName)
        {
            this.accountNumber = accountNumber;
            this.firstName = firstName;
        }
        public Client(int accountNumber, string firstName, string lastName, string address)
        {
            this.accountNumber = accountNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
        }
    }
    

}
