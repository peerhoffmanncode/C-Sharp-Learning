// See https://aka.ms/new-console-template for more information



Print print = text => text.ToUpper();
Print print1 = text => text.ToLower();
Print print3 = text => text.Substring(0, 3);
Print multicast = print1 + print3;

Console.WriteLine(multicast("My friken shit!"));


Console.ReadKey();

delegate string Print(string input);