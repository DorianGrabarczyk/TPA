using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;

namespace Loging
{
    [Export(typeof(Logger))]
    public class Logger
    {
        private string path;
        public Logger()
        {

            path = "..\\..\\..\\log.txt";
            StreamWriter file = File.CreateText(path);

            Trace.Listeners.Add(new TextWriterTraceListener(file));
            Trace.AutoFlush = true;

        }

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
