using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace ArrayQueryingStrategies;

[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.NetCoreApp31)]
[SimpleJob(RuntimeMoniker.Net50)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
public class ArrayQueryingBenchmarks
{
    private const string StructureOfListCategory = "StructureOfLists";
    private const string ListOfStructuresCategory = "ListOfStructures";
    private static decimal _structureOfListTradeIdsAverage;
    private static decimal _listOfStructuresTradeIdsAverage;

    [Params(100, 1_000, 10_000, 100_000)] public int Count;
    private ListOfStructures listOfStructures;
    private StructureOfList structureOfList;

    [GlobalSetup]
    public void Setup()
    {
        structureOfList = StructureOfList.GenerateRandomTradesWithBogus((uint)Count);
        listOfStructures = ListOfStructures.GenerateRandomTradesWithBogus((uint)Count);

        _structureOfListTradeIdsAverage = (long)structureOfList.Average(x => (long)x.TradeId);
        _listOfStructuresTradeIdsAverage = (long)listOfStructures.Average(x => (long)x.TradeId);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(StructureOfListCategory)]
    public void LinqQueryStructureOfList()
    {
        foreach (var _ in structureOfList.Where(StructureOfListQueryConditionals))
        {
        }
    }

    [Benchmark]
    [BenchmarkCategory(StructureOfListCategory)]
    public void ExplicitQueryStructureOfList()
    {
        foreach (var trade in structureOfList)
            if (StructureOfListQueryConditionals(trade))
            {
            }
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(ListOfStructuresCategory)]
    public void LinqQueryListOfStructures()
    {
        foreach (var _ in listOfStructures.Where(ListOfStructuresQueryConditionals))
        {
        }
    }

    [Benchmark]
    [BenchmarkCategory(ListOfStructuresCategory)]
    public void ExplicitQueryListOfStructures()
    {
        foreach (var trade in listOfStructures)
            if (ListOfStructuresQueryConditionals(trade))
            {
            }
    }

    private static bool ListOfStructuresQueryConditionals(Order order) =>
        order.TradeId < _listOfStructuresTradeIdsAverage
        && order.ReferenceDate > new DateTime(2023, 03, 15);

    private static bool StructureOfListQueryConditionals(Order order) =>
        order.TradeId < _structureOfListTradeIdsAverage
        && order.ReferenceDate > new DateTime(2023, 03, 15);
}
