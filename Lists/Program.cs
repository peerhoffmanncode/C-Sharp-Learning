namespace Coding.Exercise
{
    public class Exercise
    {
        public List<string> GetOnlyUpperCaseWords(List<string> words)
        {
            List<string> result = new List<string>();

            foreach (string word in words)
            {
                if (word == word.ToUpper() && word.All(x => char.IsLetter(x)))
                {
                    if (!result.Contains(word))
                    {
                        result.Add(word);
                        continue;
                    }
                }
            }
            return result;
        }
    }
}
