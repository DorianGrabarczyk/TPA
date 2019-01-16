using ViewModel.ViewItems;

namespace TPA_Etap_1
{
    public class CommandTreeItems
    {
        public int _depth;
        public ITree _itree;

        public CommandTreeItems(int depth, ITree itree)
        {
            _depth = depth;
            _itree = itree;
        }
    }
}
