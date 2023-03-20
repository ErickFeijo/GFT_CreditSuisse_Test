using CreditSuisseTest.Trade;

internal interface ITradeCategoryService
{
    public List<string> CategorizeTrades(List<ITrade> portfolio);
}