using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class PropertiesMetadataView : ITree
    {
        private IEnumerable<PropertyMetadata> _properties;

        public PropertiesMetadataView(IEnumerable<PropertyMetadata> properties)
        {
            _properties = properties;
        }

        public override string Name => this.ToString();
        public override bool Expandable => _properties?.Count() > 0;

        public override void LoadChildren()
        {
            //...
        }

        public override string ToString()
        {
            return "Properties:";
        }
    }
}
