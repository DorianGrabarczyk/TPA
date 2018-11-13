using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class PropertyMetadataView : ITree
    {
        private PropertyMetadata _property;

        public PropertyMetadataView(PropertyMetadata property)
        {
            _property = property;
        }

        public override string Name => this.ToString();
        public override bool Expandable => _property.m_Name.Count() > 0;

        public override void LoadChildren()
        {
            Children.Clear();
            Children.Add(new TypeMetadataView(_property.m_TypeMetadata));
        }

        public override string ToString()
        {
            return "Property: " + _property.m_Name;
        }
    }
}
