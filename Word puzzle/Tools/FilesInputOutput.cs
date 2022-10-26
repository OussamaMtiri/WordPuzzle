using Microsoft.Extensions.Options;
using System;
using System.IO;
using WordPuzzle.ITools;
using WordPuzzle.Models;

namespace WordPuzzle.Tools
{
    public class FilesInputOutput : IFilesInputOutput
    {
        private readonly MySettings _configuration;
        public FilesInputOutput(IOptions<MySettings> options)
        {
            _configuration = options.Value;
        }

        public string[] LoadText() => File.ReadAllLines($"{_configuration.DataSource}\\{_configuration.DictionaryFile}");

        public void WriteResultToFile(string[] results, string resultFile)
        {
            try
            {
                if (!Directory.Exists(_configuration.ResultFolderName))
                    Directory.CreateDirectory(_configuration.ResultFolderName);

                File.WriteAllLines($"{_configuration.ResultFolderName}\\{resultFile}.txt", results);
            }
            catch (Exception e)
            {
                ExceptionHandling.ExceptionHandlingCatching(e);
                return;
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
