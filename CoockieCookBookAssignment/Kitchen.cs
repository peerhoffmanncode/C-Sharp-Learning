
public static class Kitchen
{

    public static Recipe Cook(List<Ingredient> AllAvailableIngredients)
    {
        int id_input;
        List<Ingredient> enteredIngredients = new();

        Console.WriteLine("Enter recipe name :");
        string RecipeName = Console.ReadLine();
        Console.WriteLine("Enter description :");
        string RecipeDescription = Console.ReadLine();

        do
        {
            Console.WriteLine("Enter Id of ingredient to add it to the recipe: ");
            bool accepted = int.TryParse(Console.ReadLine(), out id_input);
            if (accepted && (AllAvailableIngredients.Count > id_input - 1 && id_input - 1 >= 0))
            {
                enteredIngredients.Add(AllAvailableIngredients[id_input - 1]);
            }
            else
            {
                break;
            }


        } while (AllAvailableIngredients.Count > id_input - 1 && id_input - 1 >= 0);
        if (enteredIngredients.Count > 0)
        {
            Recipe NewRecipe = new Recipe(RecipeName, RecipeDescription, enteredIngredients);
            Console.WriteLine("You created the recipe:");
            Console.WriteLine(NewRecipe);
            return NewRecipe;
        }

        Console.WriteLine("You did not created a recipe:");
        return null;
    }

}
