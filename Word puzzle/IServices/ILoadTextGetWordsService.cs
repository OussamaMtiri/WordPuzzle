using Word_puzzle.Models;

namespace Word_puzzle.IServices
{
    public interface ILoadTextGetWordsService
    {
        public string[] LoadTextAndGetWordsList(Argument argument);
        public string[] GetWordsList((Argument Argument, string[] WordsArray) tuple);
    }
}
