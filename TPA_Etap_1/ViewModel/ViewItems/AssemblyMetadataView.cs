using Loging;
using System.Linq;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class AssemblyMetadataView:ITree
    {
        private AssemblyMetadata _assembly;

        public AssemblyMetadataView(Logger log, AssemblyMetadata assembly) : base(log)
        {
            _assembly = assembly;
        }

        public override string Name => this.ToString();
        public override bool Expandable => _assembly.m_Namespaces?.Count() > 0;

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            foreach (var child in _assembly.m_Namespaces)
                Children.Add(new NamespaceMetadataView(Log, child));
        }
        public override string ToString()
        {
            return "Assembly: " + _assembly.Name;
        }
    }
}
