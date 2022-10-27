using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzle.IServices;
using WordPuzzle.Models;

namespace WordPuzzle.Services
{
    public class UserInputServices : IUserInputInteraction
    {
        private readonly Argument _argument;
        public UserInputServices(Argument argument)
        {
            _argument = argument;
        }

        public Argument GetUserArguments()
        {
            Console.WriteLine("Please input start word");
            _argument.StartWord = Console.ReadLine();
            Console.WriteLine("Please input end word");
            _argument.EndWord = Console.ReadLine();
            Console.WriteLine("Please input result file name");
            _argument.ResultFile = Console.ReadLine();
            return _argument;
        }

        public bool UserArgumentsValidation(Argument argument)
        {
            var context = new ValidationContext(argument, null, null);
            var validationResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(argument, context, validationResult, true);
            if (!isValid)
            {
                foreach (var validation in validationResult)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(validation);
                }
                Console.ResetColor();
            }
            return isValid;
        }
    }
}
