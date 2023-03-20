using CreditSuisseTest.TradeCategories.Interfaces;

namespace CreditSuisseTest.Trade
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
    }
}
