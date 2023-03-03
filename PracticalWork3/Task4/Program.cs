using Microsoft.VisualBasic.FileIO;
using System;
namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] paths =
            {
                @"E:\knute\oop\laboratory9\PracticalWork3\Task4\TextFile1.txt",
                @"E:\knute\oop\laboratory9\PracticalWork3\Task4\TextFile2.txt"
            };
            Func<string, IEnumerable<string>> tokenizeText = TokenizeText;
            Func<IEnumerable<string>, IDictionary<string, int>> countOfWords = CountOfWords;
            Action<IDictionary<string, int>> showStatisticInfo = ShowStatisticInfo;
            List<string> texts = new List<string>();
            foreach (string path in paths)
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    texts.Add(streamReader.ReadToEnd());
                }
            }
            IEnumerable<string> words = texts.SelectMany(tokenizeText);
            IDictionary<string, int> periodicityOfWords = countOfWords(words);
            showStatisticInfo(periodicityOfWords);
        }
        static IEnumerable<string> TokenizeText(string text)
        {
            char[] separators = { ' ', '\t', '\r', '\n', '.', ',', ';', ':', '!', '?', '\"', '\'' };
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        static IDictionary<string, int> CountOfWords(IEnumerable<string> words)
        {
            Dictionary<string, int> periodicityOfWords = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (periodicityOfWords.ContainsKey(word))
                {
                    periodicityOfWords[word]++;
                }
                else
                {
                    periodicityOfWords[word] = 1;
                }
            }
            return periodicityOfWords;
        }

        static void ShowStatisticInfo(IDictionary<string, int> periodicityOfWords)
        {
            foreach (var countOfWord in periodicityOfWords)
            {
                Console.WriteLine($"{countOfWord.Key} - {countOfWord.Value}");
            }
        }
    }
}