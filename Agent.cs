using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class Agent
    {
        private string name;
        private string telefonNumber;
        public List<Seller> listOfSellers = new List<Seller>();
        public List<Buyer> listOfBuyers = new List<Buyer>();
        public List<Inspection> listOfInspections = new List<Inspection>();
        private decimal agentBudget;


        public Agent (string name, string telefonNumber)
        {
            this.name = name;
            this.telefonNumber = telefonNumber;
        }

        public Agent()
        {
        }

        public Agent GetRandomAgent(List<Agent> listOfAgents)
        {
            Random random = new Random();

            int randomAgentIndex = random.Next(listOfAgents.Count);

            return listOfAgents[randomAgentIndex];
        }

        public void SetBuyersOrSellers(Client client)
        {
            if(client is Buyer)
            {
                listOfBuyers.Add((Buyer)client);
            }
            else
            {
                listOfSellers.Add((Seller)client);
            }
        }

        public void SetAgentBudget(decimal budget)
        {
            this.agentBudget = budget;
        }

        public decimal GetAgentBudjet()
        {
            return agentBudget;
        }

        public string GetName()
        {
            return name;
        }
    }
}
