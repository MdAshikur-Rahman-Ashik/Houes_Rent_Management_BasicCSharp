using MD_Ashik_ID1280982.Entitites;
using MD_Ashik_ID1280982.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Factory
{
    public abstract class BaseHouseFactory
    {
         HouseDetailes _hdf;
        protected BaseHouseFactory(HouseDetailes hdf)
        {
            _hdf = hdf;
        }
        public abstract IHouseManager Create();
        public HouseDetailes ApplyRent()
        {
            IHouseManager manager = this.Create();
            _hdf.GerdernCost = manager.GetUtility();
            _hdf.SwimingPoolCost = manager.GetPay();
            return _hdf;
        }
    }
}
