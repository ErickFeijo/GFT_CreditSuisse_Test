using CreditSuisseTest.Trade;
using CreditSuisseTest.TradeCategories.Interfaces;

internal class TradeCategoryService : ITradeCategoryService
{

    private ITradeCategoryFactory _categoryFactory;

    public TradeCategoryService(ITradeCategoryFactory categoryFactory)
    {
        _categoryFactory = categoryFactory;
    }
    public List<string> CategorizeTrades(List<ITrade> portfolio)
    {
        return portfolio.Select(x => _categoryFactory.GetTradeCategory(x)?.Name ?? "Does not fit into any category.").ToList();
    }
}