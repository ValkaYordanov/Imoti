using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class Agency
    {
        private string name;
        private string address;
        private string telefonNumber;
        private decimal agencyBudget;

        public List<Property> catalogOfProperties = new List<Property>();
        public List<Agent> listOfAgents = new List<Agent>();

        private static Agency instance = null;
        private Agency() { }

        public static Agency Instance
        {
            get
            {
                if (instance == null)
                    instance = new Agency();
                return instance;

            }
        }


        public void SetAgencyBudget(decimal budget)
        {
            this.agencyBudget = budget;
        }

        public decimal GetAgencyBudjet()
        {
            return agencyBudget;
        }
    }
}
