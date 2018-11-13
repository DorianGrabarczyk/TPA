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
            rootItem.LoadChildren();
            Console.WriteLine(rootItem.Name);
            foreach (var a in rootItem.Children)
            {
                if (a != null)
                {
                    a.LoadChildren();
                    Console.WriteLine(" " + a.Name);
                }
                foreach (var b in a.Children)
                {
                    if (b != null)
                    {
                        b.LoadChildren();
                        Console.WriteLine("  " + b.Name);
                        foreach (var c in b.Children)
                        {
                            if (c != null)
                            {
                                c.LoadChildren();
                                Console.WriteLine("   " + c.Name);
                                foreach (var d in c.Children)
                                {
                                    if (d != null)
                                    {
                                        {
                                            d.LoadChildren();
                                            Console.WriteLine("    " + d.Name);
                                            foreach(var e in d.Children)
                                            {
                                                if(e!=null)
                                                {
                                                    e.LoadChildren();
                                                    Console.WriteLine("     " + e.Name);
                                                    foreach(var f in e.Children)
                                                    {
                                                        if(f!=null)
                                                        {
                                                            //f.LoadChildren();
                                                            Console.WriteLine("        " + f.Name);
                                                            
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                Console.ReadKey();
            }
        }


    }
}
