using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordCatcher.Domain.Entities
{
    public class Word
    {
        public string Text { get; }
        public int Frequency { get; private set; }

        public Word(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Word text cannot be null or empty.");

            Text = text;
            Frequency = 0;
        }

        public void IncrementFrequency()
        {
            Frequency++;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Word other) return false;
            return string.Equals(Text, other.Text, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Text.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }
    }

}
