# Array Querying Benchmarks in C#

A performance comparison project to evaluate the efficiency of different data structure representations in C#. Specifically, this project compares the memory usage and access speed between a List of Structures (`ListOfStructures`) and a Structure of Lists (`StructureOfList`). 

## Table of Contents

1. [How it Works](#how-it-works)    
   1. [What it Does](#what-it-does)    
   2. [What is its Objective](#what-is-its-objective) 
2. [Requirements](#requirements) 
3. [Example Usage](#example-usage) 
4. [Contributing](#contributing) 
5. [License](#license) 

## How it Works 

### What it Does 

The project contains two primary data structure representations: 

1. `ListOfStructures`: An `IList` implementation that wraps around a `List<Order>` where `Order` is a custom structure. 
1. `StructureOfList`: A read-only list that stores individual properties of \`Order\` in separate arrays (`int[]`, `string[]`, etc.). 

Using BenchmarkDotNet, it performs benchmark tests that measure the speed and memory performance for querying these data structures with LINQ and explicit loops. 

### What is its Objective 

The main objectives are: 

1. To compare memory usage for the different data structure representations. 
2. To compare data access speeds for the different data structure representations. 

## Requirements

- .NET Core 2.1 and above up to .NET 7.0
- BenchmarkDotNet package 

## Example Usage

Clone the repository and navigate to the project folder. Run the following command to start the benchmarking: 

```bash 
dotnet run -c Release --framework net7.0
```

 This will execute the benchmark tests for the different runtimes (.NET Core 2.1, 3.1, .NET 5.0, .NET 6.0 and .NET 7.0) and output the results. 

## Contributing 

1. Fork the repository. 
2. Create your feature branch (`git checkout -b feature/fooBar`). 
3. Commit your changes (`git commit -am 'Add some fooBar'`). 
4. Push to the branch (`git push origin feature/fooBar`). 
5. Create a new pull request. 

## License 

This project is licensed under the MIT License - see the \`LICENSE.md\` file for details.