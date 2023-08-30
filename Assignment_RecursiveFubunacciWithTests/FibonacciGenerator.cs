using System.Collections.ObjectModel;
using System.Numerics;

namespace AssignmentRecursiveFubunacciWithTests;

public static class FibonacciGenerator
{
    private static readonly Dictionary <int, int> _cache = new();
    public static int RecursiveFibonacciWithCache(int v)
    {
        // check for max value
        if (v > 46)
        {
            throw new ArgumentException("Result will exceed max integer value!");
        }

        // calculate fibo num
        int result;
        if (v < 0) 
        { 
            return 0; 
        }
        else if (v == 0 || v == 1)
        {
            return v;
        }
        else
        {
            if (_cache.ContainsKey(v))
            { return _cache[v]; }
            result = RecursiveFibonacciWithCache(v - 1) + RecursiveFibonacciWithCache(v - 2);
        }

        _cache[v] = result;
        return result;
    }

    public static int IterativeFibonacci(int v)
    {
        if (v <= 1)
        {
            return v;
        }

        int prev = 0;
        int current = 1;

        for (int i = 2; i <= v; i++)
        {
            int temp = current;
            current = prev + current;
            prev = temp;
        }

        return current;
    }

}