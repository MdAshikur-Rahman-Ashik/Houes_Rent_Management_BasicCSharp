using MD_Ashik_ID1280982.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Repository
{
    public class HouseRepository : IHouseRentRepository
    {
        private List<HouseDetailes> houseList;
        public HouseRepository()
        {
            houseList = new List<HouseDetailes>()
            {
              new HouseDetailes() { Id=1,Name="Mannat",Address="Mumbai",HouseCatagory=HouseCatagory.Duplex},
              new HouseDetailes() { Id=2,Name="Mollah Tower",Address="Narayanganj",HouseCatagory=HouseCatagory.Flat},
              new HouseDetailes() { Id=3,Name="Mojib Tower",Address="Rupganj",HouseCatagory=HouseCatagory.Duplex}
            };
        }
        public HouseDetailes CreateHouse(HouseDetailes house)
        {
            HouseDetailes existingHouse = ((from e in houseList
                                            orderby e.Id descending
                                            select e).Take(1)).Single() as HouseDetailes;
            house.Id=existingHouse.Id + 1 ;
            houseList.Add(house);
            return house;
        }

        public HouseDetailes DeleteHouse(int id)
        {
            HouseDetailes deleteHouse = GetHouse(id);
            if (deleteHouse != null)
            {
                houseList.Remove(deleteHouse);
            }
            return deleteHouse;
        }

        public HouseDetailes GetHouse(int id)
        {
            var house = (from h in houseList where h.Id == id select h).Single();
            return house;
        }

        public IEnumerable<HouseDetailes> GetHouseList()
        {
            return from rows in houseList select rows;
        }

        public HouseDetailes UpdateHouse(HouseDetailes house)
        {
            HouseDetailes uphouse = GetHouse(house.Id);
            if (uphouse != null)
            {
                uphouse.Id = house.Id;
                uphouse.Name = house.Name;
                uphouse.Address = house.Address;
                uphouse.HouseCatagory = house.HouseCatagory;
                uphouse.BasicRent = house.BasicRent;
                uphouse.GerdernCost = house.GerdernCost;
                uphouse.SwimingPoolCost = house.SwimingPoolCost;
                uphouse.GarageCost = house.GarageCost;
            }
            return uphouse;
        }
    }
}
