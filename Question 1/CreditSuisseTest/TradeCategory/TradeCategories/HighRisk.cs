using CreditSuisseTest.Trade;

namespace CreditSuisseTest.Category.TradeCategories
{
    internal class HighRisk : TradeCategory
    {
        public HighRisk()
        {
            Name = "HIGHRISK";
        }

        public override bool IsSatisfiedBy(ITrade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Private";
        }
    }
}