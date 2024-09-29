using Order.Logic.Functions;
using Order.Model.Entities;

namespace Order.Tests.UnitTests
{
    public class UnitTest
    {
        [Fact]
        public void CalculateOrderTotalPrice_Null_ReturnsZero()
        {
            // Arrange
            List<Item>? order = null;
            decimal expectedOrderTotalPrice = 0;
            
            // Act
            var result = CalculationsHelpers.CalculateTotalPrice(order);

            // Assert
            Assert.Equal(expectedOrderTotalPrice, result);
        }

        [Theory]
        [MemberData(nameof(TestDataZero))]
        public void CalculateOrderTotalPrice_ZeroItems_ReturnsZero(List<Item> order, decimal expectedOrderTotalPrice)
        {
            // Act
            var result = CalculationsHelpers.CalculateTotalPrice(order);

            // Assert
            Assert.Equal(expectedOrderTotalPrice, result);
        }

        [Theory]
        [MemberData(nameof(TestDataWithoutDiscounts))]
        public void CalculateTotalPrice_NoDiscounts_ReturnsTotalWithoutDiscounts(List<Item> order, decimal expectedOrderTotalPriceWithoutDiscounts)
        {
            // Act
            var result = CalculationsHelpers.CalculateTotalPrice(order);

            // Assert
            Assert.Equal(expectedOrderTotalPriceWithoutDiscounts, result);
        }

        [Theory]
        [MemberData(nameof(TestDataCaseStudy))]
        public void CalculateTotalPrice_WithDiscounts_ReturnsTotal_CaseStudy(List<Item> order, decimal expectedOrderTotalPriceWithoutDiscounts)
        {
            // Act
            var result = CalculationsHelpers.CalculateTotalPrice(order);

            // Assert
            Assert.Equal(expectedOrderTotalPriceWithoutDiscounts, result);
        }

        public static IEnumerable<object[]> TestDataCaseStudy()
        {
            yield return new object[]
            {
                new List<Item>
                {
                    new Item { Name = "Laptop", Quantity = 1, Price = 1000.00m },
                    new Item { Name = "Mouse", Quantity = 3, Price = 25.00m },
                    new Item { Name = "Keyboard", Quantity = 2, Price = 50.00m }
                },
                1109.125m
            };
        }

        public static IEnumerable<object[]> TestDataZero()
        {
            yield return new object[]
            {
                new List<Item>
                {
                },
                0m
            };
        }

        public static IEnumerable<object[]> TestDataWithoutDiscounts()
        {
            yield return new object[]
            {
                new List<Item>
                {
                    new Item { Name = "Laptop", Quantity = 1, Price = 100.00m }
                },
                100.00m
            };
        }
    }
}