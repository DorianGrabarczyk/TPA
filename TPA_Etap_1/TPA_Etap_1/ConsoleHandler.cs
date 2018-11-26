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

        public ConsoleHandler()
        {
            _viewContext = new ViewContext()
            {
                PathGetter = new CommandLineFilePathGetter()
            };
        }

        public void DisplayMenu()
        {
            string choice = "";
            _viewContext.Path = _viewContext.PathGetter.getFilePath();
            _viewContext.TreeViewLoaded();
            loadedChildren.Add(new CommandTreeItems(0, _viewContext.HierarchicalAreas[0]));
            Console.Clear();
            do
            {
                Console.WriteLine("Informations:\n" +
                                  "w to expand tree\n" +
                                  "c to compress one level\n" +
                                  "p  to print tree\n" +
                                  "exit to close program\n" +
                                  "ch to change path");
                choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "w")
                    ExpandTree();
                if (choice == "c")
                    compressTree();
                if (choice == "print" || choice == "p")
                {
                    DisplayTree(_viewContext.HierarchicalAreas, 0);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                if (choice == "ch")
                {
                    _viewContext.Path = _viewContext.PathGetter.getFilePath();
                    _viewContext.TreeViewLoaded();
                    loadedChildren.Add(new CommandTreeItems(0, _viewContext.HierarchicalAreas[0]));
                }
                if (choice == "exit")
                    return;
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

        public void DisplayTree(ObservableCollection<ITree> items, int currentDepth)
        {
            // AssemblyMetadataView rootItem = new AssemblyMetadataView(Log, reflector.AssemblyModel);
            // rootItem.LoadChildren();
            // Console.WriteLine(rootItem.Name);
            //Console.Clear();
            foreach (var item in items)
            {
                if (item != null)
                {
                    Console.WriteLine(paragraphs(currentDepth) + item.Name);
                    if (currentDepth < depth)
                    {
                        DisplayTree(item.Children, currentDepth + 1);
                    }
                }

            }
        }
        private string paragraphs(int depth)
        {
            string tabulator = "";
            for (int i = 0; i < depth; i++)
                tabulator += "   ";
            return tabulator;
        }
        public void ExpandTree()
        {
            List<ITree> toAdd = new List<ITree>();

            foreach (var item in loadedChildren)
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
            foreach (var ob in toAdd)
            {
                loadedChildren.Add(new CommandTreeItems((depth + 1), ob));
                Log.Log(LogEnum.Information, "Element " + ob.Name + " was added.");
            }
            depth++;
            Log.Log(LogEnum.Information, "Expanded to depth " + depth);
        }

        public void compressTree()
        {
            if (depth > 0)
            {
                foreach (var item in loadedChildren)
                {

                    if (item._depth == depth)
                    {
                        if (item._itree != null)
                            item._itree.IsExpanded = false;
                    }

                }
                depth--;
                Log.Log(LogEnum.Information, "Tree compressed to depth " + depth);
            }
            else Log.Log(LogEnum.Warning, "Tree cannot be compressed further.");
        }


    }
}
