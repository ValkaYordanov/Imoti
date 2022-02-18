using System;
using System.Collections.Generic;
using System.Text;

namespace Imoti
{
    public class Buyer : Client
    {
        public List<Inspection> listOfDoneInspections = new List<Inspection>();
        const int numberOfInspectionsToRequest = 3;
        const int percentForCommisionFromBuyer = 3;
        const int percentForCommisionFromSeller = 3;
        public Buyer CreateBuyer()
        {
            Buyer buyer = new Buyer();

            int indexOfRandomName = random.Next(listOfNames.Count);
            int indexOfRandomTelefonNumber = random.Next(listOfTelefonNumber.Count);

            string name = listOfNames[indexOfRandomName];
            string telefonNumber = listOfTelefonNumber[indexOfRandomTelefonNumber];

            buyer.SetName(name);
            buyer.SetTelefonNumber(telefonNumber);

            decimal budjet = ReturnRandomBudjet();
            buyer.SetBudget(budjet);

            return buyer;
        }

        private decimal ReturnRandomBudjet()
        {
            Random random = new Random();
            decimal budget = random.Next(minClientBudget, maxClientBudget);
            return budget;
        }

        public void MakeRequestForProperty()
        {
            Agency agency = Agency.Instance;
            Random random = new Random();

            int agentIndex = random.Next(agency.listOfAgents.Count);
            Agent agent = agency.listOfAgents[agentIndex];
            agent.SetBuyersOrSellers(this);
        }

        public void MakeRequestForInspection()
        {
            Random random = new Random();
            Agency agency = Agency.Instance;
            List<Property> tempListOfProperties = new List<Property>(agency.catalogOfProperties);

            for (int i = 0; i < numberOfInspectionsToRequest; i++)
            {
                int propertyIndex = random.Next(tempListOfProperties.Count);
                Property property = tempListOfProperties[propertyIndex];
                Agent Agent = property.GetAgentForProperty();

                DateTime start = new DateTime(2008, 1, 1);
                int range = (DateTime.Today - start).Days;
                DateTime date = start.AddDays(random.Next(range));

                if (property.GetPriceOfTheProperty() < this.GetBudjet())
                {
                    Inspection inspection = new Inspection(property, Agent, this, date);
                    this.listOfDoneInspections.Add(inspection);
                    Agent.listOfInspections.Add(inspection);
                    tempListOfProperties.Remove(property);
                }
            }

        }


        public void BuyNewProperty()
        {
            if (this.listOfDoneInspections.Count > 0)
            {


                Agency agency = Agency.Instance;
                Random random = new Random();
                int inspectionIndex = random.Next(this.listOfDoneInspections.Count);
                Property propertyToBuy = this.listOfDoneInspections[inspectionIndex].GetProperty();
                Agent agent = this.listOfDoneInspections[inspectionIndex].GetAgent();
                Seller seller = propertyToBuy.GetSeller();

                decimal moneyCommissionFromBuyer = propertyToBuy.GetPriceOfTheProperty() * percentForCommisionFromBuyer / 100;
                decimal moneyThatGoesToTheSeller = propertyToBuy.GetPriceOfTheProperty() - moneyCommissionFromBuyer;
                decimal moneyCommissionFromSeller = moneyThatGoesToTheSeller * percentForCommisionFromSeller / 100;

                decimal moneyForAgencyOrAgentFromBuyer = moneyCommissionFromBuyer / 2;
                decimal moneyForAgencyOrAgentFromSeller = moneyCommissionFromSeller / 2;

                this.SetBudget(this.GetBudjet() - propertyToBuy.GetPriceOfTheProperty());

                decimal moneyAfterCommision = moneyThatGoesToTheSeller - moneyCommissionFromSeller;
                seller.SetBudget(seller.GetBudjet() + moneyAfterCommision);

                agency.SetAgencyBudget(agency.GetAgencyBudjet() + moneyForAgencyOrAgentFromBuyer);
                agency.SetAgencyBudget(agency.GetAgencyBudjet() + moneyForAgencyOrAgentFromSeller);

                agent.SetAgentBudget(agent.GetAgentBudjet() + moneyForAgencyOrAgentFromBuyer);
                agent.SetAgentBudget(agent.GetAgentBudjet() + moneyForAgencyOrAgentFromSeller);
            }
        }
    }
}
