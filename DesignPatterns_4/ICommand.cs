using RestaurantOrderSystem.MVVM.Models;

namespace RestaurantOrderSystem.Patterns.Command;

public interface ICommand
{
    void Execute();
}


public class AddOrderItemCommand : ICommand
{
    private readonly Order _order;
    private readonly string _itemName;
    private readonly int _quantity;
    private readonly decimal _price;
    
    public AddOrderItemCommand(Order order, string itemName, int quantity, decimal price = 10.0m)
    {
        _order = order;
        _itemName = itemName;
        _quantity = quantity;
        _price = price;
    }
    
    public void Execute()
    {
        _order.AddItem(new OrderItem
        {
            Name = _itemName,
            Quantity = _quantity,
            Price = _price
        });
        
        Console.WriteLine($"Added {_quantity}x {_itemName} to your order.");
    }
}
public class RemoveOrderItemCommand : ICommand
{
    private readonly Order _order;
    private readonly string _itemName;
    
    public RemoveOrderItemCommand(Order order, string itemName)
    {
        _order = order;
        _itemName = itemName;
    }
    
    public void Execute()
    {
        _order.RemoveItem(_itemName);
        Console.WriteLine($"Removed {_itemName} from your order.");
    }
}