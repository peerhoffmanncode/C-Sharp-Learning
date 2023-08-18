using System.Collections.Generic;

namespace CsvDataAccess.NewSolution;

public class Row
{
    private Dictionary<string, string> _stringdata = new();

    private Dictionary<string, int> _intdata = new();
    
    private Dictionary<string, decimal> _decimaldata = new();
    
    private Dictionary<string, bool> _booldata = new();

    public void AssignCell(string columnName, bool value)
    {
        _booldata[columnName] = value;
    }

    public void AssignCell(string columnName, int value)
    {
        _intdata[columnName] = value;
    }

    public void AssignCell(string columnName, decimal value)
    {
        _decimaldata[columnName] = value;

    }

    public void AssignCell(string columnName, string value)
    {
        _stringdata[columnName] = value;
    }

    public object GetAtColumn(string columnName)
    {
        if (_stringdata.ContainsKey(columnName))
            return _stringdata[columnName];
        if (_decimaldata.ContainsKey(columnName))
            return _decimaldata[columnName];
        if (_intdata.ContainsKey(columnName))
            return _intdata[columnName];
        if (_booldata.ContainsKey(columnName))
            return _booldata[columnName];

        return null;
    }
}