using Loging;
using System.Linq;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class NamespaceMetadataView : ITree
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
            if (_namespaceMetadata.m_Types != null)
                foreach (var child in _namespaceMetadata.m_Types)
                {
                    if (TypeMetadata.m_typesMetadata.ContainsKey(child.m_typeName))
                    {
                        Children.Add(new TypeMetadataView(Log, TypeMetadata.m_typesMetadata[child.m_typeName]));
                    }
                    else
                    {
                        Children.Add(new TypeMetadataView(Log, child));
                    }
                }


        }
        public override string ToString()
        {
            return "Namespace : " + _namespaceMetadata.m_NamespaceName;
        }


    }
}
