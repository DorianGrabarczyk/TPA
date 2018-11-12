using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class TypeMetadataView:ITree
    {
        private TypeMetadata _typeMetadata;

        public TypeMetadataView(TypeMetadata typeMetadata)
        {
            _typeMetadata = typeMetadata;
        }

        public override string Name => this.ToString();

        public override bool Expandable => _typeMetadata?.m_Methods.Count() > 0 || _typeMetadata?.m_Properties.Count() > 0 || _typeMetadata?.m_Constructors.Count() > 0;

        public override void LoadChildren()
        {
            Children.Clear();
            base.Children.Add(new ConstructorsView(_typeMetadata.m_Constructors));
            Children.Add(new MethodsMetadataView(_typeMetadata.m_Methods));
            Children.Add(new PropertiesMetadataView(_typeMetadata.m_Properties));
        }

        public override string ToString()
        {
            return "Type : " + _typeMetadata.Name;
        }


    }
}
