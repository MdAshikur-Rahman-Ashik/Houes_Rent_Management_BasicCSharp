using MD_Ashik_ID1280982.Entitites;
using MD_Ashik_ID1280982.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Factory
{
    public class DuplexHouseFactory : BaseHouseFactory
    {
        public DuplexHouseFactory(HouseDetailes hdf) : base(hdf)
        {
        }

        public override IHouseManager Create()
        {
            DuplexHouseManager manager = new DuplexHouseManager();
           return manager;
        }
    }
}
