using System.Collections;
using Bogus;

namespace ArrayQueryingStrategies;

public class StructureOfList : IReadOnlyList<Order>
{
    private readonly Order order = new();
    public StructureOfList(
        int[] tradeIds,
        string[] customers,
        string[] hashes,
        DateTime[] referenceDates
    )
    {
        TradeIds = tradeIds;
        Customers = customers;
        Hashes = hashes;
        ReferenceDates = referenceDates;
    }

    private int[] TradeIds { get; }
    private string[] Customers { get; }
    private string[] Hashes { get; }
    private DateTime[] ReferenceDates { get; }
    public int Count => TradeIds.Length;

    public Order this[int index]
    {
        get
        {
            order.TradeId = TradeIds[index];
            order.Customer = Customers[index];
            order.Hash = Hashes[index];
            order.ReferenceDate = ReferenceDates[index];

            return order;
        }
        set
        {
            TradeIds[index] = value.TradeId;
            Customers[index] = value.Customer;
            Hashes[index] = value.Hash;
            ReferenceDates[index] = value.ReferenceDate;
        }
    }

    public static StructureOfList GenerateRandomTradesWithBogus(uint numberOfTrades) =>
        new Faker<StructureOfList>()
            .CustomInstantiator(
                x => new StructureOfList(
                    x.Make((int)numberOfTrades, () => x.Random.Int())
                        .ToArray(),
                    x.Make((int)numberOfTrades, () => x.Company.CompanyName())
                        .ToArray(),
                    x.Make((int)numberOfTrades, () => x.Random.Hash())
                        .ToArray(),
                    x.Make((int)numberOfTrades, () => x.Date.Past())
                        .ToArray()
                )
            )
            .Generate();

    public IEnumerator<Order> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return new Order(TradeIds[i], Customers[i], Hashes[i], ReferenceDates[i]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
