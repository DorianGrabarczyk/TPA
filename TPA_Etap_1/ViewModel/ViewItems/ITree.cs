using Loging;
using System.Collections.ObjectModel;

namespace ViewModel.ViewItems
{
    public abstract class ITree
    {
        public ITree(Logger log)
        {
            Log = log;
            Children = new ObservableCollection<ITree> { null };
            built = false;
        }

        public abstract string Name { get; }
        public ObservableCollection<ITree> Children { get; set; }

        internal Logger Log;

        private bool isExpanded;
        private bool built;
        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                isExpanded = value;
                if (built)
                    return;
                Children.Clear();
                LoadChildren(Children);
                built = true;
            }
        }
        public virtual void LoadChildren(ObservableCollection<ITree> children)
        {
            Log.Log(LogEnum.Information, Name + "'s children were loaded.");
        }
    }
}

     
