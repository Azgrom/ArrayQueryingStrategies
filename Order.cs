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
}
