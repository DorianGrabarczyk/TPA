using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;
using ViewModel.ViewItems;

namespace ViewModel.ViewItems
{
    public class TypeMetadataView : ITree

    {
        private TypeMetadata _typeMetaData;

        public TypeMetadataView(TypeMetadata typeMetadata)
        {
            _typeMetaData = typeMetadata;
        }

        public override string Name => this.ToString();

        public override bool Expandable => _typeMetaData.Methods.Count() > 0 || _typeMetaData?.Properties.Count() > 0 || _typeMetaData.Constructors.Count() > 0;

        public override void LoadChildren()
        {
            Children.Clear();

            base.Children.Add(new ConstructorsView(_typeMetaData.Constructors));
            Children.Add(new MethodsMetadataView(_typeMetaData.Methods));
            Children.Add(new PropertiesMetadataView(_typeMetaData.Properties));
        }

        public override string ToString()
        {
            return "Type : " + _typeMetaData.Name;
        }
    }
}
