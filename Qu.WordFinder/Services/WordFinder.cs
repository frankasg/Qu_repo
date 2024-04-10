
using Qu.WordFinder.Extensions;
using Qu.WordFinder.Interfaces;

namespace Qu.WordFinder.Services
{
    internal class WordFinder : IWordFinder
    {
        private readonly char[,] _matrix;
        private readonly int _numRows;
        private readonly int _numColumns;

        public WordFinder(IEnumerable<string> matrix)
        {
            var matrixArray = matrix.ToArray();
            _numRows = matrixArray.Length;
            _numColumns = matrixArray[0].Length;
            _matrix = matrixArray.ConvertToMatrix(_numRows, _numColumns);
        }
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var trie = _matrix.ConstructTrie(_numRows, _numColumns); 

            var wordCounts = new Dictionary<string, int>();

            foreach (var word in wordstream)
            {
                var result = trie.RetrieveSubstrings(word.AsSpan()).ToArray();
                var ocurrences = result.Count();
                if (ocurrences > 0 && !wordCounts.ContainsKey(word))
                {
                    wordCounts[word] = ocurrences;
                }
            }
            return wordCounts.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).Take(10);
        }  
        
    }
}
