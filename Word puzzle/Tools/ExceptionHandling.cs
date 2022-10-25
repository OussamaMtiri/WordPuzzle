using Serilog;
using System;

namespace WordPuzzle.Tools
{
    public class ExceptionHandling
    {        
        public static void ExceptionHandlingCatching(Exception exception)
        {
            var log = new LoggerConfiguration()
                  .WriteTo.RollingFile("Logs\\Log.txt")
                  .CreateLogger();
            log.Information(exception.Message);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
    }
}
