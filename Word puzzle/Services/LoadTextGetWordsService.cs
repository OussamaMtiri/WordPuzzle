using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using WordPuzzle.IServices;
using WordPuzzle.ITools;
using WordPuzzle.Models;
using WordPuzzle.Tools;

namespace WordPuzzle.Services
{
    public class LoadTextGetWordsService : ILoadTextGetWordsService
    {
        private readonly IFilesInputOutput _filesInputOutput;
        private readonly MySettings _configuration;
        public LoadTextGetWordsService(IFilesInputOutput filesInputOutput, IOptions<MySettings> options)
        {
            _filesInputOutput = filesInputOutput;
            _configuration = options.Value;
        }

        public string[] LoadTextAndGetWordsList(Argument argument)
        {
            try
            {
                var wordsArray = _filesInputOutput.LoadText();
                return GetWordsList(argument, wordsArray);
            }
            catch (Exception e)
            {
                ExceptionHandling.ExceptionHandlingCatching(e);
                return null;
            }
        }

        public string[] GetWordsList(Argument argument, string[] wordsArray)
        {
            int indexStartWord = Array.IndexOf(wordsArray, argument.StartWord);
            int indexEndWord = Array.IndexOf(wordsArray, argument.EndWord);
            wordsArray = wordsArray.Skip(indexStartWord).Take(indexEndWord - indexStartWord + 1).Where(w => w.Length == _configuration.WordLength).ToArray();
            List<string> result = new() { argument.StartWord };
            string toAdd;
            foreach (var item in wordsArray)
            {
                toAdd = wordsArray.Skip(Array.IndexOf(wordsArray, item)).Where(w => item.Except(w).Count() == 1).Last();
                if (!result.Contains(toAdd))
                    result.Add(toAdd);

                if (result.Last() == argument.EndWord)
                    break;
            }
            return result.ToArray();
        }
    }
}
