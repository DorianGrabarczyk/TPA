﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ViewModel;

namespace TPA_Etap_1
{
    public class CommandLineFilePathGetter : IFileManager
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
