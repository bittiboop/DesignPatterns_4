using RestaurantOrderSystem.MVVM.Models;

namespace RestaurantOrderSystem.Patterns.ChainOfResponsibility;

public abstract class OrderProcessor
{
    protected OrderProcessor? NextProcessor { get; private set; }
    
    public void SetNextProcessor(OrderProcessor nextProcessor)
    {
        NextProcessor = nextProcessor;
    }
    
    public abstract void ProcessOrder(Order order);
}

public class PaymentProcessor : OrderProcessor
{
    public override void ProcessOrder(Order order)
    {
        Console.WriteLine("Processing payment for order...");
        
        decimal total = order.Items.Sum(item => item.Price * item.Quantity);
        Console.WriteLine($"Payment of ${total} processed successfully.");
        
        NextProcessor?.ProcessOrder(order);
    }
}
public class KitchenProcessor : OrderProcessor
{
    public override void ProcessOrder(Order order)
    {
        Console.WriteLine("Kitchen is preparing your order...");
        
        foreach (var item in order.Items)
        {
            Console.WriteLine($"Preparing: {item.Quantity}x {item.Name}");
        }
        
        Console.WriteLine("All items prepared!");
        
        NextProcessor?.ProcessOrder(order);
    }
}
public class DeliveryProcessor : OrderProcessor
{
    public override void ProcessOrder(Order order)
    {
        Console.WriteLine("Order is being delivered...");
        Console.WriteLine("Order delivered successfully!");
    }
}
