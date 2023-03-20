using CreditSuisseTest.TradeCategories;
using CreditSuisseTest.TradeCategories.Interfaces;

namespace CreditSuisseTest.Trade
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }

        public Trade(double value, string clientSector)
        {
            Value = value;
            ClientSector = clientSector;
        }        
    }
}
