using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public abstract class Client
    {
        protected string name;
        protected string telefonNumber;
        protected decimal budget;

        protected const int minClientBudget = 30000;
        protected const int maxClientBudget = 150000;

        protected Random random = new Random();
        protected List<string> listOfNames = new List<string> { "Valentin", "Georgi", "Petyr", "Galena", "Ivan", "Strahilka", "Petra", "Danch", "Gery", "Vasil", "Ivanka" };
        protected List<string> listOfTelefonNumber = new List<string> { "0885462851", "0889362851", "0885462851", "0885862851", "0885462861", "0885322851", "0985462991" };
        
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetTelefonNumber(string telefonNumber)
        {
            this.telefonNumber = telefonNumber;
        }

        public string GetTelefonNumber()
        {
            return telefonNumber;
        }

        public void SetBudget(decimal budget)
        {
            this.budget = budget;
        }

        public decimal GetBudjet()
        {
            return budget;
        }
    }
}
