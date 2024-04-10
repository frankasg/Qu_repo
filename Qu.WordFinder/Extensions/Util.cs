using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrieNet.Ukkonen;

namespace Qu.WordFinder.Extensions
{
    internal static class Util
    {
        internal static char[,] ConvertToMatrix(this string[] matrixArray, int numRows, int numColumns)
        {
            var result = new char[numRows, numColumns];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    result[i, j] = matrixArray[i][j];
                }
            }

            return result;
        }
    
        internal static UkkonenTrie<char, int> ConstructTrie(this char[,] matrix, int numRows, int numColumns)
        {
            var trie = new UkkonenTrie<char, int>(0);
            int count = 0;
            // Horizontal words
            for (int i = 0; i < numRows; i++)
            {
                var horizontalWord = new StringBuilder();
                for (int j = 0; j < numColumns; j++)
                {
                    horizontalWord.Append(matrix[i, j]);
                }
                trie.Add(horizontalWord.ToString().AsMemory(), count++);
            }

            // Vertical words
            for (int j = 0; j < numColumns; j++)
            {
                var verticalWord = new StringBuilder();
                for (int i = 0; i < numRows; i++)
                {
                    verticalWord.Append(matrix[i, j]);
                }
                trie.Add(verticalWord.ToString().AsMemory(), count++);
            }

            return trie;
        }
    }
}
