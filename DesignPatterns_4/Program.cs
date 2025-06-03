using RestaurantOrderSystem.MVVM.Models;
using RestaurantOrderSystem.MVVM.ViewModels;
using RestaurantOrderSystem.MVVM.Views;
using RestaurantOrderSystem.Patterns.ChainOfResponsibility;
using RestaurantOrderSystem.Patterns.Command;
using RestaurantOrderSystem.Patterns.Iterator;

namespace RestaurantOrderSystem;

class Program
{
    static void Main(string[] args)
    {
        var orderModel = new OrderModel();
        var orderViewModel = new OrderViewModel(orderModel);
        var orderView = new OrderView(orderViewModel);
        
        var paymentProcessor = new PaymentProcessor();
        var kitchenProcessor = new KitchenProcessor();
        var deliveryProcessor = new DeliveryProcessor();
        
        paymentProcessor.SetNextProcessor(kitchenProcessor);
        kitchenProcessor.SetNextProcessor(deliveryProcessor);
        
        Console.WriteLine("=== Restaurant Order System ===\n");
        
        orderView.PlaceOrder("Pizza", 1);
        orderView.PlaceOrder("Salad", 2);
        orderView.PlaceOrder("Soda", 3);
        
        var order = orderModel.GetCurrentOrder();
        paymentProcessor.ProcessOrder(order);
        
        Console.WriteLine("\n=== Order Items ===");
        var iterator = new OrderItemIterator(order.Items);
        while (iterator.HasNext())
        {
            var item = iterator.Next();
            Console.WriteLine($"- {item.Quantity}x {item.Name}");
        }
    }
}