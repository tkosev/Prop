using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class CampHost
    {   
        private int accountNumber;
        public int numberOfGuests;
        private int camp_id;


        public int AccountNumber { get { return accountNumber; } }
        public int NumberOfGuests { get { return numberOfGuests; } }
        public int Camp_id { get { return camp_id; } }


        public CampHost(int accountNumber, int numberOfGuests, int camp_id)
        {
            this.accountNumber = accountNumber;
            this.numberOfGuests = numberOfGuests;
            this.camp_id = camp_id;
        }
    }
}
