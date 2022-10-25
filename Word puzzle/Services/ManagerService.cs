using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Word_puzzle.IServices;
using Word_puzzle.ITools;
using Word_puzzle.Models;
using Word_puzzle.Tools;

namespace Word_puzzle.Services
{
    public class ManagerService : IGetWordsService
    {
        private readonly ILoadTextGetWordsService _searchService;
        private readonly Argument _argument;
        private readonly IFilesInputOutput _filesInputOutput;
        private readonly IUserInputInteraction _userInputInteraction;

        public ManagerService(ILoadTextGetWordsService searchService, Argument argument, IFilesInputOutput filesInputOutput, IUserInputInteraction userInputInteraction)
        {
            _searchService = searchService;
            _argument = argument;
            _filesInputOutput = filesInputOutput;
            _userInputInteraction = userInputInteraction;   
        }

        public void GetWords()
        {
            try
            {
                _userInputInteraction.GetUserArguments();
                if (!_userInputInteraction.UserArgumentsValidation())
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
