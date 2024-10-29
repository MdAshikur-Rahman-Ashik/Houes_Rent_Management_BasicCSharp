using MD_Ashik_ID1280982.Entitites;
using MD_Ashik_ID1280982.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Factory
{
    public class FlatHouseFactory : BaseHouseFactory
    {
        public FlatHouseFactory(HouseDetailes hdf) : base(hdf)
        {
        }

        public override IHouseManager Create()
        {
            FlatHouseManager manager = new FlatHouseManager();  
            return manager;
        }
    }
}
