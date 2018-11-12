using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.ViewItems;

namespace TPA_Etap_1
{
    public class ConsoleHandler : IDisplayHandler
    {
        private Reflector reflector = new Reflector();
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
            AssemblyMetadataView rootItem = new AssemblyMetadataView(reflector.AssemblyModel);
           // rootItem.LoadChildren();
            Console.WriteLine(rootItem.Name);
            Console.ReadKey();
        }


    }
}
