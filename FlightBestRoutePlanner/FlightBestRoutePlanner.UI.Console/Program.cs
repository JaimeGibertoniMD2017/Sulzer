using FlightBestRoutePlanner.Logic;

string connectionString = @"Server=192.168.0.8\SQLEXPRESS,1433;Database=FlightPlanner;User Id=sa;Password=6508180Jgp@;Encrypt=True;TrustServerCertificate=True;";
var planner = new FlightRoutePlanner(connectionString);

// Find the cheapest route from City_A to City_C
var (route, price) = planner.PlanRoute("City_A", "City_C", DateTime.Now);
if (route != null)
{
    Console.WriteLine($"Cheapest route from City_A to City_C: {string.Join("- -> ", route)}");
    Console.WriteLine($"Total price: ${price:F2}");
}
else
{
    Console.WriteLine("No valid route found from City_A to City_C.");
}

// Find a round-trip from City_A to City_B with at most one connection
var (outboundRoute, returnRoute, totalPrice) = planner.PlanRoundTrip("City_A", "City_B", DateTime.Now, DateTime.Now.AddDays(7), maxConnections: 1);
if (outboundRoute != null && returnRoute != null)
{
    Console.WriteLine($"\nRound-trip from City_A to City_B:");
    Console.WriteLine($"Outbound: {string.Join(" --> ", outboundRoute)}");
    Console.WriteLine($"Return: {string.Join(" --> ", returnRoute)}");
    Console.WriteLine($"Total price: ${totalPrice:F2}");
}
else
{
    Console.WriteLine("No valid round-trip found from Origin City to Destination City with at most one connection.");
}
