namespace SearchSQL
{
    public interface ITreeView
    {
        int BuildNodes();
        int FindContentAndObjects(string word);
    }
}
