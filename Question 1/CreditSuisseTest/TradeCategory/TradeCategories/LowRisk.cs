using CreditSuisseTest.Trade;

namespace CreditSuisseTest.Category.TradeCategories
{
    internal class LowRisk : TradeCategory
    {
        public LowRisk()
        {
            Name = "LOWRISK";
        }

        public override bool IsSatisfiedBy(ITrade trade)
        {
            return trade.Value < 1000000 && trade.ClientSector == "Public";
        }

    }
}
