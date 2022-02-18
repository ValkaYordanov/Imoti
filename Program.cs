using System;
using System.Collections.Generic;
using System.Linq;

namespace Imoti
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<string> listOfNames = new List<string> { "Valentin", "Georgi", "Petyr", "Galena", "Ivan", "Strahilka", "Petra", "Danch", "Gery", "Vasil", "Ivanka" };
            List<string> listOfAddresses = new List<string> { "Varna", "Sofia", "Veliko Tyrnovo", "Byrgas", "Smolqn", "Kazanlak", "Pernik" };
            List<Seller> listOfSellers = new List<Seller>();
            List<Buyer> listOfBuyers = new List<Buyer>();
            Agency agency = Agency.Instance;

            for (int i = 0; i < 5; i++)
            {
                int indexOfRandomName = random.Next(listOfNames.Count);
                int indexOfRandomAddress = random.Next(listOfAddresses.Count);
                string name = listOfNames[indexOfRandomName];
                string address = listOfAddresses[indexOfRandomAddress];
                Agent agent = new Agent(name, address);
                agency.listOfAgents.Add(agent);
            }

            for (int i = 0; i < 30; i++)
            {
                Seller seller = new Seller();
                seller = seller.CreateSeller();
                listOfSellers.Add(seller);
            }

            for (int i = 0; i < listOfSellers.Count; i++)
            {
                Agent agentObj = new Agent(); ;
                var randomAgent = agentObj.GetRandomAgent(agency.listOfAgents);
                agency.catalogOfProperties.Add(listOfSellers[i].GetProperty());
                randomAgent.SetBuyersOrSellers(listOfSellers[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                Buyer buyer = new Buyer();
                buyer = buyer.CreateBuyer();
                listOfBuyers.Add(buyer);
            }

            for (int i = 0; i < listOfBuyers.Count; i++)
            {
                listOfBuyers[i].MakeRequestForProperty();
            }

            for (int i = 0; i < listOfBuyers.Count; i++)
            {
                listOfBuyers[i].MakeRequestForInspection();
            }

            for (int i = 0; i < listOfBuyers.Count; i++)
            {
                listOfBuyers[i].BuyNewProperty();
            }

            Console.WriteLine("Agency budget: " + Math.Round(agency.GetAgencyBudjet(), 2) + "$ money");


            List<Agent> listAgents = agency.listOfAgents.OrderBy(agent => agent.GetAgentBudjet()).ToList();

            foreach (var agent in listAgents)
            {
                Console.WriteLine("Agent " + agent.GetName() + " has: " + Math.Round(agent.GetAgentBudjet(),2) + "$ money.");
            }
        }
    }
}
