# Case 2
# Total Order Calculation Function

This solution to the Case #2 is a simple functional approach:

CalculationsHelpers Class

The CalculationsHelpers class provides utility methods for calculating the total price of an order, considering various discounts and special cases. The only public method receives a List<item> (order) to return a decimal value applying the Case 2 business rules and edge cases.

This simple solution was developed using VS 2022. 
Contains a very simple set of Tests.
Using the CLI the solution must build, get the packages online and run using the following command from the folder were the .sln file is located (solution root folder). You can clone the code from the GitHub repo following these steps:

PS C:\mkdir YOURREPOFOLDER
PS C:\cd YOURREPOFOLDER
PS C:\git init
PS C:\git clone https://github.com/JaimeGibertoniMD2017/Sulzer.git

To run the .exe file follow these steps:

PS C:\YOURREPOFOLDER\cd Sulzer\Order.Logic.Functions\
PS C:\dotnet run --project .\Order.UI\

It will display the following output:

Order Total Calculation Function

Total order price after discounts = 1109.125 

# Case 3
# Problem Solving

This is a containerised application in .NET 8 using Fibonacci Heaps (Class borrowed from an orignal implementation in C++ translated to C#). Also implements a Dijkstra's algorithm to find the shortest path in a graph. Implementation inspired in a Graph Algorithm GitHub repository with an impplementation of Graphs, Finonacci Heaps, Priority Queues and other algorithms and data structures.

There can be a significant difference in performance when using Fibonacci heaps compared to standard binary heaps or other priority queue implementations, especially for large datasets and certain operations.

Fibonacci heaps are particularly efficient for algorithms that involve a large number of "decrease-key" operations, such as Dijkstra's algorithm for finding shortest paths in a graph. Here are the key differences:

1. Asymptotic complexity:
   - Fibonacci Heap: O(1) amortized time for insert and decrease-key operations, and O(log n) for delete-min.
   - Binary Heap: O(log n) for insert, decrease-key, and delete-min operations.

2. Practical performance:
   - For large datasets with frequent decrease-key operations, Fibonacci heaps can significantly outperform binary heaps.
   - However, for smaller datasets or when decrease-key operations are less frequent, the constant factors and implementation complexity of Fibonacci heaps might make them slower in practice.

3. Implementation complexity:
   - Fibonacci heaps are more complex to implement correctly and efficiently.
   - Binary heaps are simpler and often have better cache locality, which can be advantageous in practice.

For this flight route planner implementation, using a Fibonacci heap could potentially improve performance, especially if we are dealing with a large number of cities and frequently updating route costs. However, the improvement might not be noticeable for smaller datasets, much less with the test case.

You can get it cloning from the following repository:

PS C:\mkdir YOURREPOFOLDER
PS C:\cd YOURREPOFOLDER
PS C:\git init
PS C:\git clone https://github.com/JaimeGibertoniMD2017/Sulzer.git

You must have at least WSL2 or Hyper-V and Docker installed using VS code or VS 2022 to run the containerised UI Console App. The output will be displayed on Docker Desktop as expected. But can be debugged for inspection purposes. This implementation lacks of Unit Tests.

Flight Planner database is located inside the project folder (\SQLScripts folder) as Data and Schema script and a database backup file (.bak)
