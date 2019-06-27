using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = TextFromFile();
            char[] symbols = SymbolsFromText(text);
            var content = text.Trim(symbols);
            var sentence = SentencesFromText(text).ToList<string>();
            WordsInAlphabeticalOrder(text);

            WriteToFile(LongSentence(sentence), ShortSentence(sentence, symbols), PopularLetter(text));
            Console.ReadKey();
        }

        public static string TextFromFile()
        {
            string content = "";
            using (StreamReader read = new StreamReader(@"C:\Users\user\source\repos\WorkWithFiles\Files\sample.txt"))
            {
                content = read.ReadToEnd();
            }
            Regex regex = new Regex(@"[\[\]\(\)\-*+&|\{\}\t\n\\]");
            var str = regex.Replace(content, " ");
            var text = str.Replace("\"", "");
            return text;
        }

        public static List<string> SentencesFromText(string text)
        {

            Regex r = new Regex(@"[A-Za-z]+[^\n\t.!?]*[\n\t.!?]");
            MatchCollection matches = r.Matches(text);
            List<string> result = new List<string>();
            foreach (Match m in matches)
            {
                result.Add(m.Value);
            }
            return result.ToList<string>();
        }

        public static char[] SymbolsFromText(string str)
        {
            Regex symbol = new Regex(@"[^0-9a-zA-Z\s\']");
            MatchCollection punctpunctuation = symbol.Matches(str);
            var listOfPunct = new List<char>();
            foreach (Match item in punctpunctuation)
            {
                listOfPunct.Add(Convert.ToChar(item.Value));
            }
            var charOfPunc = listOfPunct.GroupBy(x => x).Select(x => x.First()).ToArray();
            return charOfPunc;
        }

        public static string ShortSentence(List<string> text, char[] symbols)
        {
            Dictionary<string, int> sentences = new Dictionary<string, int>();
            foreach (string world in text)
            {
                var str = world.Trim(symbols);
                var worlds = str.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                if (sentences.ContainsKey(world)) sentences.Remove(world);
                else sentences.Add(world, worlds.Count());
            }
            int min = sentences.Values.Min();
            var listOfresult = new List<string>();

            foreach (string element in sentences.Keys)
            {
                if (sentences[element] == min)
                {
                    listOfresult.Add(element);
                }
            }
            var result = listOfresult.OrderBy(x=>x).ToArray(); 
            return result.First();
        }

        public static string LongSentence(List<string> text)
        {
            char[] charMass;
            int maxCount = 0;
            int count;
            string sentence = null;
            foreach (var item in text)
            {
                charMass = item.ToCharArray();
                count = 0;
                foreach (var symbol in charMass)
                {
                    if (char.IsSymbol(symbol)) count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    sentence = item;
                }
            }
            return sentence;
        }

        public static string PopularLetter(string str)
        {
            string result = null;
            Dictionary<char, int> mas = new Dictionary<char, int>();
            var strSimvolov = Regex.Replace(str, @"[^A-Za-z]", "").ToLower().ToCharArray();
            foreach (char ch in strSimvolov)
            {
                if (mas.ContainsKey(ch)) mas[ch]++;
                else mas.Add(ch, 1);
            }
            int max = mas.Values.Max();
            foreach (char el in mas.Keys)
            {
                if (mas[el] == max)
                {
                    result = $"The most common letter is: {el} - {mas[el]} times.";
                }
            }
            return result;
        }

        public static void WordsInAlphabeticalOrder(string str)
        {
            var text = str.ToLower();
            Regex reg_worlds = new Regex(@"\b[A-Za-z'-]+\b");
            MatchCollection matches = reg_worlds.Matches(text);
            var listOfWorlds = new List<string>();
            foreach (Match m in matches)
            {
                listOfWorlds.Add(m.Value);
            }
            var worlds = listOfWorlds.GroupBy(x => x).Select(group => $"{group.Key} = {group.Count()}.").OrderBy(x => x);
            var result = string.Join("\n", worlds);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\user\source\repos\WorkWithFiles\Files\AlphabeticalWords.txt"))
            {
                sw.WriteLine(result);
            }
        }

        public static void WriteToFile(string sentence, string element, string str)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\user\source\repos\WorkWithFiles\Files\Output.txt"))
            {
                sw.WriteLine("The longest sentence in the number of characters:\n {0}", sentence);
                sw.WriteLine("The shortest sentence by word count: {0}", element);
                sw.WriteLine(str);
            }
        }
    }
}
