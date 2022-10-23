using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Word_puzzle.IServices;
using Word_puzzle.Models;

namespace Word_puzzle.Services
{
    public class SearchService : ISearchService
    {
        private readonly MySettings _configuration;
        public SearchService(IOptions<MySettings> options)
        {
            _configuration = options.Value;
        }

        public string[] LoadFileAndSearch(Argument argument)
        {
            try
            {
                var wordsArray = LoadTextAndGetList();
                //Example of Tuple
                return Search((argument, wordsArray));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string[] LoadTextAndGetList() => File.ReadAllLines($"{_configuration.DataSource}\\{_configuration.DictionaryFile}");

        public string[] Search((Argument Argument, string[] WordsArray) tuple)
        {
            Argument argument = tuple.Argument;
            string[] wordsArray = tuple.WordsArray;
            int indexStartWord = Array.IndexOf(wordsArray, argument.StartWord);
            int indexEndWord = Array.IndexOf(wordsArray, argument.EndWord);
            wordsArray = wordsArray.Skip(indexStartWord).Take(indexEndWord - indexStartWord + 1).Where(w => w.Length == 4).ToArray();

            List<string> result = new() { argument.StartWord };
            foreach (var item in wordsArray)
            {
                result.Add(wordsArray.Skip(Array.IndexOf(wordsArray, item)).Where(w => item.Except(w).Count() == 1).Last());
                if (result.Last() == argument.EndWord) //
                                                       //TODO
                    break;
            }
            return result.ToArray();
        }



    }
}
