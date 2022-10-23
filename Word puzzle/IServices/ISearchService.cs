using Word_puzzle.Models;

namespace Word_puzzle.IServices
{
    public interface ISearchService
    {
        string[] LoadFileAndSearch(Argument argument);
    }
}
