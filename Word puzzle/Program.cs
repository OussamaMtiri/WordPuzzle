using Word_puzzle.Tools;

namespace WordPuzzle
{
    class Program
    {
        public static void Main()
        {
            var managerService = AppStartup.Setup();
            managerService.GetWords();
        }
    }
}