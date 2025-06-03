using RestaurantOrderSystem.MVVM.Models;

namespace RestaurantOrderSystem.Patterns.Iterator;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}


public class OrderItemIterator : IIterator<OrderItem>
{
    private readonly List<OrderItem> _items;
    private int _position = 0;
    
    public OrderItemIterator(List<OrderItem> items)
    {
        _items = items;
    }
    
    public bool HasNext()
    {
        return _position < _items.Count;
    }
    
    public OrderItem Next()
    {
        if (!HasNext())
            throw new InvalidOperationException("No more items in collection");
            
        var item = _items[_position];
        _position++;
        return item;
    }
}