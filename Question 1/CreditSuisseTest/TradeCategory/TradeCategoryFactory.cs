using CreditSuisseTest.TradeCategories.Interfaces;
using CreditSuisseTest.Trade;
using CreditSuisseTest.Category.TradeCategories;

namespace CreditSuisseTest.TradeCategories
{
    public sealed class TradeCategoryFactory : ITradeCategoryFactory
    {
        IEnumerable<TradeCategory> _tradeCategories;

        public TradeCategoryFactory(IEnumerable<TradeCategory> tradeCategories)
        {
            _tradeCategories = tradeCategories;
        }

        public TradeCategory? GetTradeCategory(ITrade trade)
        {
            return _tradeCategories.FirstOrDefault(x => x.IsSatisfiedBy(trade));
        }
    }
}