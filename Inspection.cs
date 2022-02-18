using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class Inspection
    {
        private Property property;
        private Agent agent;
        private Buyer buyer;
        private DateTime dateOfInspection;

        public Inspection(Property property, Agent agent, Buyer buyer, DateTime dateOfInspection)
        {
            this.property = property;
            this.agent = agent;
            this.buyer = buyer;
            this.dateOfInspection = dateOfInspection;
        }

        public Property GetProperty()
        {
            return property;
        }
        public Agent GetAgent()
        {
            return agent;
        }
    }
}
