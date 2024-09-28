using Order.Model.Entities;

namespace Order.Logic.Functions
{
    public static class CalculationsHelpers
    {
        public static decimal CalculateTotalPrice(List<Item> items)
        {
            decimal totalOrderWithouDiscounts = items.Sum(x => x.Price * x.Quantity);
            decimal special = HandleSpecialCases(items, totalOrderWithouDiscounts);
            return special == 0 ? special : CalculateFinalPrice(items, totalOrderWithouDiscounts);
        }

        private static decimal CalculateFinalPrice(List<Item> items, decimal totalOrderWithoutDiscounts)
        {            
            return  CalculateDiscounts(items, totalOrderWithoutDiscounts);
        }

        private static decimal DiscountsPerItemsOrder(List<Item> items)
        {
            return items.Where(i => i.Quantity >= 3)
                                  .Sum(s => s.Price * s.Quantity * 0.1m);
        }

        private static decimal CalculateDiscounts(List<Item> items, decimal totalOrderWithoutDiscounts)
        {
            decimal totalOrderAfterDiscounts = totalOrderWithoutDiscounts - DiscountsPerItemsOrder(items);
            return totalOrderWithoutDiscounts > 100 ? totalOrderAfterDiscounts - DiscountsPerTotalOrder(totalOrderAfterDiscounts) : totalOrderAfterDiscounts;
        }

        private static decimal DiscountsPerTotalOrder(decimal totalOrder)
        {
            return totalOrder * 5 / 100;
        }

        private static decimal HandleSpecialCases(List<Item> items, decimal sum)
        {
            return items.Count == 0 || sum == 0 ? 0 : sum;
        }
    }
}