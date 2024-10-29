using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_Ashik_ID1280982.Entitites
{
    public class HouseDetailes
    {
        int id;
        string name;
        string address;
        HouseCatagory houseCatagory;
        decimal basicRent;
        public HouseDetailes()
        {
            
        }

        public HouseDetailes(int id, string name, string address, HouseCatagory houseCatagory, decimal basicRent = 0)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.houseCatagory = houseCatagory;
            this.BasicRent = basicRent;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public HouseCatagory HouseCatagory { get => houseCatagory; set => houseCatagory = value; }
        public decimal BasicRent { get => basicRent; set => basicRent = value; }

        public decimal GerdernCost { get; set; }
        public decimal SwimingPoolCost { get; set; }
        public decimal GarageCost { get; set; }
        
    }
}
