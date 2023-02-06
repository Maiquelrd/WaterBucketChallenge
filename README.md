
# WaterBucketChallenge with .NET CORE 6 Web API

This repository contains a solution to the Water Jug Challenge, which involves measuring a specific volume of water using two jugs of different sizes. The solution is implemented in C# using .NET CORE 6 Web API.

## Prerequisites

Before getting started, you will need to have the following installed on your computer:

-   [Visual Studio](https://visualstudio.microsoft.com/downloads/)
-   [.NET CORE 6 runtime](https://dotnet.microsoft.com/download/dotnet-core/6.0)

## Getting Started

1.  Clone this repository to your computer
2.  Open Visual Studio and select "Open a project or solution"
3.  Navigate to the cloned repository and select the `WaterBucketChallenge.sln` file
4.  Once the project is loaded in Visual Studio, right-click on the `WaterJugChallenge` project and select "Set as Startup Project"
5.  Press `F5` to run the project and launch the .NET CORE 6 Web API

## Usage

The solution uses a recursive algorithm to solve the challenge, and it provides an endpoint to retrieve the steps required to reach the target volume of water. If no solution is possible, it will return "No Solution".

The initial values of the jugs and the target volume can be modified by changing the values of the `x`, `y`, and `z` variables in the `WaterJugController` class.

To retrieve the solution, send a GET request to the endpoint `api/WaterJug` in your web browser or using a tool like [Postman](https://www.postman.com/).

## Limitations

The only actions allowed in this solution are filling the jugs, emptying the jugs, and transferring water from one jug to the other.

## Conclusion

This repository provides a solution to the Water Jug Challenge using .NET CORE 6 Web API. It can be used as a starting point for further development or as an educational tool for learning about web API development and problem-solving in C#.

## Contact

Mauricio Mojica - @sirmaiquis - maiquel.mojica@gmail.com

GitHub: [https://github.com/Maiquelrd/WaterBucketChallenge)
