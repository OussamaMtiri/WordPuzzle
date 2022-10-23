﻿using Microsoft.Extensions.Options;
using System;
using System.IO;
using Word_puzzle.IServices;
using Word_puzzle.Models;

namespace Word_puzzle.Services
{
    class GetWordsService : IInputOutputService
    {
        private readonly ISearchService _searchService;
        private readonly Argument _argument;
        private readonly MySettings _configuration;

        public GetWordsService(ISearchService searchService, Argument argument, IOptions<MySettings> options)
        {
            _configuration = options.Value;
            _searchService = searchService;
            _argument = argument;
        }

        public void GetWords()
        {
            try
            {
                UserInteration();
                var result = _searchService.LoadFileAndSearch(_argument);
                WriteOutput(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UserInteration()
        {
            Console.WriteLine("Please input start word");
            //_argument.StartWord = Console.ReadLine();
            _argument.StartWord = "spin";

            Console.WriteLine("Please input end word");
            //_argument.EndWord = Console.ReadLine();
            _argument.EndWord = "spot";

            Console.WriteLine("Please input result file name");
            //_argument.ResultFile = Console.ReadLine();
            _argument.ResultFile = "res";
        }

        public void WriteOutput(string[] results)
        {
            if (!Directory.Exists(_configuration.ResultFolderName))
                Directory.CreateDirectory(_configuration.ResultFolderName);

            File.WriteAllLines($"{_configuration.ResultFolderName}\\{_argument.ResultFile}.txt", results);
        }
    }
}
