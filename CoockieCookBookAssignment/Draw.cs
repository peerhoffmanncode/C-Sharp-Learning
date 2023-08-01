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
        foreach (var ingredient in allIngredients)
        {
            string ingredientInfo = $"Id {ingredient.Id} - {ingredient.Name}";
            string instructionInfo = $": {ingredient.Instruction}";
            string outputLine = $"{ingredientInfo.PadRight(24)}{instructionInfo}";

            Console.WriteLine(outputLine);
        }
        Console.WriteLine();
    }

    public static void AllRecipes(List<Recipe> allRecipes)
    {
        if (allRecipes.Count > 0)
        {
            Console.WriteLine("Existing recipes are:");
            for (int i = 0; i < allRecipes.Count; i++)
            {
                Console.WriteLine($"***** {i + 1} *****");
                Console.WriteLine(allRecipes[i]);
            }
            Console.WriteLine();
        }
    }

}