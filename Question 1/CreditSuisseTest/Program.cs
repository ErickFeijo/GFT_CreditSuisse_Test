using CreditSuisseTest.Category.TradeCategories;
using CreditSuisseTest.Trade;
using CreditSuisseTest.TradeCategories;
using CreditSuisseTest.TradeCategories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    public static void Main()
    {
        var tradeService = ConfigureServices().GetRequiredService<ITradeCategoryService>();

        Console.WriteLine("Input: ");

        var portfolio = new List<ITrade>
        {
            new Trade(2000000, "Private"),
            new Trade(400000, "Public"),
            new Trade(500000, "Public"),
            new Trade(3000000, "Public")
        };

        foreach (var trade in portfolio)
        {
            Console.WriteLine($"- Value: {trade.Value} Sector: {trade.ClientSector} ");
        }

        var tradeTradeCategories = tradeService.CategorizeTrades(portfolio);

        Console.WriteLine(Environment.NewLine + "Output: ");

        foreach (var name in tradeTradeCategories)
        {
            Console.WriteLine($"- {name} ");
        }

        Console.ReadLine();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<ITradeCategoryService, TradeCategoryService>();
        services.AddScoped<ITradeCategoryFactory, TradeCategoryFactory>();

        //Trade Categories
        services.AddScoped<TradeCategory, HighRisk>();
        services.AddScoped<TradeCategory, MediumRisk>();
        services.AddScoped<TradeCategory, LowRisk>();

        return services.BuildServiceProvider();
    }
}
