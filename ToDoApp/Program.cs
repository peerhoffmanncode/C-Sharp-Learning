Console.WriteLine("Hello");
Console.WriteLine();

main();

void main()
{
    // init list of todos
    List<string> ToDos = new List<string>();

    do
    {
        // show menu and handle user selection
        // the method is executed in the switch statement
        switch (ShowMenuAndSelectOption())
        {
            case 0:
                // exit
                Console.WriteLine();
                Console.WriteLine("bye.");
                Console.WriteLine();
                Environment.Exit(0);
                break;
            case 1:
                // see all
                SeeAllTodos(ToDos, "Your current ToDos are:");
                break;
            case 2:
                // add one
                ToDos = AddATodo(ToDos);
                break;
            case 3:
                // remove one
                ToDos = RemoveATodo(ToDos);
                break;
        }
    } while (true);
}

List<string> RemoveATodo(List<string> TheCurrentToDos)
{
    Console.WriteLine();

    // check if any todos are available
    if (TheCurrentToDos.Count < 1)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return TheCurrentToDos;
    }

    // show all to todos
    SeeAllTodos(TheCurrentToDos, "Select the index of the TODO you want to remove:");

    bool success = false;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        // pars input as int
        bool parsed = int.TryParse(Console.ReadLine(), out int index);

        if (parsed)
        {
            index -= 1;
            if (index >= 0 && index < TheCurrentToDos.Count)
            {
                Console.WriteLine($"TODO removed: {TheCurrentToDos[index]}");
                // remove todo from list
                TheCurrentToDos.RemoveAt(index);
                success = true;
            }
            else
            {
                Console.WriteLine("The given index is not valid.");
            }
        }
        else
        {
            Console.WriteLine("Selected index cannot be empty.");
        }
    } while (!success);
    return TheCurrentToDos;
}

List<string> AddATodo(List<string> TheCurrentToDos)
{
    Console.WriteLine();
    string newTodo;

    do
    {
        Console.WriteLine("Enter the TODO description:");
        newTodo = Console.ReadLine();
        if (newTodo.Length > 0)
        {
            if (TheCurrentToDos.Contains(newTodo))
            {
                Console.WriteLine("The description must be unique.");
                newTodo = "";
            }
            else
            {
                TheCurrentToDos.Add(newTodo);
            }
        }
        else
        {
            Console.WriteLine("The description cannot be empty.");
        }

    } while (!TheCurrentToDos.Contains(newTodo));

    Console.WriteLine($"TODO successfully added: {newTodo}");
    return TheCurrentToDos;

}

void SeeAllTodos(List<String> TheCurrentToDos, string title)
{
    Console.WriteLine();

    // if any todos - write them to console
    if (TheCurrentToDos.Count > 0)
    {
        Console.WriteLine(title);
        int index = 0;
        foreach (string ToDo in TheCurrentToDos)
        {
            index++;
            Console.WriteLine(index + ". " + ToDo);
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("No TODOs have been added yet.");
        Console.WriteLine();
    }
}

int ShowMenuAndSelectOption()
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    Console.WriteLine();

    string selection;
    do
    {
        selection = Console.ReadLine();
        // handle user selection
        switch (selection.ToLower())
        {
            case "s":
                return 1;
            case "a":
                return 2;
            case "r":
                return 3;
            case "e":
                return 0;
            default:
                Console.WriteLine("Incorrect input!");
                return -1;
        }
    } while (true);
}
