using MD_Ashik_ID1280982.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Repository
{
    public interface IHouseRentRepository
    {
        IEnumerable<HouseDetailes> GetHouseList();
        HouseDetailes GetHouse(int id);
        HouseDetailes CreateHouse(HouseDetailes house);
        HouseDetailes UpdateHouse(HouseDetailes house);
        HouseDetailes DeleteHouse(int id);
    }
}
