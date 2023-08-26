using System.Diagnostics;
using System.Globalization;

// define base path
const string BasePath = @"tickets\";

// execute TicketSystem

TicketSystem.run(BasePath, new FileHandler());

Console.WriteLine("Press any key to close.");
Console.ReadKey();