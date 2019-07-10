using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithFiles.Models
{
    public class World : ISentensePart
    {
        public string Value { get; set; }

        public async Task<List<string>> GetWorlds(List<string> rawSentence)
        {
            Regex reg_worlds = new Regex(@"\b[A-Za-z0-9]+([-:\/\',]?[A-Za-z0-9]+)*\b");
            var listOfWorlds = new List<string>();
            foreach( var sent in rawSentence)
            {
                foreach (Match item in reg_worlds.Matches(sent))
                {
                    listOfWorlds.Add(item.ToString());
                }
            }           
            return listOfWorlds;
        }
    }
}
