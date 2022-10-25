using WordPuzzle.Models;

namespace WordPuzzle.IServices
{
    public interface ILoadTextGetWordsService
    {
        public string[] LoadTextAndGetWordsList(Argument argument);
        public string[] GetWordsList((Argument Argument, string[] WordsArray) tuple);
    }
}
