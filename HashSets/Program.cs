
var spellChecker = new SpellChecker();

var hashSet1 = new HashSet<string> { "1", "2", "3", "4" };
var hashSet2 = new HashSet<string> { "1", "2", "3", "5" };
var hashSet3 = new HashSet<string>();
hashSet1.UnionWith(hashSet1);

Console.WriteLine(hashSet1.ToString());

Console.ReadKey();

public class SpellChecker
{
    private readonly HashSet<string> _correctWords = new()
    {
        "dog", "cat", "fish", "horse", "fish"
    };

    public bool IsCorrect(string word) =>
        _correctWords.Contains(word);

    public void AddCorrectWord(string word) =>
        _correctWords.Add(word);


}


public static class HashSetsUnionExercise
{
    public static HashSet<T> CreateUnion<T>(
        HashSet<T> set1, HashSet<T> set2)
    {
        var workOnSet = new HashSet<T>(set1);
        workOnSet.UnionWith(set2);
        return workOnSet;
    }
}  