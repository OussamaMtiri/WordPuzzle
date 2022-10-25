using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle.Tools
{
    public class ExceptionHandling
    {
        public Exception Exception { get; set; }
        public static void ExceptionHandlingCatching(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
    }
}
