using System.Collections;
using Bogus;

namespace ArrayQueryingStrategies;

public class ListOfStructures : IList<Order>
{
    private readonly IList<Order> _listImplementation;

    private ListOfStructures(IList<Order> listImplementation) => _listImplementation = listImplementation;
    
    public static implicit operator ListOfStructures(List<Order> trades) => new(trades);

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

    public IEnumerator<Order> GetEnumerator() => _listImplementation.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_listImplementation).GetEnumerator();

    public void Add(Order item) => _listImplementation.Add(item);

    public void Clear() => _listImplementation.Clear();

    public bool Contains(Order item) => _listImplementation.Contains(item);

    public void CopyTo(Order[] array, int arrayIndex) => _listImplementation.CopyTo(array, arrayIndex);

    public bool Remove(Order item) => _listImplementation.Remove(item);

    public int Count => _listImplementation.Count;

    public bool IsReadOnly => _listImplementation.IsReadOnly;

    public int IndexOf(Order item) => _listImplementation.IndexOf(item);

    public void Insert(int index, Order item) => _listImplementation.Insert(index, item);

    public void RemoveAt(int index) => _listImplementation.RemoveAt(index);

    public Order this[int index]
    {
        get => _listImplementation[index];
        set => _listImplementation[index] = value;
    }
}
