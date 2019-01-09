using Loging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class AssemblyMetadataView : ITree
    {
        private AssemblyMetadata _assembly;

        public AssemblyMetadataView(Logger log, AssemblyMetadata assembly) : base(log)
        {
            _assembly = assembly;
        }

        public override string Name => this.ToString();

        public override void LoadChildren(ObservableCollection<ITree> children)
        {           
            var namespaceList = _assembly.m_Namespaces.ToList();
            if (namespaceList != null)
            {
                foreach (var child in _assembly.m_Namespaces)
                    if (child != null)
                        children.Add(new NamespaceMetadataView(Log, child));
            }
        }
        public override string ToString()
        {
            String str = _assembly.Name;
            return str;
        }
    }
}
