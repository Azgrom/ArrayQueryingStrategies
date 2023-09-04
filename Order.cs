using Bogus;

namespace ArrayQueryingStrategies;

public class Order
{
    public Order()
    {
    }

    public Order(int tradeId, string customer, string hash, DateTime referenceDate)
    {
        TradeId = tradeId;
        Customer = customer;
        Hash = hash;
        ReferenceDate = referenceDate;
    }

    public int TradeId { get; set; }
    public string Customer { get; set; }
    public string Hash { get; set; }
    public DateTime ReferenceDate { get; set; }

    public static ListOfStructures GenerateRandomTradesWithBogus(uint numberOfTrades) =>
        new Faker<Order>()
            .CustomInstantiator(
                x => new Order(
                    x.Random.Int(),
                    x.Company.CompanyName(),
                    x.Random.Hash(),
                    x.Date.Between(new DateTime(2023, 1, 1), new DateTime(2023, 06, 30))
                )
            )
            .Generate((int)numberOfTrades);
}
