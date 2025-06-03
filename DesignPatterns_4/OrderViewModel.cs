namespace RestaurantOrderSystem.MVVM.ViewModels;

using RestaurantOrderSystem.MVVM.Models;
using RestaurantOrderSystem.Patterns.Command;

public class OrderViewModel
{
    private readonly OrderModel _orderModel;
    
    public OrderViewModel(OrderModel orderModel)
    {
        _orderModel = orderModel;
    }
    
    public void AddItemToOrder(string itemName, int quantity, decimal price = 10.0m)
    {
        var command = new AddOrderItemCommand(_orderModel.GetCurrentOrder(), itemName, quantity, price);
        command.Execute();
    }
    
    public void RemoveItemFromOrder(string itemName)
    {
        var command = new RemoveOrderItemCommand(_orderModel.GetCurrentOrder(), itemName);
        command.Execute();
    }
    
    public Order GetOrder()
    {
        return _orderModel.GetCurrentOrder();
    }
}