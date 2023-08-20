﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public struct Time
{
    public int Hour { get; }
    public int Minute { get; }

    public Time(int hour, int minute)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(
                "Minute is out of range of 0-59");
        }
        Hour = hour;
        Minute = minute;
    }

    public override string ToString() =>
        $"{Hour.ToString("00")}:{Minute.ToString("00")}";


    public override bool Equals(object? obj)
    {
        return obj is Time other &&
               Hour == other.Hour &&
               Minute == other.Minute;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hour, Minute);
    }
}

