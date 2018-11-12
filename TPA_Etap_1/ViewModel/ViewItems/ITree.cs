using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewItems
{
    public abstract class ITree
    {
        public ITree()
        {
            Children = new ObservableCollection<ITree>();
            Children.Add(null);
            isExpanded = false;
        }
        public abstract string Name { get; }
        public ObservableCollection<ITree> Children { get; set; }

        private bool isExpanded;
        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                if (Expandable)
                    isExpanded = value;
                        if (isExpanded)
                            LoadChildren();

            }
        }
        public virtual bool Expandable => Children?.Count > 0;

        public abstract void LoadChildren();
    }
}
