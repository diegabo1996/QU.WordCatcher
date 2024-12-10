using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordCatcher.Application.Tests.Helpers
{
    public static class MatrixHelper
    {
        public static List<string> GenerateRandomMatrix(int size)
        {
            var random = new Random();
            return Enumerable.Range(0, size)
                .Select(_ => new string(Enumerable.Range(0, size)
                    .Select(__ => (char)random.Next('a', 'z' + 1))
                    .ToArray()))
                .ToList();
        }
        public static void HideWordsInMatrix(List<string> matrix, List<string> words)
        {
            var random = new Random();
            int size = matrix.Count;

            foreach (var word in words)
            {
                bool placed = false;

                while (!placed)
                {
                    int wordLength = word.Length;
                    int row = random.Next(size);
                    int col = random.Next(size - wordLength);

                    if (random.Next(2) == 0)
                    {
                        if (Enumerable.Range(0, wordLength).All(i => matrix[row][col + i] == word[i] || char.IsLower(matrix[row][col + i])))
                        {
                            var rowArray = matrix[row].ToCharArray();
                            for (int i = 0; i < wordLength; i++)
                            {
                                rowArray[col + i] = word[i];
                            }
                            matrix[row] = new string(rowArray);
                            placed = true;
                        }
                    }
                    else
                    {
                        if (row + wordLength <= size && Enumerable.Range(0, wordLength).All(i => matrix[row + i][col] == word[i] || char.IsLower(matrix[row + i][col])))
                        {
                            for (int i = 0; i < wordLength; i++)
                            {
                                var rowArray = matrix[row + i].ToCharArray();
                                rowArray[col] = word[i];
                                matrix[row + i] = new string(rowArray);
                            }
                            placed = true;
                        }
                    }
                }
            }
        }
    }
}
