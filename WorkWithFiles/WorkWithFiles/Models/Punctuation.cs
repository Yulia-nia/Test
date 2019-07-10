using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithFiles.Models
{
    public class Punctuation : ISentensePart
    {
        public string Value { get; set; }       
    }
}
