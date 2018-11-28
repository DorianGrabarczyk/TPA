using Loging;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class PropertyMetadataView : ITree
    {
        private PropertyMetadata _property;

        public PropertyMetadataView(Logger log, PropertyMetadata property) : base(log)
        {
            _property = property;
        }

        public override string Name => this.ToString();
        public override bool Expandable => _property.m_TypeMetadata != null;

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            if (_property !=null)
            {
                if (TypeMetadata.m_typesMetadata.ContainsKey(_property.m_TypeMetadata.Name))
                    Children.Add(new TypeMetadataView(base.Log, TypeMetadata.m_typesMetadata[_property.m_TypeMetadata.Name]));
                else
                    Children.Add(new TypeMetadataView(base.Log, _property.m_TypeMetadata));
            }
        }

        public override string ToString()
        {
            return "Property: " + _property.m_Name;
        }
    }
}
