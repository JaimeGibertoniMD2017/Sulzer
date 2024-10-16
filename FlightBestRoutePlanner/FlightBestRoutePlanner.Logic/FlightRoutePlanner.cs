using FlightBestRoutePlanner.Model;
using Microsoft.Data.SqlClient;

namespace FlightBestRoutePlanner.Logic
{
    public class FlightRoutePlanner
    {
        private readonly string connectionString;
        private FlightRouteGraph graph;
        private Dictionary<int, City> cities = [];
        private Dictionary<int, Flight> flights = [];

        public FlightRoutePlanner(string connectionString)
        {
            this.connectionString = connectionString;
            LoadGraphData();
        }

        private void LoadGraphData()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                LoadCities(cities, connection);

                LoadFlights(flights, connection);
            }

            graph = new FlightRouteGraph(cities, flights);
        }

        private static void LoadCities(Dictionary<int, City> cities, SqlConnection connection)
        {
            using var command = new SqlCommand("SELECT Id, Name FROM Cities", connection);
            using var reader = command.ExecuteReader();

            int id; string name;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                name = reader.GetString(1);
                cities[id] = new City(id, name);
            }
        }

        private static void LoadFlights(Dictionary<int, Flight> flights, SqlConnection connection)
        {
            using var command = new SqlCommand("SELECT Id, SourceCityId, DestinationCityId, Distance, BasePrice FROM Flights", connection);
            using var reader = command.ExecuteReader();

            int id; int sourceCityId; int destinationCityId; int distance; decimal basePrice;
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                sourceCityId = reader.GetInt32(1);
                destinationCityId = reader.GetInt32(2);
                distance = reader.GetInt32(3);
                basePrice = reader.GetDecimal(4);
                flights[id] = new Flight(id, sourceCityId, destinationCityId, distance, basePrice);
            }
        }

        public (List<string> route, double price) PlanRoute(string sourceCity, string destinationCity, DateTime departureTime, int maxConnections = int.MaxValue)
        {
            int sourceCityId = GetCityId(sourceCity);
            int destinationCityId = GetCityId(destinationCity);

            var (path, totalPrice) = graph.FindCheapestRoute(sourceCityId, destinationCityId, departureTime, maxConnections);

            if (path == null)
                return PlantRoutNull();

            var route = path.Select(cityId => GetCityName(cityId)).ToList();
            return (route, totalPrice);
        }

        private static (List<string> route, double price) PlantRoutNull()
        {
            return (route: null, price: double.MaxValue);
        }

        public (List<string> outboundRoute, List<string> returnRoute, double totalPrice) PlanRoundTrip(string sourceCity, string destinationCity, DateTime departureTime, DateTime returnTime, int maxConnections = int.MaxValue)
        {
            var (outboundRoute, outboundPrice) = PlanRoute(sourceCity, destinationCity, departureTime, maxConnections);
            var (returnRoute, returnPrice) = PlanRoute(destinationCity, sourceCity, returnTime, maxConnections);

            if (outboundRoute == null || returnRoute == null)
                return PlanRoundTripNull();

            return (outboundRoute, returnRoute, outboundPrice + returnPrice);
        }

        private static (List<string> outboundRoute, List<string> returnRoute, double totalPrice) PlanRoundTripNull()
        {
            return (outboundRoute: null, returnRoute: null, totalPrice: double.MaxValue);
        }

        private int GetCityId(string cityName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id FROM Cities WHERE Name = @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", cityName);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private string GetCityName(int cityId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Name FROM Cities WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", cityId);
                    return (string)command.ExecuteScalar();
                }
            }
        }
    }
}
