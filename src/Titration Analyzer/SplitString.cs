using System.Text.RegularExpressions;

namespace Titration_Analyzer
{
    public class SplitString
    {
        public string[] SplitCapitalLetters(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }

        public string[] SplitNumbersFromLetters(string source)
        {
            return Regex.Split(source, @"(\d+)");
        }
        public bool Checkletters(string source)
        {
            return Regex.IsMatch(source, @"^[a-zA-Z]+$");
        }
    }
}


