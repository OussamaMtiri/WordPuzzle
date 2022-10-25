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
                //throw new ArgumentNullException();
                Argument _argument=_userInputInteraction.GetUserArguments();
                if (!_userInputInteraction.UserArgumentsValidation(_argument))
                    return;
                var result = _searchService.LoadTextAndGetWordsList(_argument);
                _filesInputOutput.WriteResultToFile(result);
            }
            catch (Exception e)
            {
                ExceptionHandling.ExceptionHandlingCatching(e);
            }
        }
    }
}
