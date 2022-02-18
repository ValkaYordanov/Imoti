using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class Seller : Client
    {
        private Property property;

        public Seller CreateSeller()
        {
            Seller seller = new Seller();
            Property propertyObj = new Apartment();

            int indexOfRandomName = random.Next(listOfNames.Count);
            int indexOfRandomTelefonNumber = random.Next(listOfTelefonNumber.Count);

            string name = listOfNames[indexOfRandomName];
            string telefonNumber = listOfTelefonNumber[indexOfRandomTelefonNumber];

            seller.SetName(name);
            seller.SetTelefonNumber(telefonNumber);

            var property = propertyObj.CreateProperty(seller);
            seller.SetProperty(property);

            return seller;
        }

        public void SetProperty(Property property)
        {
            this.property = property;
        }

        public Property GetProperty()
        {
            return property;
        }
    }
}
