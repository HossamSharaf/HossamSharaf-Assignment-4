using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using System.Text;

namespace ConsoleApp3
{
    [MemoryDiagnoser]
    public class StringBenchmark
    {
        private int[] durations = { 180, 240, 180, 240, 180 };
        [Params(100, 1000, 10000, 100000)]
        public int Iterations;

        [Benchmark]
        public string StringConcatenation()
        {
            string result = "";
            for (int i = 0; i < Iterations; i++)
            {
                result += "Session " + i + "\n";
            }
            return result;
        }
        [Benchmark]
        public string StringBuilderConcatenation()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                result.Append("Session " + i + "\n");
            }
            return result.ToString();
        }

    }
   
}
