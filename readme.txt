Solution: ClaimsTriangle
There are two projects in this Solution.
Project1: ClaimsTriangle
Project1 Type: Console App (.Net Framework)
I call my Visual Studio Console C# Solution and Project, ClaimsTriangle.
I use Csv Helper; please install this via NuGet Package Manager if it's not restored
Please copy data.csv into the project's \bin\Debug folder


Project2: ClaimsTriangleUnitTests
Project2 Type: NUnit Test (.Net CORE)
Please copy data.csv into the test project's bin\Debug\netcoreapp3.1 folder



How to run the app from command line:-
ClaimsTriangle <path and name of input file> <path and name of output file>

i.e.
ClaimsTriangle c:\temp\data.csv c:\temp\dataout.csv



Input file example:
Product, Origin Year, Development Year, Incremental Value
Comp, 1992, 1992, 110.0
Comp, 1992, 1993, 170.0
Comp, 1993, 1993, 200.0
Non-Comp, 1990, 1990, 45.2
Non-Comp, 1990, 1991, 64.8
Non-Comp, 1990, 1993, 37.0
Non-Comp, 1991, 1991, 50.0
Non-Comp, 1991, 1992, 75.0
Non-Comp, 1991, 1993, 25.0
Non-Comp, 1992, 1992, 55.0
Non-Comp, 1992, 1993, 85.0
Non-Comp, 1993, 1993, 100.0

Output file example:
1990, 4
Comp, 0, 0, 0, 0, 0, 0, 0, 110, 280, 200
Non-Comp, 45.2, 110, 110, 147, 50, 125, 150, 55, 140, 100
