using Microsoft.Extensions.Options;
using NUnit.Framework;
using Word_puzzle;
using Word_puzzle.Models;
using Word_puzzle.Services;

namespace WordPuzzleTests
{
    public class SearchServiceTests
    {
        [Test]
        public void LoadText()
        {
            //Arrange
            var options = Options.Create(new MySettings() { DataSource = "DataSource", DictionaryFile = "words-english.txt", ResultFolderName = "ResultFolder" });
            var searchService = new LoadTextGetWordsService(options);

            //Act
            var wordsArray = searchService.LoadText();

            //Assert
            Assert.AreEqual(26880, wordsArray.Length);           
        }

        [Test]
        public void GetWordsList()
        {
            //Arrange
            var options = Options.Create(new MySettings() { DataSource = "DataSource", DictionaryFile = "words-english.txt", ResultFolderName = "ResultFolder" });
            var searchService = new LoadTextGetWordsService(options);
            var wordsArray = searchService.LoadText();

            //Act
            var Array = searchService.GetWordsList((new Argument { StartWord = "spin", EndWord = "spot", ResultFile = "res" }, wordsArray));

            //Assert
            Assert.AreEqual(3, Array.Length);
        }
    }
}