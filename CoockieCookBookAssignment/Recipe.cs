public class Recipe
{
    string _name;
    string _description;
    List<Ingredient> _allIngredients;

    public Recipe(string Name, string Description, List<Ingredient> AllIngredients)
    {
        _name = Name;
        _description = Description;
        _allIngredients = AllIngredients;
    }
    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }

    public List<Ingredient> AllIngredients { get => _allIngredients; }

    public override string ToString()
    {
        string output = string.Empty;
        foreach (var ingredient in _allIngredients)
        {
            output += $"{ingredient.Name}. {ingredient.Instruction}." + Environment.NewLine;
        }
        return output;
    }
}

