using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Statistics
    {
                
        public int VisitorsTotal;
        public int VisitorsInEvent;
        public int MoneySpend;
        public int TotalMoney;
        public int maleFemale;

        public Statistics(int VisitorsTotal, int VisitorsInEvent, int MoneySpend, int TotalMoney,int maleFemale)
        {
            this.VisitorsTotal = VisitorsTotal;
            this.VisitorsInEvent = VisitorsInEvent;
            this.MoneySpend = MoneySpend;
            this.TotalMoney = TotalMoney;
            this.maleFemale = maleFemale;
        }
    }
}
