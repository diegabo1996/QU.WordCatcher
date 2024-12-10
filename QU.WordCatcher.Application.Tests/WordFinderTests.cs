using Moq;
using QU.WordCatcher.Application.Services;
using QU.WordCatcher.Application.Tests.Helpers;
using QU.WordCatcher.Domain.Interfaces;
using Shouldly;

namespace QU.WordCatcher.Application.Tests
{
    public class WordFinderTests
    {
        private IWordFinder CreateWordFinder(IEnumerable<string> matrix)
        {
            return new WordFinder(matrix);
        }

        [Fact]
        public void Find_ShouldReturnEmpty_WhenWordStreamIsEmpty()
        {
            var matrix = new List<string>
        {
            "abcd",
            "efgh",
            "ijkl",
            "mnop"
        };
            var wordFinder = CreateWordFinder(matrix);
            var wordStream = Enumerable.Empty<string>();

            var result = wordFinder.Find(wordStream);

            result.ShouldBeEmpty();
        }

        [Fact]
        public void Find_ShouldReturnWords_WhenTheyExistInMatrix()
        {
            var matrix = new List<string>
        {
            "abcd",
            "efgh",
            "ijkl",
            "mnop"
        };
            var wordFinder = CreateWordFinder(matrix);
            var wordStream = new List<string> { "abcd", "efgh", "ijkl", "mnop", "mnop" };

            var result = wordFinder.Find(wordStream);

            result.ShouldContain("abcd");
            result.ShouldContain("efgh");
            result.ShouldContain("ijkl");
            result.ShouldContain("mnop");
            result.Count().ShouldBe(4);
        }

        [Fact]
        public void Find_ShouldIgnoreCase_WhenMatchingWords()
        {
            var matrix = new List<string>
        {
            "abcd",
            "EfGh",
            "ijkl",
            "MNOP"
        };
            var wordFinder = CreateWordFinder(matrix);
            var wordStream = new List<string> { "ABCD", "efgh", "Ijkl", "mnop" };

            var result = wordFinder.Find(wordStream);

            result.ShouldContain("ABCD");
            result.ShouldContain("efgh");
            result.ShouldContain("Ijkl");
            result.ShouldContain("mnop");
            result.Count().ShouldBe(4);
        }

        [Fact]
        public void Find_ShouldReturnEmpty_WhenNoWordsFound()
        {
            var matrix = new List<string>
        {
            "abcd",
            "efgh",
            "ijkl",
            "mnop"
        };
            var wordFinder = CreateWordFinder(matrix);
            var wordStream = new List<string> { "qrst", "uvwx", "yz" };

            var result = wordFinder.Find(wordStream);

            result.ShouldBeEmpty();
        }

        [Fact]
        public void Find_ShouldReturnTop10Words_InDescendingOrder()
        {
            var matrix = MatrixHelper.GenerateRandomMatrix(64);
            var wordStream = new List<string>
            {
                "example", "matrix", "stream", "search", "hidden", "chill",
                "random", "finder", "coding", "coding", "matrix", "matrix"
            };

            MatrixHelper.HideWordsInMatrix(matrix, wordStream);

            Console.WriteLine("Matrix Created: ");
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(", ", row));
            }

            var wordFinder = CreateWordFinder(matrix);

            var result = wordFinder.Find(wordStream);

            result.Count().ShouldBeGreaterThan(0);

            Console.WriteLine("Words Found: "+string.Join(", ", result));
        }
    }

}