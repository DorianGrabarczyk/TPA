namespace Interfaces
{
    public enum LogEnum
    {
        Error,
        Warning,
        Information
    }

    public interface ILogger
    {
        void Log(LogEnum type, string text);
    }
}
