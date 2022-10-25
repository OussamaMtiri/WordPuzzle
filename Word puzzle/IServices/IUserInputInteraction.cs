using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzle.Models;

namespace WordPuzzle.IServices
{
    public interface IUserInputInteraction
    {
        public Argument GetUserArguments();
        public bool UserArgumentsValidation(Argument argument);
    }
}
