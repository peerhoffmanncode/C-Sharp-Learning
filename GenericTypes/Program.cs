// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


SimpleList<string> myList = new SimpleList<string>();


myList.Add("1abc");
myList.Add("2abc");
myList.Add("3abc");
myList.Add("4abc");
myList.Add("5abc");
Console.WriteLine(myList);

myList.RemoveAt(2);
Console.WriteLine(myList);


Console.ReadKey();


class ListOfInts

{
    private int[] _items = new int[4];       // define base array with 4 int items
    private int _size = 0;

    public void Add(int item)
    {
        if (_size >= _items.Length)
        {
            var newItems = new int[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];    // copy list
            }
            _items = newItems;              // old list = new list
            newItems = null;                // delete newItems object
        }
        _items[_size] = item;               // add element to nex free sport in array
        ++_size;                            // increase counter        
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _size)
        {
            throw new IndexOutOfRangeException();
        }
        --_size;

        for (var i = index; i < _size; ++i)
        {
            _items[i] = _items[i + 1];
        }
        _items[_size] = default;
    }

    public int GetAtIndex(int index)
    {
        if (index < 0 || index > _size)
        {
            throw new IndexOutOfRangeException();
        }
        return _items[index];
    }
    public override string ToString()
    {
        string output = "";
        foreach (var item in _items)
        {
            output += item.ToString() + Environment.NewLine;
        }
        return output;
    }
}



class SimpleList<T>

{
    private T[] _items = new T[4];       // define base array with 4 int items
    private int _size = 0;

    public void Add(T item)
    {
        if (_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];    // copy list
            }
            _items = newItems;              // old list = new list
            newItems = null;                // delete newItems object
        }
        _items[_size] = item;               // add element to nex free sport in array
        ++_size;                            // increase counter        
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _size)
        {
            throw new IndexOutOfRangeException();
        }
        --_size;

        for (var i = index; i < _size; ++i)
        {
            _items[i] = _items[i + 1];
        }
        _items[_size] = default;
    }

    public T GetAtIndex(int index)
    {
        if (index < 0 || index > _size)
        {
            throw new IndexOutOfRangeException();
        }
        return _items[index];
    }
    public override string ToString()
    {
        string output = "";
        foreach (var item in _items)
        {
            if (item is not null)
            {
                output += item.ToString() + Environment.NewLine;
            }
            else
            { output += ""; }
        }
        output += $"Number of elements: {_size}{Environment.NewLine}";
        output += $"Type of list: {typeof(T).FullName}{Environment.NewLine}";
        return output;
    }
}