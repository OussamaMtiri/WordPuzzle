using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using WordPuzzle;
using WordPuzzle.Models;
using WordPuzzle.Services;
using WordPuzzle.Tools;

namespace WordPuzzleTests
{
    public class SearchServiceTests
    {
        [Test]
        public void LoadText()
        {
            //Arrange
            var options = GetAppSettingOptions();

            var filesInputOutput = new FilesInputOutput(options, new Argument());

            //Act
            var wordsArray = filesInputOutput.LoadText();

            //Assert
            Assert.AreEqual(26880, wordsArray.Length);
        }

        [Test]
        public void GetWordsList()
        {
            //Arrange
            var options = GetAppSettingOptions();
            Argument argument = new() { StartWord = "spin", EndWord = "spot", ResultFile = "res" };
            LoadTextGetWordsService loadTextGetWordsService = new(new FilesInputOutput(options, argument));

            //Act
            var Array = loadTextGetWordsService.LoadTextAndGetWordsList(argument);

            //Assert
            Assert.AreEqual(3, Array.Length);
        }




        public static IOptions<MySettings> GetAppSettingOptions()
        {
            string appsettingsJson = File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\appsettingsTest.json");
            var mySetting = JsonSerializer.Deserialize<MySettings>(appsettingsJson);
            return Options.Create(mySetting);
            
        }
    }
}