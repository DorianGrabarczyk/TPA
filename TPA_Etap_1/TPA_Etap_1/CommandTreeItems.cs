using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewItems;

namespace TPA_Etap_1
{
    public class CommandTreeItems
    {
        public int _depth;
        public ITree _itree;

        public CommandTreeItems(int depth,ITree itree)
        {
            _depth = depth;
            _itree = itree;
        }
    }
}
