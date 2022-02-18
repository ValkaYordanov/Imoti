using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class Parcel : Property
    {
        public bool isInRegulation;
        private TypeOfParcel typeOfParcel;
        public Parcel(string description, string address, double area, Agent agentForProperty, TypeOfParcel typeOfParcel, bool isInRegulation, decimal priceOfTheProperty, Seller seller)
   : base(description, address, area, agentForProperty, priceOfTheProperty, seller)
        {
            this.isInRegulation = isInRegulation;
            this.typeOfParcel = typeOfParcel;
        }
    }
}
