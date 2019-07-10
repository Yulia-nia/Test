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
        public async Task<List<string>> GetSentences(string path)
        {
            try
            {
                Sentence sent = new Sentence();
                if (File.Exists(path))
                {
                    string fullText = await OpenFile(path);
                    return await sent.GetSentenceByString(fullText);
                }
                else
                    throw new FileNotFoundException($"File {path} not found");
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}

