using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class House : Property
    {

        private TypeOfHouse typeOfHouse;
        private TypeOfConstruction typeOfConstruction;
        private int numberOfParkingSpaces;
        private double yardArea;

        public House(string description, string address, double area, Agent agentForProperty, TypeOfHouse typeOfHouse, TypeOfConstruction typeOfConstruction, int numberOfParkingSpaces, double yardArea, decimal priceOfTheProperty, Seller seller)
           : base(description, address, area, agentForProperty, priceOfTheProperty, seller)
        {
            this.typeOfHouse = typeOfHouse;
            this.typeOfConstruction = typeOfConstruction;
            this.numberOfParkingSpaces = numberOfParkingSpaces;
            this.yardArea = yardArea;
        }
    }
}
