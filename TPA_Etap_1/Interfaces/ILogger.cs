using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
