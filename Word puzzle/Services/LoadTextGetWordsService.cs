using System;
using System.Collections.Generic;
using System.Linq;
using Word_puzzle.IServices;
using Word_puzzle.ITools;
using Word_puzzle.Models;
using Word_puzzle.Tools;

namespace Word_puzzle.Services
{
    public class LoadTextGetWordsService : ILoadTextGetWordsService
    {
       private readonly IFilesInputOutput _filesInputOutput;
        public LoadTextGetWordsService(IFilesInputOutput filesInputOutput)
        {
           _filesInputOutput = filesInputOutput;    
        }

        public string[] LoadTextAndGetWordsList(Argument argument)
        {
            try
            {
                var wordsArray =_filesInputOutput.LoadText();
                return GetWordsList((argument, wordsArray));
            }
            catch (Exception e)
            {
                ExceptionHandling.ExceptionHandlingCatching(e);
                return null;
            }
        }

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
