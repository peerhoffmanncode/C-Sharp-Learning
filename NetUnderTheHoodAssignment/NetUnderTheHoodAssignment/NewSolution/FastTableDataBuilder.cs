using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<Row>();
        foreach (var row in csvData.Rows)
        {
            var RowData = new Row();
            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];
                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    RowData.AssignCell(column, true);
                }
                else if (valueAsString == "FALSE")
                {
                    RowData.AssignCell(column, false);
                }
                else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    RowData.AssignCell(column, valueAsDecimal);
                }
                else if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    RowData.AssignCell(column, valueAsInt);
                }
                else
                {
                    RowData.AssignCell(column, valueAsString);
                }
            }
            resultRows.Add(RowData);
        }
        return new TableData(csvData.Columns, resultRows);
    }
}