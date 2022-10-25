namespace Word_puzzle.ITools
{
    public interface IFilesInputOutput
    {
        public string[] LoadText() ;
        public void WriteResultToFile(string[] results);
    }
}