using System;
using System.Text.RegularExpressions;
using Interfaces;

namespace TPA_Etap_1
{
    public class CommandLineFilePathGetter : IGetterFilePath
    {
        public string getFilePath()
        {
            Console.WriteLine("Wpisze scieżkę pliku");
            return Regex.Replace(Console.ReadLine(), @"\\", @"\\");
        }

        public string getTargetFilePath()
        {
            throw new NotImplementedException();
        }
    }
}
