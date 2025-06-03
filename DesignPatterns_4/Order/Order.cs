namespace RestaurantOrderSystem.MVVM.Models;

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; } = new();
    
    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }
    
    public void RemoveItem(string itemName)
    {
        var item = Items.FirstOrDefault(i => i.Name == itemName);
        if (item != null)
        {
            Items.Remove(item);
        }
    }
}