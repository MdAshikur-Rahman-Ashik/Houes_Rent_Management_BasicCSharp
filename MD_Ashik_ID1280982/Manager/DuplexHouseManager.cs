using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Manager
{
    public class DuplexHouseManager : IHouseManager
    {
        public decimal GetPay()
        {
            
            double texPcnt = .50 ;
            double basic = 20000;
            double pay = basic * texPcnt;
            return (decimal)pay;
           

        }

        public decimal GetUtility()
        {
            double waterBill = 5000;
            double gasBill = 350;
            double UBill = waterBill + gasBill;
            return (decimal)UBill;
        }
        public decimal SwimingPoolCost()
        {
            return 5000;
        }
    }
}
