# Rendiment Span
## Instruccions instal·lació i execució

### Instal·lació llibreries
```bash
      dotnet add package BenchmarkDotNet
```
### Execució
S'ha d'executar en mode producció
```bash
      dotnet run --configuration Release
```
## Codi font
Copia un quart d'un array ubicat al mig d'un array utilitzant mètode tradicional i span.  
```CSharp 
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SpanTDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkDemo1>();
        }
    }

    [MemoryDiagnoser]
    public class BenchmarkDemo1
    {
        private int[] _myArray;

        [Params(100, 1000, 10000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void SetUp()
        {
            _myArray = new int[Size];
            for (int index = 0; index < Size; index++)
            {
                _myArray[index] = index;
            }
        }

        [Benchmark(Baseline = true)]
        public int[] Original()
        {
            return _myArray.Skip(Size / 2).Take(Size / 4).ToArray();
        }

        [Benchmark]
        public int[] ArrayCopy()
        {
            var copy = new int[Size / 4];
            Array.Copy(_myArray, Size / 2, copy, 0, Size / 4);
            return copy;
        }

        [Benchmark]
        public Span<int> Span()
        {
            return _myArray.AsSpan().Slice(Size / 2, Size / 4);
        }
    }
}
```
# Resultats

```
BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
Intel Core i5-2400 CPU 3.10GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX
```
| Method    | Size  | Mean          | Error       | StdDev      | Median        | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------- |------ |--------------:|------------:|------------:|--------------:|------:|--------:|-------:|----------:|------------:|
| **Original**  | **100**   |    **191.545 ns** |   **3.6477 ns** |   **5.4597 ns** |    **193.191 ns** | **1.001** |    **0.04** | **0.0713** |     **224 B** |        **1.00** |
| ArrayCopy | 100   |     28.875 ns |   0.5498 ns |   0.4591 ns |     28.814 ns | 0.151 |    0.00 | 0.0408 |     128 B |        0.57 |
| Span      | 100   |      1.015 ns |   0.0153 ns |   0.0144 ns |      1.018 ns | 0.005 |    0.00 |      - |         - |        0.00 |
|           |       |               |             |             |               |       |         |        |           |             |
| **Original**  | **1000**  |  **1,161.690 ns** |  **22.4441 ns** |  **20.9942 ns** |  **1,153.818 ns** | **1.000** |    **0.02** | **0.3567** |    **1120 B** |        **1.00** |
| ArrayCopy | 1000  |    129.213 ns |   2.6315 ns |   2.9249 ns |    129.629 ns | 0.111 |    0.00 | 0.3262 |    1024 B |        0.91 |
| Span      | 1000  |      1.078 ns |   0.0375 ns |   0.0350 ns |      1.085 ns | 0.001 |    0.00 |      - |         - |        0.00 |
|           |       |               |             |             |               |       |         |        |           |             |
| **Original**  | **10000** | **11,110.252 ns** | **168.3516 ns** | **149.2393 ns** | **11,130.211 ns** | **1.000** |    **0.02** | **3.2196** |   **10120 B** |        **1.00** |
| ArrayCopy | 10000 |  1,097.585 ns |  21.8263 ns |  60.4805 ns |  1,077.267 ns | 0.099 |    0.01 | 3.1834 |   10024 B |        0.99 |
| Span      | 10000 |      1.087 ns |   0.0498 ns |   0.0465 ns |      1.094 ns | 0.000 |    0.00 |      - |         - |        0.00 |
