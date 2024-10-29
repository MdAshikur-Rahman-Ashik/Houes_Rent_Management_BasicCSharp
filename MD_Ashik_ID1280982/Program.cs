
using MD_Ashik_ID1280982.Entitites;
using MD_Ashik_ID1280982.Factory;
using MD_Ashik_ID1280982.Manager;
using MD_Ashik_ID1280982.Repository;
using System;
using System.Collections.Generic;

namespace MD_Ashik_ID1280982
{
    internal class Program
    {
        public static HouseRepository repo = new HouseRepository();

        static void Main(string[] args)
        {
            try
            {
                DoTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void DoTask()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t****** Project C# ******");
            Console.WriteLine("\t\t\t\t****** House Rent Project ******");
            Console.WriteLine("\t\t\t\t****** Md.Ashikur Rahman Ashik ******");
            Console.WriteLine("\t\t\t\t****** ID-1280982 ******");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t====== House Management ======");
            Console.WriteLine("\t\t\t\t------------------------------\n");
            Console.WriteLine("\t\t\t\tHow many operations would you like to perform?\n");

            int cont = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cont; i++)
            {
                Console.WriteLine("\t\t\t\tSelect Operation\n");
                Console.WriteLine("\t\tHint:\nSelect-1\nCreate-2\nUpdate-3\nDelete-4");
                int opeCount = Convert.ToInt32(Console.ReadLine());
                switch (opeCount)
                {
                    case 1:
                        ShowAllHouse();
                        break;
                    case 2:
                        CreateHouse();
                        break;
                    case 3:
                        UpdateHouse();
                        break;
                    case 4:
                        DeleteHouse();
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }

        private static void DeleteHouse()
        {
            Console.WriteLine("Enter Id");
            int s = Convert.ToInt32(Console.ReadLine());
            HouseDetailes deleteHouse = new HouseDetailes { Id = s };
            deleteHouse = repo.DeleteHouse(deleteHouse.Id);

            Console.WriteLine("Deleted Successfully");
            ShowAllHouse();
        }

        private static void UpdateHouse()
        {
            HouseDetailes upHouse = new HouseDetailes();
            Console.WriteLine("Enter Id");
            upHouse.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            upHouse.Name = Console.ReadLine();
            Console.WriteLine("Enter Address");
            upHouse.Address = Console.ReadLine();

        EnterType:
            Console.WriteLine("Enter Category (1 = Duplex, 2 = Flat)");
            string typeRead = Console.ReadLine();

            HouseCatagory houseCatagory;
            try
            {
                houseCatagory = (HouseCatagory)Enum.Parse(typeof(HouseCatagory), typeRead);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid selection.");
                goto EnterType;
            }
            upHouse.HouseCatagory = houseCatagory;

            // Set BasicRent based on House Category
            BaseHouseFactory houseFactory = new HouseManagerFactory().CreateFactory(upHouse);
            houseFactory.ApplyRent();

            upHouse = repo.UpdateHouse(upHouse);
            ShowAllHouse();
        }

        private static void CreateHouse()
        {
            HouseDetailes hdf = new HouseDetailes();
            Console.WriteLine("Enter Name");
            hdf.Name = Console.ReadLine();
            Console.WriteLine("Enter Address");
            hdf.Address = Console.ReadLine();

        EnterType:
            Console.WriteLine("Enter Category (1 = Duplex, 2 = Flat)");
            string typeRead = Console.ReadLine();

            HouseCatagory houseCatagory;
            try
            {
                houseCatagory = (HouseCatagory)Enum.Parse(typeof(HouseCatagory), typeRead);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid selection.");
                goto EnterType;
            }

            hdf.HouseCatagory = houseCatagory;

            // Set BasicRent based on House Category
            BaseHouseFactory houseFactory = new HouseManagerFactory().CreateFactory(hdf);
            houseFactory.ApplyRent();

            repo.CreateHouse(hdf);
            ShowAllHouse();
        }

        private static void ShowAllHouse()
        {
            Console.WriteLine("-------------------------------------------------");
            IEnumerable<HouseDetailes> houseList = repo.GetHouseList();
            Console.WriteLine(string.Format("|{0,5}|{1,15}|{2,-20}|{3,10}|{4,10}|{5,10}|{6,15}|{7,15}|",
                "ID", "Name", "Address", "HouseCategory", "BasicRent", "Utility", "GarageCost", "SpecialFeatureCost"));
            Console.WriteLine();

            foreach (HouseDetailes item in houseList)
            {
                IHouseManager houseManager;

                if (item.HouseCatagory == HouseCatagory.Duplex)
                {
                    houseManager = new DuplexHouseManager();
                }
                else if (item.HouseCatagory == HouseCatagory.Flat)
                {
                    houseManager = new FlatHouseManager();
                }
                else
                {
                    houseManager = null;
                }

                decimal utilityCost = houseManager?.GetUtility() ?? 0;
                decimal specialFeatureCost = 0;
                decimal garageCost = 0;

                if (houseManager is DuplexHouseManager duplexManager)
                {
                    specialFeatureCost = duplexManager.SwimingPoolCost();
                }
                else if (houseManager is FlatHouseManager flatManager)
                {
                    garageCost = flatManager.GarageCost();
                    specialFeatureCost = flatManager.GerdernCost();
                }

                Console.WriteLine(string.Format("|{0,5}|{1,15}|{2,-20}|{3,10}|{4,10}|{5,10}|{6,15}|{7,15}|",
                    item.Id, item.Name, item.Address, item.HouseCatagory, item.BasicRent, utilityCost, garageCost, specialFeatureCost));
            }
        }
    }
}
