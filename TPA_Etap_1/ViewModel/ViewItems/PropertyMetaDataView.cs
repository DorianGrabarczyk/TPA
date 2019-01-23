
using System.Collections.ObjectModel;
using Model;
using Interfaces;

namespace ViewModel.ViewItems
{
    class PropertyMetadataView : ITree
    {
        private PropertyMetadata _property;

        public PropertyMetadataView(ILogger log, PropertyMetadata property) : base(log)
        {
            _property = property;
        }

        public override string Name => this.ToString();

        public override void LoadChildren(ObservableCollection<ITree> children)
        {
            if (_property !=null)
            {
                children.Add(new TypeMetadataView(Log,_property.m_TypeMetadata));
            }
        }

        public override string ToString()
        {
            return "Property: " + _property.m_Name;
        }
    }
}
