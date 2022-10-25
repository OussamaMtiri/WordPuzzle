using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_puzzle.IServices;
using Word_puzzle.Models;

namespace Word_puzzle.Services
{
    public class UserInputInteraction : IUserInputInteraction
    {
        private readonly Argument _argument;
        public UserInputInteraction(Argument argument)
        {
            _argument = argument;
        }

        public void GetUserArguments()
        {
            Console.WriteLine("Please input start word");
            //_argument.StartWord = Console.ReadLine();
            _argument.StartWord = "spin";

            Console.WriteLine("Please input end word");
            //_argument.EndWord = Console.ReadLine();
            _argument.EndWord = "spot";

            Console.WriteLine("Please input result file name");
            //_argument.ResultFile = Console.ReadLine();
            _argument.ResultFile = "dd";
        }

        public bool UserArgumentsValidation()
        {
            var context = new ValidationContext(_argument, null, null);
            var validationResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(_argument, context, validationResult, true);
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
