using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WordPuzzle.IServices;
using WordPuzzle.ITools;
using WordPuzzle.Models;
using WordPuzzle.Tools;

namespace WordPuzzle.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ILoadTextGetWordsService _searchService;
        private readonly IFilesInputOutput _filesInputOutput;
        private readonly IUserInputInteraction _userInputInteraction;



        public ManagerService(ILoadTextGetWordsService searchService, IFilesInputOutput filesInputOutput, IUserInputInteraction userInputInteraction)
        {
            _searchService = searchService;
            _filesInputOutput = filesInputOutput;
            _userInputInteraction = userInputInteraction;

        }

        public void GetWords()
        {
            try
            {
                Argument argument = _userInputInteraction.GetUserArguments();
                if (!_userInputInteraction.UserArgumentsValidation(argument))
                    return;
                var result = _searchService.LoadTextAndGetWordsList(argument);
                if (result == null)
                    return;
                _filesInputOutput.WriteResultToFile(result, argument.ResultFile);
            }
            catch (Exception e)
            {
                ExceptionHandling.ExceptionHandlingCatching(e);
            }
        }
    }
}
