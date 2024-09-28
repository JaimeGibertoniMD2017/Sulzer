namespace Order.Model.Entities
{
    public class Item
    {
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
    }
}
