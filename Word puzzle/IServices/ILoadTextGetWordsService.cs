using Word_puzzle.Models;

namespace Word_puzzle.IServices
{
    public interface ILoadTextGetWordsService
    {
        string[] LoadTextAndGetWordsList(Argument argument);
        public string[] LoadText();
        public string[] GetWordsList((Argument Argument, string[] WordsArray) tuple);
    }
}
