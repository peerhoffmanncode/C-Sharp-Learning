// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Hello, World!");

public interface Icompress
{
    void Compress();
}


public class xxx : Icompress
{
    private void Compress() => Console.WriteLine("stuff");
}


public class FullName
{
    public string First { get; init; }
    public string Last { get; init; }

    public override bool Equals(object? obj)
    {
        return obj is FullName name &&
               First == name.First &&
               Last == name.Last;
    }

    public override string ToString() => $"{First} {Last}";

    //your code goes here
}


public struct Time
{
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}