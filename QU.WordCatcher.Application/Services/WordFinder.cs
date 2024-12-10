using QU.WordCatcher.Application.Interfaces;
using QU.WordCatcher.Domain.Entities;
using QU.WordCatcher.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordCatcher.Application.Services
{
    public class WordFinder : IWordFinder
    {
        private readonly Matrix _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = new Matrix(matrix);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            if (wordStream == null || !wordStream.Any())
                return Enumerable.Empty<string>();

            var words = wordStream
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Select(w => new Word(w))
                .ToList();

            foreach (var word in words)
            {
                int count = CountWordOccurrences(word.Text);
                if (count > 0)
                    word.IncrementFrequency();
            }

            return words
                .Where(w => w.Frequency > 0)
                .OrderByDescending(w => w.Frequency)
                .Take(10)
                .Select(w => w.Text);
        }

        private int CountWordOccurrences(string wordText)
        {
            int count = 0;

            for (int row = 0; row < _matrix.Rows; row++)
            {
                string rowText = GetRowAsString(row);
                count += CountOccurrencesInLine(rowText, wordText);
            }

            for (int col = 0; col < _matrix.Columns; col++)
            {
                string colText = GetColumnAsString(col);
                count += CountOccurrencesInLine(colText, wordText);
            }

            return count;
        }

        private string GetRowAsString(int row)
        {
            var builder = new StringBuilder();
            for (int col = 0; col < _matrix.Columns; col++)
            {
                builder.Append(_matrix.GetCharacterAt(new Position(row, col)));
            }
            return builder.ToString();
        }

        private string GetColumnAsString(int col)
        {
            var builder = new StringBuilder();
            for (int row = 0; row < _matrix.Rows; row++)
            {
                builder.Append(_matrix.GetCharacterAt(new Position(row, col)));
            }
            return builder.ToString();
        }

        private int CountOccurrencesInLine(string line, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }
    }
}
