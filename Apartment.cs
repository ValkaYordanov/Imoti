using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class Apartment : Property
    {
       
        private TypeOfApartment typeOfApartment;
        private TypeOfConstruction typeOfConstruction;

        public Apartment()
        {
        }

        public Apartment(string description, string address, double area, Agent agentForProperty, TypeOfApartment typeOfApartment, TypeOfConstruction typeOfConstruction, decimal priceOfTheProperty, Seller seller) 
            : base(description, address, area, agentForProperty, priceOfTheProperty, seller)
        {
            this.typeOfApartment = typeOfApartment;
            this.typeOfConstruction = typeOfConstruction;
        }
    }
}
