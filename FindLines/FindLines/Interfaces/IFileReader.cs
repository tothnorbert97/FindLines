namespace FindLines.Interface
{
    public interface IFileReader<T>
    {
        string[] CollectFilePaths();
        T Read(string path);
    }
}
