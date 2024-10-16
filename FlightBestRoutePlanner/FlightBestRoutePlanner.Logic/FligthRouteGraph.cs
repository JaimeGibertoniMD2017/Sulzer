using FlightBestRoutePlanner.Data;
using FlightBestRoutePlanner.Model;

namespace FlightBestRoutePlanner.Logic
{
    public class FlightRouteGraph
    {
        private readonly Dictionary<int, City> cities;
        private readonly Dictionary<int, Flight> flights;
        private readonly PricingRules pricingSystem;
        private FibonacciHeap<double> fibonacciHeap = new();
        private Dictionary<int, double> distances = [];
        private Dictionary<int, int> previous = [];
        private Dictionary<int, int> connections = [];

        public FlightRouteGraph(Dictionary<int, City> cities,
                                                     Dictionary<int, Flight> flights)
        {
            this.cities = cities;
            this.flights = flights;
            this.pricingSystem = new PricingRules();
        }

        public (List<int> path, double totalPrice) FindCheapestRoute(int sourceCityId,
                                                                                                                     int destinationCityId,
                                                                                                                     DateTime departureTime,
                                                                                                                     int maxConnections = int.MaxValue)
        {
            foreach (var city in cities.Keys)
            {
                distances[city] = double.MaxValue;
                connections[city] = 0;
            }

            distances[sourceCityId] = 0;
            fibonacciHeap.Insert(0, sourceCityId);

            while (!fibonacciHeap.IsEmpty())
            {
                int currentCityId = fibonacciHeap.ExtractMin();

                if (currentCityId == destinationCityId)
                    break;

                if (connections[currentCityId] >= maxConnections)
                    continue;

                var outgoingFlights = flights.Values.Where(f => f.SourceCityId == currentCityId);
                int nextCityId; decimal price; double newDistance;
                foreach (var flight in outgoingFlights)
                {
                    UpdateFlights(departureTime, maxConnections, currentCityId, out nextCityId, out price, out newDistance, flight);
                }
            }

            if (!previous.ContainsKey(destinationCityId))
                return (path: null, totalPrice: double.MaxValue);

            List<int> path = UpdatePath(sourceCityId, destinationCityId, previous);

            return (path, totalPrice: distances[destinationCityId]);
        }

        private void UpdateFlights(DateTime departureTime, int maxConnections, int currentCityId, out int nextCityId, out decimal price, out double newDistance, Flight? flight)
        {
            nextCityId = flight.DestinationCityId;
            price = pricingSystem.CalculatePrice(flight, departureTime, 50); // Assuming 50 available seats for simplicity
            newDistance = distances[currentCityId] + (double)price;

            if (newDistance < distances[nextCityId] && connections[currentCityId] + 1 <= maxConnections)
            {
                distances[nextCityId] = newDistance;
                previous[nextCityId] = currentCityId;
                connections[nextCityId] = connections[currentCityId] + 1;
                fibonacciHeap.Insert(newDistance, nextCityId);
            }
        }

        private static List<int> UpdatePath(int sourceCityId,
                                                                       int destinationCityId,
                                                                       Dictionary<int, int> previous)
        {
            var path = new List<int>();
            for (int at = destinationCityId; at != sourceCityId; at = previous[at])
            {
                path.Add(at);
            }

            path.Add(sourceCityId);
            path.Reverse();
            return path;
        }
    }
}
