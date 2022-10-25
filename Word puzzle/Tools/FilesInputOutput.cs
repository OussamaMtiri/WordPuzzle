using Microsoft.Extensions.Options;
using System;
using System.IO;
using Word_puzzle.ITools;
using Word_puzzle.Models;

namespace Word_puzzle.Tools
{
    public class FilesInputOutput : IFilesInputOutput
    {
        private readonly MySettings _configuration;
        private readonly Argument _argument;
        public FilesInputOutput(IOptions<MySettings> options, Argument argument)
        {
            _configuration = options.Value;
            _argument = argument;
        }

        public string[] LoadText() => File.ReadAllLines($"{_configuration.DataSource}\\{_configuration.DictionaryFile}");

        public void WriteResultToFile(string[] results)
        {
            try
            {
                if (!Directory.Exists(_configuration.ResultFolderName))
                    Directory.CreateDirectory(_configuration.ResultFolderName);

                File.WriteAllLines($"{_configuration.ResultFolderName}\\{_argument.ResultFile}.txt", results);
            }
            catch (Exception e)
            {
                ExceptionHandling.ExceptionHandlingCatching(e);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Result file created");
                Console.ResetColor();
            }
        }
    }
}
