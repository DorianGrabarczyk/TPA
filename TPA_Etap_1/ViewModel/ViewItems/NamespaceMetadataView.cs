using Interfaces;
using System.Collections.ObjectModel;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class NamespaceMetadataView : ITree
    {
        private NamespaceMetadata _namespaceMetadata;

        public NamespaceMetadataView(ILogger log, NamespaceMetadata namespaceMetadata) : base(log)
        {
            _namespaceMetadata = namespaceMetadata;
        }

        public override string Name => this.ToString();

        public override void LoadChildren(ObservableCollection<ITree> children)
        {

            if (_namespaceMetadata.m_Types != null)
                foreach (var child in _namespaceMetadata.m_Types)
                {
                    Children.Add(new TypeMetadataView(Log,child));
                }
        }

        public override string ToString()
        {
            return "Namespace : " + _namespaceMetadata.m_NamespaceName;
        }
    }
}
