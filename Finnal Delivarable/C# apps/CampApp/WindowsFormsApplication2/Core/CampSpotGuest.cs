using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class CampSpotGuest
    {
        private int campId;
        private int accountNumber;



        public int CampId { get { return campId; } }
        public int AccountNumber { get { return accountNumber; } }


        public CampSpotGuest(int campId, int accountNumber)
        {
            this.accountNumber = accountNumber;
            this.campId = campId;
        }
    }
}
