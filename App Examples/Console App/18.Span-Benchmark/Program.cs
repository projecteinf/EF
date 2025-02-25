using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

// INSTAL·LAR PAQUET BenchmarkDotNet
//      dotnet add package BenchmarkDotNet

// EXECUCIÓ 
// S'ha d'executar en mode producció
//
//      dotnet run --configuration Release

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
