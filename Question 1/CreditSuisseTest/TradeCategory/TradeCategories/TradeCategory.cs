using CreditSuisseTest.Trade;

namespace CreditSuisseTest.Category.TradeCategories
{
    public abstract class TradeCategory
    {
        public string Name { get; set; }
        public abstract bool IsSatisfiedBy(ITrade trade);
    }
}
