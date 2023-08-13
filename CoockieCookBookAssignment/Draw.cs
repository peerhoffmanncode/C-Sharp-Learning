public static class Draw
{
    public static void WelcomeMsg()
    {
        Console.WriteLine("Hello, this is a Coockie Cook Book Console App");
        Console.WriteLine();
    }

    public static void AllIngedients(List<Ingredient> allIngredients)
    {
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        var outputLines = allIngredients
            .Select(ingredient => $"Id {ingredient.Id} - {ingredient.Name}" +
                                  $": {ingredient.Instruction.PadRight(24)}{ingredient.Instruction}")
            .ToList();
        Console.WriteLine(string.Join(Environment.NewLine, outputLines));
        Console.WriteLine();
    }

    public static void AllRecipes(List<Recipe> allRecipes)
    {
        if (allRecipes.Count > 0)
        {
            //Console.WriteLine("Existing recipes are:");
            //for (int i = 0; i < allRecipes.Count; i++)
            //{
            //    Console.WriteLine($"***** {i + 1} *****");
            //    Console.WriteLine(allRecipes[i]);
            //}
            //Console.WriteLine();


            Console.WriteLine("Existing recipes are:");
            var outputLines = allRecipes
                .Select((recipe, index) => $"***** {index + 1} *****{Environment.NewLine}{recipe}")
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, outputLines));
            Console.WriteLine();
        }
    }

}