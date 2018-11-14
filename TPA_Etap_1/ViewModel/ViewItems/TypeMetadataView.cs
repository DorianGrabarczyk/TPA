using Loging;
using System.Linq;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    public class TypeMetadataView : ITree

    {
        private TypeMetadata _typeMetaData;

        public TypeMetadataView(Logger log, TypeMetadata typeMetadata) : base(log)
        {
            _typeMetaData = typeMetadata;
        }

        public override string Name => this.ToString();

        public override bool Expandable => _typeMetaData.Methods.Count() > 0 || _typeMetaData?.Properties.Count() > 0 || _typeMetaData.Constructors.Count() > 0;

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            base.Children.Add(new ConstructorsView(Log, _typeMetaData.Constructors));
            Children.Add(new MethodsMetadataView(Log, _typeMetaData.Methods));
            Children.Add(new PropertiesMetadataView(Log, _typeMetaData.Properties));
        }

        public override string ToString()
        {
            return "Type : " + _typeMetaData.Name;
        }
    }
}
