using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class AssemblyMetadataView:ITree
    {
        private AssemblyMetadata _assembly;

        public AssemblyMetadataView(AssemblyMetadata assembly)
        {
            _assembly = assembly;
        }

        public override string Name => this.ToString();
        public override bool Expandable => _assembly.m_Namespaces.Count() > 0;

        public override void LoadChildren()
        {
            Children.Clear();
            foreach (var child in _assembly.m_Namespaces)
                Children.Add(new NamespaceMetadataView(child));
        }
        public override string ToString()
        {
            return "Assembly: " + _assembly.Name;
        }
    }
}
