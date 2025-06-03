namespace RestaurantOrderSystem.MVVM.Views;

using RestaurantOrderSystem.MVVM.ViewModels;

public class OrderView
{
    private readonly OrderViewModel _viewModel;
    
    public OrderView(OrderViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    
    public void PlaceOrder(string itemName, int quantity)
    {
        _viewModel.AddItemToOrder(itemName, quantity);
    }
    
    public void CancelOrderItem(string itemName)
    {
        _viewModel.RemoveItemFromOrder(itemName);
    }
    
    public void DisplayOrder()
    {
        var order = _viewModel.GetOrder();
        Console.WriteLine($"Order #{order.Id}");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"- {item.Quantity}x {item.Name}: ${item.Price * item.Quantity}");
        }
        
        decimal total = order.Items.Sum(i => i.Price * i.Quantity);
        Console.WriteLine($"Total: ${total}");
    }
}