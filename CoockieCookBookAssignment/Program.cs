// define program wide consts
const string filename_ingredients = "cookie_ingredients";
const string filename_recipes = "cookie_recipes";
const FileType filetype = FileType.json;

// define general file handler
// define general file handler
IFileHandler<Ingredient> IngredientsFileHandler;
IFileHandler<Recipe> RecipesFileHandler;
switch (filetype)
{
    case FileType.json:
        IngredientsFileHandler = new FromJSON<Ingredient>(filename_ingredients);
        RecipesFileHandler = new FromJSON<Recipe>(filename_recipes);
        break;
    case FileType.txt:
        //IngredientsFileHandler = new FromTXT<Ingredient>(filename_ingredients);
        //RecipesFileHandler = new FromTXT<Recipe>(filename_recipes);
        break;
    case FileType.Memory:
        IngredientsFileHandler = new FromMemory<Ingredient>(filename_ingredients);
        RecipesFileHandler = new FromMemory<Recipe>(filename_recipes);
        break;
}

// Read Data from memory and store to file
//List<Ingredient> AllStoredIngredients = memoryHandler.Read();
//JsonFileHandler.Write(AllStoredIngredients);

// Read ingredients
List<Ingredient> AllStoredIngredients = IngredientsFileHandler.Read();
// Read ingredients
List<Recipe> AllStoredRecipes = RecipesFileHandler.Read();


// Draw Welcome message        
Draw.WelcomeMsg();

// Draw all recipes if any
Draw.AllRecipes(AllStoredRecipes);

// Draw all ingredients if any
Draw.AllIngedients(AllStoredIngredients);

// Create a Recipe
string input;
do
{
    Recipe NewRecipe = Kitchen.Cook(AllStoredIngredients);
    if (NewRecipe is not null)
    { AllStoredRecipes.Add(NewRecipe); }

    Console.WriteLine("Create another one? [y/n]:");
    input = Console.ReadLine();
} while (input.ToLower() == "y");

// store to file
bool stored = RecipesFileHandler.Write(AllStoredRecipes);
if (stored)
{
    Console.WriteLine("Updated recipe cook book ;-)");
}
else
{
    Console.WriteLine("seems like things went south... nothing was safed!");
}
Console.ReadKey();
enum FileType
{
    json,
    txt,
    Memory,
}