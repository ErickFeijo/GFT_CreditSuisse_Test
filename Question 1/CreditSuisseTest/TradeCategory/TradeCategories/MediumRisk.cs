using CreditSuisseTest.TradeCategories.Interfaces;
using CreditSuisseTest.Trade;

namespace CreditSuisseTest.Category.TradeCategories
{
    internal class MediumRisk : TradeCategory
    {
        public MediumRisk()
        {
            Name = "MEDIUMRISK";
        }

        public override bool IsSatisfiedBy(ITrade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Public";
        }
    }
}