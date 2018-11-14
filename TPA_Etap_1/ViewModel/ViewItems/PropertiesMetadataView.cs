using Loging;
using System.Collections.Generic;
using System.Linq;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class PropertiesMetadataView : ITree
    {
        private IEnumerable<PropertyMetadata> _properties;

        public PropertiesMetadataView(Logger log, IEnumerable<PropertyMetadata> properties) : base(log)
        {
            _properties = properties;
        }

        public override string Name => this.ToString();
        public override bool Expandable => _properties?.Count() > 0;

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            foreach (var child in _properties)
                Children.Add(new PropertyMetadataView(Log, child));

        }

        public override string ToString()
        {
            return "Properties:";
        }
    }
}
