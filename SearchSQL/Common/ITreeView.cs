namespace SearchSQL
{
    public interface ITreeView : ISaveFile
    {
        int BuildNodes();
        int FindContentAndObjects(string word);
    }
}
