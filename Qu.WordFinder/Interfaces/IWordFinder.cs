namespace Qu.WordFinder.Interfaces
{
    internal interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}