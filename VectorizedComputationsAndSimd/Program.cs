using System;
using System.Numerics;
using BenchmarkDotNet.Running;

namespace VectorizedComputationsAndSimd
{
    internal static class Program
    {
        private static void Main()
        {
            if (!Vector.IsHardwareAccelerated)
            {
                throw new Exception("Nothing to do here");
            }

            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}