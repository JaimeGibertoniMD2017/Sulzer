# Case 2
# Total Order Calculation Function

This solution to the Case #2 is a simple fucntional approach:

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
# 