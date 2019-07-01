using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFiles.Models
{
    public class Sentence : ICollection<ISentensePart>
    {
        private List<ISentensePart> _sentence = new List<ISentensePart>();

        #region MyList
        public int Count => _sentence.Count;
        public string Value { get; set; }

        public bool IsReadOnly => false;
        public void Add(ISentensePart item)
        {
            _sentence.Add(item);
        }

        public void Clear()
        {
            _sentence.Clear();
        }

        public bool Contains(ISentensePart item)
        {
            return _sentence.Contains(item);
        }

        public void CopyTo(ISentensePart[] array, int arrayIndex)
        {
            _sentence.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ISentensePart> GetEnumerator()
        {
            return _sentence.GetEnumerator();
        }

        public bool Remove(ISentensePart item)
        {
            return _sentence.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<ISentensePart>)_sentence).GetEnumerator();
        }
        #endregion
    }

}
