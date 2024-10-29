using MD_Ashik_ID1280982.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Factory
{
    public class HouseManagerFactory
    {
        public BaseHouseFactory CreateFactory(HouseDetailes hdf)
        {
            BaseHouseFactory returnValue = null;
            if (hdf.HouseCatagory== HouseCatagory.Flat)
            {
                returnValue = new FlatHouseFactory(hdf);
            }
            else if (hdf.HouseCatagory == HouseCatagory.Duplex)
            {
                returnValue = new DuplexHouseFactory(hdf);
            }
            return returnValue;
        }
    }
}
