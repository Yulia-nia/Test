using WorkWithFiles.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace WorkWithFiles
{
    class TextHandler
    {
        public string Path { get; set; }

        public async Task<List<string>> ParseText()
        {
            Parser parser = new Parser();
            return await parser.GetSentences(Path);
        }

        public async Task<Dictionary<string, int>> GetAlfaDictionary()
        {
            var sent = await ParseText();
            World world = new World();
            List<string> worlds = await world.GetWorlds(sent);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var item in worlds)
            {
                if (dictionary.ContainsKey(item)) dictionary[item]++;
                else dictionary.Add(item, 1);
            }
            return dictionary;
        }

        private async Task<Dictionary<char, int>> GetPopularLetter()
        {
            var dictionary = new Dictionary<char, int>();
            var sent = await ParseText();
            World world = new World();
            List<string> worlds = await world.GetWorlds(sent);
            foreach (var item in worlds)
            {               
                char[] symbols = (item.ToString()).ToCharArray();
                foreach (var symbol in symbols)
                {
                    if (dictionary.ContainsKey(symbol)) dictionary[symbol]++;
                    else dictionary.Add(symbol, 1);
                }
            }
            return dictionary;
        }

        public async Task<string> GetShortSentence()
        {
            var sent = await ParseText();
            Dictionary<string, int> sentences = new Dictionary<string, int>();
            foreach (string item in sent)
            {
                Regex r = new Regex(@"[^0-9A-Za-z]+");
                var newstr = r.Replace(item, " ");
                var worlds = newstr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if ((sentences.ContainsKey(item)) || (worlds.Count() <= 1)) sentences.Remove(item);
                else sentences.Add(item, worlds.Count());
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
            return listOfresult.First();
        }
        public async Task<List<string>> RemoveUnusedSymbols()
        {
            var sentence = await ParseText();
            var symbolsCollection = new[] { "(", ")", "[", "]", "}", "{", "<", ">", "\\", "--", "+", "*", "=", "\n", "|" };
            List<string> text = new List<string>();
            foreach (var sent in sentence)
            {
                foreach (var item in symbolsCollection)
                {
                    sent.Replace(item, "");
                }
                text.Add(sent);
            }
            return text;
        }

        public async Task<string> GetLongSentence()
        {
            var sent = await RemoveUnusedSymbols();  
            var dictionary = new Dictionary<string, int>();            
            int count;            
            foreach (var item in sent)
            {                
                if (dictionary.ContainsKey(item))
                {
                    dictionary.Remove(item);
                }
                else
                {
                    var charMass = item.ToCharArray();
                    count = 0;
                    foreach (var symbol in charMass)
                    {
                        if (char.IsSymbol(symbol)) count++;
                    }
                    dictionary.Add(item, count);
                }
            }
            int max = dictionary.Values.Max();
            var listOfresult = new List<string>();
            foreach (string element in dictionary.Keys)
            {
                if (dictionary[element] == max)
                {
                    listOfresult.Add(element);
                }
            }
            var result = listOfresult.OrderByDescending(x => x).ToArray();
            return result.First();
        }

        public async Task Print()
        {
            string path = @"C:\Users\user\source\repos\WorkWithFiles\Files\Output.txt";
            using (StreamWriter sw1 = new StreamWriter(path, false, Encoding.UTF8))
            {
                var dict = await GetPopularLetter();
                int max = dict.Values.Max();
                foreach (char element in dict.Keys)
                {
                    if (dict[element] == max)
                    {
                        await sw1.WriteLineAsync($"The most common letter is: {element} - {dict[element]} times.");
                    }
                }
                var shortSentence = await GetShortSentence();
                await sw1.WriteLineAsync($"The shortest sentence by word count: {shortSentence}");

                var longentence = await GetLongSentence();
                await sw1.WriteLineAsync($"The longest sentence by character count: {longentence}");
            }
        }
        public async Task Creat()
        {
            string path = @"C:\Users\user\source\repos\WorkWithFiles\Files\AlphabeticalWords.txt";
            using (StreamWriter sw1 = new StreamWriter(path, false, Encoding.UTF8))
            {
                var dictonary = await GetAlfaDictionary();
                foreach (var item in dictonary.OrderBy(KeyValuePair => KeyValuePair.Key))
                {
                    await sw1.WriteLineAsync($"{item.Key} - {item.Value.ToString()}");
                }
            }
        }
    }
}
