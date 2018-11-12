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
            //...
        }

        public override string ToString()
        {
            return "Constructors: ";
        }
    }
}
