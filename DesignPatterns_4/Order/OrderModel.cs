namespace RestaurantOrderSystem.MVVM.Models;

public class OrderModel
{
    private Order _currentOrder = new Order { Id = 1 };
    
    public Order GetCurrentOrder()
    {
        return _currentOrder;
    }
    
    public void CreateNewOrder()
    {
        _currentOrder = new Order { Id = _currentOrder.Id + 1 };
    }
}