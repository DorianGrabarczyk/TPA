using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class ConstructorsView : ITree
    {
        private IEnumerable<MethodMetadata> _constructors;

        public override string Name => this.ToString();
        public override bool Expandable => _constructors?.Count() > 0;

        public ConstructorsView(IEnumerable<MethodMetadata> constructors)
        {
            _constructors = constructors;
        }

        public override void LoadChildren()
        {
            Children.Clear();
            foreach (var child in _constructors)
                Children.Add(new MethodMetadataView(child));
        }

        public override string ToString()
        {
            return "Constructors: ";
        }
    }
}
