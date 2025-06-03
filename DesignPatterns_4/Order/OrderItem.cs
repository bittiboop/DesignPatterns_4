﻿namespace RestaurantOrderSystem.MVVM.Models;


public class OrderItem
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}