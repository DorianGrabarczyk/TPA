using Loging;
using System;
using ViewModel;
using ViewModel.ViewItems;

namespace TPA_Etap_1
{
    public class ConsoleHandler : IDisplayHandler
    {
        private Reflector reflector = new Reflector();
        private Logger Log;

        public ConsoleHandler(Logger log)
        {
            Log = log;
        }

        public void DisplayMenu()
        {
            var selectedFile = SelectFile();
            OpenFile(selectedFile);
            DisplayTree();
        }

        public string SelectFile()
        {
            Console.WriteLine("Select File");
            return Console.ReadLine();

        }

        public void OpenFile(string fileName)
        {
            reflector.Reflect("../../../" + fileName);
        }

        public void DisplayTree()
        {
            AssemblyMetadataView rootItem = new AssemblyMetadataView(Log, reflector.AssemblyModel);
            rootItem.LoadChildren();
            Console.WriteLine(rootItem.Name);          
        }


    }
}
