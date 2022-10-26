using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.IO;
using System.Text.Json;
using WordPuzzle;
using WordPuzzle.ITools;
using WordPuzzle.Models;
using WordPuzzle.Services;
using WordPuzzle.Tools;

namespace WordPuzzleTests
{
    public class UnitTests
    {
        #region LoadTextGetWordsServiceTests
        [TestCase("spin", "spot", "res", 3)]
        public void GetWordsList_Count_ReturnWordsCount(string startWord, string endWord, string resultFile, int lenthExpected)
        {
            //Arrange
            var options = Tools.GetAppSettingOptions();
            Argument argument = new() { StartWord = startWord, EndWord = endWord, ResultFile = resultFile };
            LoadTextGetWordsService loadTextGetWordsService = new(new FilesInputOutput(options), options);

            //Act
            var Array = loadTextGetWordsService.LoadTextAndGetWordsList(argument);

            //Assert
            Assert.AreEqual(lenthExpected, Array.Length);
        }
        #endregion

        #region FilesInputOutputTests
        [TestCase(26880)]
        public void LoadText_CalculateLenght_ReturnLenghtOfDocument(int lenthExpected)
        {
            //Arrange
            var options = Tools.GetAppSettingOptions();
            var filesInputOutput = new FilesInputOutput(options);

            //Act
            var wordsArray = filesInputOutput.LoadText();

            //Assert
            Assert.AreEqual(lenthExpected, wordsArray.Length);
        }

        [TestCase(new string[] { "word1", "word2" }, "testResultFile")]
        public void WriteResultToFile_CreateFile_fileSuccessfullyCreated(string[] results, string resultFile)
        {
            //Arrange
            bool fileExists = false;
            var options = Tools.GetAppSettingOptions();
            var filesInputOutput = new FilesInputOutput(options);

            //Act
            filesInputOutput.WriteResultToFile(results, resultFile);
            if (!Directory.Exists(resultFile))
                fileExists = true;

            //Assert
            Assert.IsTrue(fileExists);
        }
        #endregion

        #region UserInputServices
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
        #endregion       
    }
}