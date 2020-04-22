namespace FindLines.Interfaces
{
    public interface IProcessWriter<T>
    {
        void WriteProcessStart();
        void WriteProcessResult(T result);
        void WriteProcessEnd();
    }
}
