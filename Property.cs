using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public abstract class Property
    {
        Random random = new Random();
        private string description;
        private string address;
        private double area;
        private Agent agentForProperty;
        private decimal priceOfTheProperty;
        private Seller seller;
        public enum TypeOfApartment { Atelier = 1, Studio = 2, OneBedroom = 3, TwoBedroom = 4, Penthouse = 5 };
        public enum TypeOfHouse { LevelOfHouse = 1, WholeHouse = 2 };
        public enum TypeOfConstruction { EPK = 1, Brick = 2, Panel = 3, Loam = 4 };
        public enum TypeOfParcel { Fields = 1, Lawn = 2, Forests = 3 }
        private enum TypeOfPreperty { Apartment = 1, House = 2, Parcel = 3 };

        public Property(string description, string address, double area, Agent agentForProperty, decimal priceOfTheProperty, Seller seller)
        {
            this.description = description;
            this.address = address;
            this.area = area;
            this.agentForProperty = agentForProperty;
            this.priceOfTheProperty = priceOfTheProperty;
            this.seller = seller;
        }

        public Property() { }

        public Property CreateProperty(Seller seller)
        {
            Random random = new Random();
            int randomPropertyType = random.Next(1, 101);

            if (randomPropertyType <=33)
            {
                decimal price = random.Next(70000, 150000);
                TypeOfApartment typeOfApartment = GetTypeOfApartment();
                TypeOfConstruction typeOfConstruction = GetTypeOfConstruction();
                var agent = GetRandomAgent();
                Apartment apartment = new Apartment("Very good Apartment", "Varna, ul. Petra 20", 100.50, agent, typeOfApartment, typeOfConstruction,price, seller);
              
                return apartment;
            }
            else if (randomPropertyType >33 && randomPropertyType <= 66)
            {
                decimal price = random.Next(50000, 80000);
                TypeOfHouse typeOfHouse = GetTypeOfHouse();
                TypeOfConstruction typeOfConstruction = GetTypeOfConstruction();
                var agent = GetRandomAgent();
                House house = new House("Very good house to live", "Burgas, ul. Sharan 50", 150.75, agent, typeOfHouse, typeOfConstruction, 3, 20.20, price, seller);
                house.SetSeller(seller);
                return house;
            }
            else
            {
                decimal price = random.Next(30000, 85000);
                TypeOfParcel typeOfParcel = GetTypeOfParcel();
                var agent = GetRandomAgent();
                Parcel pacel = new Parcel("Beautiful place", "Sofia, Krasna Polqna", 500.00, agent, typeOfParcel, true, price, seller);
                pacel.SetSeller(seller);
                return pacel;

            }

        }

        private TypeOfParcel GetTypeOfParcel()
        {
            int randomType = random.Next(1, 4);

            if (randomType == (int)TypeOfParcel.Fields)
            {
                return TypeOfParcel.Fields;
            }
            else if (randomType == (int)TypeOfParcel.Lawn)
            {
                return TypeOfParcel.Lawn;
            }
            else 
            {
                return TypeOfParcel.Forests;
            }
          
        }

        private TypeOfHouse GetTypeOfHouse()
        {
            int randomType = random.Next(1, 3);

            if (randomType == (int)TypeOfHouse.LevelOfHouse)
            {
                return TypeOfHouse.LevelOfHouse;
            }
            else
            {
                return TypeOfHouse.WholeHouse;
            }

        }

        private TypeOfApartment GetTypeOfApartment()
        {

            int randomType = random.Next(1, 6);

            if (randomType == (int)TypeOfApartment.Atelier)
            {
                return TypeOfApartment.Atelier;
            }
            else if (randomType == (int)TypeOfApartment.Studio)
            {
                return TypeOfApartment.Studio;
            }
            else if (randomType == (int)TypeOfApartment.OneBedroom)
            {
                return TypeOfApartment.OneBedroom;
            }
            else if (randomType == (int)TypeOfApartment.TwoBedroom)
            {
                return TypeOfApartment.TwoBedroom;
            }
            else
            {
                return TypeOfApartment.Penthouse;
            }
        }

        private TypeOfConstruction GetTypeOfConstruction()
        {

            int randomType = random.Next(1, 5);

            if (randomType == (int)TypeOfConstruction.EPK)
            {
                return TypeOfConstruction.EPK;
            }
            else if (randomType == (int)TypeOfConstruction.Brick)
            {
                return TypeOfConstruction.Brick;
            }
            else if (randomType == (int)TypeOfConstruction.Panel)
            {
                return TypeOfConstruction.Panel;
            }
            else
            {
                return TypeOfConstruction.Loam;
            }
        }

        private Agent GetRandomAgent()
        {
            Agency agency = Agency.Instance;
            int randomAgent = random.Next(agency.listOfAgents.Count);
            var agent = agency.listOfAgents[randomAgent];

            return agent;
        }


        public decimal GetPriceOfTheProperty()
        {
            return priceOfTheProperty;
        }

        public Agent GetAgentForProperty()
        {
            return agentForProperty;
        }

        public void SetSeller(Seller seller)
        {
            this.seller = seller;
        }

        public Seller GetSeller()
        {
            return seller;
        }
    }
}
