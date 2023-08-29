using System.Numerics;

namespace Assignment_NumericTypesSuggester;

internal static class TypeSuggester
{
    public const string BigInteger = "big Integer";    
    public const string ULong = "unsigned Long";
    public const string UInt = "unsigned Integer";
    public const string UShort = "unsigned Short";
    public const string Byte = "Byte";
    public const string Long = "Long";
    public const string Int = "Integer";
    public const string Short = "Short";
    public const string SByte = "signed Byte";
    public const string Decimal = "Decimal";
    public const string Double = "Double";
    public const string Float = "Float";
    public const string ERROR = "Impossible representation!";


    internal static string FindFittingType(
        BigInteger minValue, 
        BigInteger maxValue, 
        bool onlyIntgeral, 
        bool mustBePercise)
    {
        return onlyIntgeral ? GetIntegralNumber(minValue, maxValue) : GetFloatingPointNumber(minValue, maxValue, mustBePercise);
    }

    private static string GetFloatingPointNumber(BigInteger minValue, BigInteger maxValue, bool mustBePercise)
    {
        return mustBePercise ? GetPerciseFloatingPoint(minValue, maxValue) : GetRegularFloatingPoint(minValue, maxValue);
    }

    private static string GetRegularFloatingPoint(BigInteger minValue, BigInteger maxValue)
    {
        if (minValue >= new BigInteger(float.MinValue) && maxValue <= new BigInteger(float.MaxValue))
        { return Float; }

        if (minValue >= new BigInteger(double.MinValue) && maxValue <= new BigInteger(double.MaxValue))
        { return Double; }

        return ERROR;
    }

    private static string GetPerciseFloatingPoint(BigInteger minValue, BigInteger maxValue)
    {
        if (minValue >= new BigInteger(decimal.MinValue) && maxValue <= new BigInteger(decimal.MaxValue))
        { return Decimal; }
        
        return ERROR;
    }

    private static string GetIntegralNumber(BigInteger minValue, BigInteger maxValue)
    {

        if (minValue > 0 )
        {
            if (minValue >= new BigInteger(byte.MinValue) && maxValue <= new BigInteger(byte.MaxValue))
            { return Byte; }

            if (minValue >= new BigInteger(ushort.MinValue) && maxValue <= new BigInteger(ushort.MaxValue))
            { return UShort; }

            if (minValue >= new BigInteger(uint.MinValue) && maxValue <= new BigInteger(uint.MaxValue))
            { return UInt; }

            if (minValue >= new BigInteger(ulong.MinValue) && maxValue <= new BigInteger(ulong.MaxValue))
            { return ULong; }
        }
        else
        {
            if (minValue >= new BigInteger(sbyte.MinValue) && maxValue <= new BigInteger(sbyte.MaxValue))
            { return SByte; }

            if (minValue >= new BigInteger(short.MinValue) && maxValue <= new BigInteger(short.MaxValue))
            { return Short; }

            if (minValue >= new BigInteger(int.MinValue) && maxValue <= new BigInteger(int.MaxValue))
            { return Int; }

            if (minValue >= new BigInteger(long.MinValue) && maxValue <= new BigInteger(long.MaxValue))
            { return Long; }
        }

        return BigInteger;
    }
}