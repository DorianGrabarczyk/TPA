using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class MethodsMetadataView : ITree
    {
        private IEnumerable<MethodMetadata> _methods;

        public override string Name => throw new NotImplementedException();
        public override bool Expandable => _methods?.Count() > 0;

        public MethodsMetadataView(IEnumerable<MethodMetadata> methods)
        {
            _methods = methods;
        }

        public override void LoadChildren()
        {
            //...
        }

        public override string ToString()
        {
            return "Methods: ";
        }
    }
}
