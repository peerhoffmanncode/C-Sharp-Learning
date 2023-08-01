public class Ingredient
{
    int _id;
    string _name;
    string _instruction;

    public Ingredient(int Id, string Name, string Instruction)
    {
        _id = Id;
        _name = Name;
        _instruction = Instruction;
    }

    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public string Instruction { get { return _instruction; } set { _instruction = value; } }

    public override string ToString() => $"{Instruction}";

}
