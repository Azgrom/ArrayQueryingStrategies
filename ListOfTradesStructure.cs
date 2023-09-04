using System.Collections;

namespace ArrayQueryingStrategies;

public class ListOfStructures : IList<Order>
{
    private readonly IList<Order> _listImplementation;

    private ListOfStructures(IList<Order> listImplementation) => _listImplementation = listImplementation;
    
    public static implicit operator ListOfStructures(List<Order> trades) => new(trades);

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
