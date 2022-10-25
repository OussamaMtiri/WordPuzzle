using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_puzzle.IServices
{
    public interface IUserInputInteraction
    {
        public void GetUserArguments();
        public bool UserArgumentsValidation();
    }
}
