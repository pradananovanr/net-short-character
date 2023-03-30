using System.Text.RegularExpressions;

class Program
{
    private static readonly Regex whitespace = new Regex(@"\s+");
    private static char[] vowels = { 'a', 'i', 'u', 'e', 'o' };
    private static string replaceWhitespace(string input, string replacement)
    {
        return whitespace.Replace(input, replacement);
    }

    public string procVowel(string? param)
    {
        string result = "";
        if (param?.Length > 0)
        {
            param = replaceWhitespace(param, "");

            foreach (char input in param.ToLower())
            {
                if (vowels.Contains(input))
                {
                    result += input;
                }
            }
        }
        return new string(result.OrderBy(c => param?.IndexOf(c)).ToArray());
    }

    public string procConsonant(string? param)
    {
        string result = "";
        if (param?.Length > 0)
        {
            param = replaceWhitespace(param, "");

            foreach (char input in param.ToLower())
            {
                if (!vowels.Contains(input))
                {
                    result += input;
                }
            }
            result = new string(result.OrderBy(c => result.IndexOf(c)).ToArray());
        }
        return new string(result);
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        while (true)
        {
            Console.Write("Input one line of words (S) : ");
            string? input = Console.ReadLine();
            string charVowel = program.procVowel(input);
            string charConsonant = program.procConsonant(input);

            Console.WriteLine("Vowel Characters : ");
            Console.WriteLine(charVowel);
            Console.WriteLine("Consonant Characters : ");
            Console.WriteLine(charConsonant);
        }
    }
}