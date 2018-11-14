using GUI;
using Loging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ViewModel;
using ViewModel.ViewItems;

namespace TPA_Etap_1
{
    public class ConsoleHandler : IDisplayHandler
    {
        private Reflector reflector = new Reflector();
        private Logger Log;
        public ViewContext _viewContext;
        private int depth;
        private List<CommandTreeItems> loadedChildren = new List<CommandTreeItems>();

        public ConsoleHandler(Logger log)
        {
            Log = log;
            _viewContext = new ViewContext(log);
        }

        public void DisplayMenu()
        {
            string choice = "";
            var selectedFile = SelectFile();
            OpenFile(selectedFile);
            AssemblyMetadataView rootItem = new AssemblyMetadataView(Log, reflector.AssemblyModel);
            _viewContext.HierarchicalAreas.Add(rootItem);
            loadedChildren.Add(new CommandTreeItems(0, _viewContext.HierarchicalAreas[0]));
            Console.Clear();
            do {
                Console.WriteLine("Info:\n" +
                                  "w / expand to expand tree\n" +
                                  "s / collapse to hide one level\n" +
                                  "p / print to print tree\n" +
                                  "e / exit to close program\n" +
                                  "n / change to change path");
                choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "w")
                    ExpandTree();
                if (choice == "print" || choice == "p")
                {
                    DisplayTree(_viewContext.HierarchicalAreas, 0);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                choice = "";
                Console.Clear();
            }
            while (true);
            
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

        public void DisplayTree(ObservableCollection<ITree> items , int currentDepth)
        {
           // AssemblyMetadataView rootItem = new AssemblyMetadataView(Log, reflector.AssemblyModel);
           // rootItem.LoadChildren();
           // Console.WriteLine(rootItem.Name);
            //Console.Clear();
            foreach(var item in items)
            {
                if (item != null)
                {
                    Console.WriteLine(TabsCreator(currentDepth) + item.Name);
                    if (currentDepth < depth)
                    {
                        DisplayTree(item.Children, currentDepth + 1);
                    }
                }

            }           
        }
        private string TabsCreator(int depth)
        {
            string tabulator = "";
            for (int i = 0; i < depth; i++)
                tabulator += "   ";
            return tabulator;
        }
        public void ExpandTree()
        {
            List<ITree> toAdd = new List<ITree>();

            foreach(var item in loadedChildren)
            {
                if (item._itree != null)
                {
                    if (item._depth == depth)


                        item._itree.IsExpanded = true;


                    foreach (var child in item._itree.Children)
                    {
                        if (!loadedChildren.Select(t => t._itree).ToList().Contains(child))
                            toAdd.Add(child);
                    }
                }

            }
            foreach(var ob in toAdd)
            {
                loadedChildren.Add(new CommandTreeItems((depth + 1), ob));
            }
            depth++;


        }


    }
}
