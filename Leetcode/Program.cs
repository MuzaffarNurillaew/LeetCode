using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    public bool MakeEqual(string[] words)
    {
        int len = words.Length;
        var allWords = new StringBuilder();
        foreach ( var word in words)
        {
            allWords.Append(word);
        }
        string allWordsStr = allWords.ToString();
        Dictionary<char, int> characterDict = new();
        for (int i = 0; i < 26; i++)
        {
            char currentLetter = (char)('a' + i);
            characterDict[currentLetter] = allWordsStr.Count(c => c == currentLetter);
            if (characterDict[currentLetter] == 0)
            {
                characterDict.Remove(currentLetter);
            }
        }
        foreach (var letter in characterDict.Keys)
        {
            if (characterDict[letter] % len != 0)
            {
                return false;
            }
        }
        return true;
    }
}