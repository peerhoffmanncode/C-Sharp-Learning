using AssignmentRecursiveFubunacciWithTests;
using System;
using System.Diagnostics;
using System.Numerics;

namespace Assignment_RecursiveFubunacciWithTests;

public static class Program
{
    public static void Main2()
    {
        int maxFibuNum = 10;

        // Run the Recursive Fibonacci with Cache approach
        Console.WriteLine("Recursive Fibonacci with Cache:");
        MeasureMemoryAndTime(() =>
        {
            BigInteger result = FibonacciGenerator.RecursiveFibonacciWithCache(maxFibuNum);
            Console.WriteLine(result);
        });

        // Run the Iterative Fibonacci approach
        Console.WriteLine("Iterative Fibonacci:");
        MeasureMemoryAndTime(() =>
        {
            BigInteger result = FibonacciGenerator.IterativeFibonacci(maxFibuNum);
            Console.WriteLine(result);
        });


        Console.ReadKey();
    }

    private static void MeasureMemoryAndTime(Action action)
    {
        long startMemory = Process.GetCurrentProcess().WorkingSet64;
        Stopwatch stopwatch = Stopwatch.StartNew();

        action.Invoke(); // Execute the provided action

        stopwatch.Stop();
        long endMemory = Process.GetCurrentProcess().WorkingSet64;

        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Memory used: {(endMemory - startMemory) / 1024} kbytes");
    }
}