using DataBase;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loging
{
    [Export("DBLogging",typeof(ILogger))]
    public class DBLogger : ILogger
    {
        public void Log(LogEnum type, string text)
        {
            var repository = new DBMessageRepo();
            string message = "";

            message = ("[ " + DateTime.Now + " " + type + " ]: " + text);
            repository.AddMessage(message);
        }
    }
}
