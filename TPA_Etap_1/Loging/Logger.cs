using System;
using System.Diagnostics;
using System.IO;

namespace Loging
{
    public class Logger
    {
        private string path;

        public Logger(string destination)
        {
            path = destination;
            StreamWriter file = File.CreateText(path);

            Trace.Listeners.Add(new TextWriterTraceListener(file));
            Trace.AutoFlush = true;
        }

        public void Log(LogEnum type, string text)
        {
            Trace.WriteLine("[ " + DateTime.Now + " " + type + " ]: " + text);
        }
    }
}
