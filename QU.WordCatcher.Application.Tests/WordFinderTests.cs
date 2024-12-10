using Moq;
using QU.WordCatcher.Application.Interfaces;
using QU.WordCatcher.Application.Services;
using QU.WordCatcher.Application.Tests.Helpers;
using Shouldly;

namespace QU.WordCatcher.Application.Tests
{
    public class WordFinderTests
    {
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
            var wordFinder = new WordFinder(matrix);
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
            var wordFinder = new WordFinder(matrix);
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
            var wordFinder = new WordFinder(matrix);
            var wordStream = new List<string> { "ABCD", "efgh", "Ijkl", "mnop" };

            var result = wordFinder.Find(wordStream);

            result.ShouldContain("ABCD");
            result.ShouldContain("efgh");
            result.ShouldContain("Ijkl");
            result.ShouldContain("mnop");
            result.Count().ShouldBe(4);
        }

        [Fact]
        public void Find_ShouldReturnTop10Words_WhenMoreThanTenExist_InLargeMatrix()
        {
            var matrix = MatrixHelper.GenerateRandomMatrix(64);
            var wordStream = new List<string>
            {
                "example", "matrix", "stream", "search", "hidden", "chill",
                "random", "finder", "coding", "testcase", "python", "extra"
            };

            MatrixHelper.HideWordsInMatrix(matrix, wordStream);

            var wordFinder = new WordFinder(matrix);

            var result = wordFinder.Find(wordStream);

            result.Count().ShouldBeGreaterThanOrEqualTo(10); 
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
            var wordFinder = new WordFinder(matrix);
            var wordStream = new List<string> { "qrst", "uvwx", "yz" };

            var result = wordFinder.Find(wordStream);

            result.ShouldBeEmpty();
        }
    }

}