using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class MethodMetadataView : ITree
    {
        private MethodMetadata _method;

        public override string Name => this.ToString();
        public override bool Expandable => _method.m_Parameters?.Count() > 0 || _method.m_ReturnType != null;

        public MethodMetadataView(MethodMetadata method)
        {
            _method = method;
        }

        public override void LoadChildren()
        {
            //...
        }

        public override string ToString()
        {
            return "Method: " + _method.Name;
        }
    }
}
