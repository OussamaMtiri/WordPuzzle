using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Word_puzzle.IServices;
using Word_puzzle.Models;

namespace Word_puzzle.Services
{
    public class LoadTextGetWordsService : ILoadTextGetWordsService
    {
        private readonly MySettings _configuration;
        public LoadTextGetWordsService(IOptions<MySettings> options)
        {
            _configuration = options.Value;
        }

        public string[] LoadTextAndGetWordsList(Argument argument)
        {
            try
            {
                var wordsArray = LoadText();
                return GetWordsList((argument, wordsArray));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string[] LoadText() => File.ReadAllLines($"{_configuration.DataSource}\\{_configuration.DictionaryFile}");

        public string[] GetWordsList((Argument Argument, string[] WordsArray) tuple)
        {    //Example of Tuple(Not Needed)
            Argument argument = tuple.Argument;
            string[] wordsArray = tuple.WordsArray;
            int indexStartWord = Array.IndexOf(wordsArray, argument.StartWord);
            int indexEndWord = Array.IndexOf(wordsArray, argument.EndWord);
            wordsArray = wordsArray.Skip(indexStartWord).Take(indexEndWord - indexStartWord + 1).Where(w => w.Length == 4).ToArray();
            List<string> result = new() { argument.StartWord };
            foreach (var item in wordsArray)
            {
                result.Add(wordsArray.Skip(Array.IndexOf(wordsArray, item)).Where(w => item.Except(w).Count() == 1).Last());
                if (result.Last() == argument.EndWord)
                    break;
            }
            return result.ToArray();
        }



    }
}
