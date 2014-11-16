using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Client
    {
        private int accountNumber;
        private string firstName;
        //private double moneyBalance;
        //private bool inEvent;

        public int AccountNumber { get { return accountNumber; } }
        public string First_name { get { return firstName; } }
        //public double MoneyBalance { get { return moneyBalance; }}
        //public bool InEvent { get { return inEvent; } }

        public Client(int accountNumber, string firstName)
        {
            this.accountNumber = accountNumber;
            this.firstName = firstName;
        }
    }
    

}
