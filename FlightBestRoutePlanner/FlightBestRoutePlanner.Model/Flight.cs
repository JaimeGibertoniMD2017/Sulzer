using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBestRoutePlanner.Model
{
    public class Flight
    {
        public int Id { get; }
        public int SourceCityId { get; }
        public int DestinationCityId { get; }
        public int Distance { get; }
        public decimal BasePrice { get; }

        public Flight(int id, int sourceCityId, int destinationCityId, int distance, decimal basePrice)
        {
            Id = id;
            SourceCityId = sourceCityId;
            DestinationCityId = destinationCityId;
            Distance = distance;
            BasePrice = basePrice;
        }
    }
}
