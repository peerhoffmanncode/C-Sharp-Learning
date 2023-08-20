

using System.ComponentModel.DataAnnotations;
using System.Reflection;

Person validPerson = new("John", 1982);
Person inValidPerson = new("J2dfgfgdfgdfgdfg", 1900);

Console.WriteLine(validPerson.Equals(validPerson));

var validator = new Validator();

Console.WriteLine(validator.Validate(validPerson) ? $"{validPerson} is valid" : $"{validPerson} is not valid!");
Console.WriteLine(validator.Validate(inValidPerson) ? $"{inValidPerson} is valid" : $"{inValidPerson} is not valid!");

Console.ReadKey();


public class Person
{
    [StringLengthValidator(2,10)]
    public string Name { get; }

    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public Person(string name) => Name = name;

    public override string ToString() => Name;
}

[AttributeUsage(AttributeTargets.Property)]
public class StringLengthValidatorAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public StringLengthValidatorAttribute(int min, int max)
    {
        Min = min; 
        Max = max;
    }
}


class Validator
{
    public bool Validate(object instance)
    {
        var type = instance.GetType();
        var properties = type.GetProperties()
            .Where(property => Attribute.IsDefined(property, typeof(StringLengthValidatorAttribute)));

        foreach (var property in properties)
        {
            object? value = property.GetValue(instance);
            if (value is not string)
            {
                throw new InvalidOperationException(
                    $"Attribute {nameof(StringLengthValidatorAttribute)} can only be applyed to strings!");
            }

            var valueAsString = (string)value;
            var attribute = (StringLengthValidatorAttribute)property.GetCustomAttributes(typeof(StringLengthValidatorAttribute), true).First();
            if (valueAsString.Length > attribute.Max || valueAsString.Length < attribute.Min)
            {
                Console.WriteLine($"Property '{property.Name}' is not valid, its lenght was {valueAsString.Length}! Should be in range of ({attribute.Min}, {attribute.Max})");
                return false;
            }
        }
        return true;
    }
}



