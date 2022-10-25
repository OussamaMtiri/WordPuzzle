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
        [TestCase(26880)]
        public void LoadText_CalculateLenght_ReturnLenghtOfDocument(int lenthExpected)
        {
            //Arrange
            var options = GetAppSettingOptions();
            var filesInputOutput = new FilesInputOutput(options, new Argument());

            //Act
            var wordsArray = filesInputOutput.LoadText();

            //Assert
            Assert.AreEqual(lenthExpected, wordsArray.Length);
        }

        [TestCase("spin", "spot", "res", 3)]
        public void GetWordsList_Count_ReturnWordsCount(string startWord, string endWord, string resultFile, int lenthExpected)
        {
            //Arrange
            var options = GetAppSettingOptions();
            Argument argument = new() { StartWord = startWord, EndWord = endWord, ResultFile = resultFile };
            LoadTextGetWordsService loadTextGetWordsService = new(new FilesInputOutput(options, argument));

            //Act
            var Array = loadTextGetWordsService.LoadTextAndGetWordsList(argument);

            //Assert
            Assert.AreEqual(lenthExpected, Array.Length);
        }

        [TestCase("spin", "spot", null)]
        public void UserArgumentsValidation_TryValidateNullArgument_ValidationFail(string startWord, string endWord, string resultFile)
        {
            //Arrange
            Argument argument = new() { StartWord = startWord, EndWord = endWord, ResultFile = resultFile };
            UserInputServices userInputServices = new(argument);

            //Act
            bool isValid = userInputServices.UserArgumentsValidation(argument);

            //Assert
            Assert.AreNotEqual(true, isValid);
        }

        public static IOptions<MySettings> GetAppSettingOptions()
        {
            string appsettingsJson = File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\appsettingsTest.json");
            var mySetting = JsonSerializer.Deserialize<MySettings>(appsettingsJson);
            return Options.Create(mySetting);

        }
    }
}