using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithFiles.Models
{
    public class Sentence 
    {
        private List<string> _sentence = new List<string>();
        public async Task<List<string>> GetSentenceByString(string text)
        {
            Regex r = new Regex(@"[A-Za-z]+[^.!?]*[.!?]");
            foreach (Match item in r.Matches(text))
            {
                _sentence.Add(item.ToString());
            }
            return _sentence;
        }
    }
}
