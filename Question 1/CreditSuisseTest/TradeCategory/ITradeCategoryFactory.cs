using CreditSuisseTest.Category.TradeCategories;
using CreditSuisseTest.Trade;

namespace CreditSuisseTest.TradeCategories.Interfaces
{
    internal interface ITradeCategoryFactory
    {
        TradeCategory? GetTradeCategory(ITrade trade);
    }
}
