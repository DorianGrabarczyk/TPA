using Loging;
using System.Linq;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class NamespaceMetadataView:ITree
    {
        private NamespaceMetadata _namespaceMetadata;

        public NamespaceMetadataView(Logger log, NamespaceMetadata namespaceMetadata) : base(log)
        {
            _namespaceMetadata = namespaceMetadata;
        }
        public override bool Expandable => _namespaceMetadata.m_Types?.Count() > 0;

        public override string Name => this.ToString();

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            foreach (var child in _namespaceMetadata.m_Types)
                Children.Add(new TypeMetadataView(Log, child));
        }
        public override string ToString()
        {
            return "Namespace : " + _namespaceMetadata.Name;
        }


    }
}
