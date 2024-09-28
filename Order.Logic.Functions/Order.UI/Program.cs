using Order.Logic.Functions;
using Order.Model.Entities;

var order = new List<Item> {
    new Item{ Name="Laptop",  Quantity=1, Price =1000.00m },
    new Item{ Name= "Mouse",  Quantity = 3, Price = 25.00m },
    new Item{Name="Keyboard", Quantity = 2, Price = 50.00m}
};

var totalOrderAfterDiscounts = CalculationsHelpers.CalculateTotalPrice(order);

Console.WriteLine("Order Total Calculation Function\n");
Console.WriteLine($"Total order price after discounts = {totalOrderAfterDiscounts}");
var _ = Console.ReadLine();