using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkWithFiles.Models;

namespace WorkWithFiles
{
    class Parser
    {
        public async Task<string> OpenFile(string path)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(path))
            {
                text = await sr.ReadToEndAsync();
            }
            return text;
        }

        public async Task<Sentence[]> GetSentences(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string fullText = await OpenFile(path);
                    return await GetSentence(fullText.ToLower());
                }
                else
                    throw new FileNotFoundException($"File {path} not found");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<string>> GetSentencesString(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string fullText = await OpenFile(path);
                    return await GetSentenceByString(fullText);
                }
                else
                    throw new FileNotFoundException($"File {path} not found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<string>> GetSentenceByString(string text)
        {
            List<Sentence> sentenses = new List<Sentence>();
            var tasks = new List<Task<Sentence>>();
            Regex r = new Regex(@"[A-Za-z]+[^\n\t.!?]*[\n\t.!?]");
            var listOfSentences = new List<string>();
            foreach (Match item in r.Matches(text))
            {
                listOfSentences.Add(item.ToString());
            }
            return listOfSentences;
        }

        private async Task<Sentence[]> GetSentence(string text)
        {
            List<Sentence> sentenses = new List<Sentence>();
            var tasks = new List<Task<Sentence>>();
            Regex r = new Regex(@"[A-Za-z]+[^\n\t.!?]*[\n\t.!?]");
            var listOfSentences = new List<string>();
            foreach (Match item in r.Matches(text))
            {
                listOfSentences.Add(item.ToString());
            }
            foreach (var s in listOfSentences)
            {
                tasks.Add(Task.Run(() => ParseSentences(s)));
            }
            Task.WaitAll(tasks.ToArray());
            sentenses.AddRange(tasks.Select(t => t.Result).ToArray());
            return sentenses.ToArray();
        }



        private Sentence ParseSentences(string rawSentence)
        {
            var sentence = new Sentence();
            Regex reg_worlds = new Regex(@"\b[A-Za-z0-9]+([-:\/\',]?[A-Za-z0-9]+)*\b");
            var listOfWorlds = new List<string>();
            foreach (Match item in reg_worlds.Matches(rawSentence))
            {
                listOfWorlds.Add(item.ToString());
            }
            foreach (var item in listOfWorlds)
            {
                var tuple = GetPunctuationFromWorld(item);
                sentence.Add(tuple.Item1);
                if (tuple.Item1 != null)
                {
                    sentence.Add(tuple.Item1);
                }
                if (tuple.Item2 != null)
                {
                    sentence.Add(tuple.Item2);
                }
            }
            return sentence;
        }

        private Tuple<World, Punctuation> GetPunctuationFromWorld(string world)
        {
            StringBuilder punct = new StringBuilder("");
            while (world != "" && !char.IsLetterOrDigit(world[world.Length - 1]) == true)
            {
                punct.Append(world[world.Length - 1]);
                world = world.Remove(world.Length - 1);
            }
            return new Tuple<World, Punctuation>(
                string.IsNullOrWhiteSpace(world) ? null
                : new World() { Value = world },
                string.IsNullOrWhiteSpace(punct.ToString())
                ? null
                : new Punctuation() { Value = punct.ToString() });
        }
    }
}

