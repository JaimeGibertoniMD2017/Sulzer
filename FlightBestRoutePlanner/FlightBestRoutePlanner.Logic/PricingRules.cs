using FlightBestRoutePlanner.Model;

namespace FlightBestRoutePlanner.Logic
{
    public class PricingRules
    {
        private readonly Random random = new Random();

        public decimal CalculatePrice(Flight flight, DateTime departureTime, int availableSeats)
        {
            decimal basePrice = flight.BasePrice;
            decimal dynamicFactor = CalculateDynamicFactor(departureTime, availableSeats);
            return basePrice + dynamicFactor;
        }

        private decimal CalculateDynamicFactor(DateTime departureTime, int availableSeats)
        {
            // Time of day factor
            decimal timeOfDayFactor = departureTime.Hour >= 9 && departureTime.Hour <= 17 ? 1.2m : 1.0m;

            // Availability factor
            decimal availabilityFactor = Math.Max(1.0m, 2.0m - (availableSeats / 100.0m));

            // Random factor for promotions
            decimal promotionFactor = ((decimal)random.NextDouble()) * 0.2m + 0.9m;  // 10% discount to 10% increase

            return timeOfDayFactor * availabilityFactor * promotionFactor * 10;  // Multiply by 10 to make the dynamic factor more significant
        }
    }
}
