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

       // public override bool Expandable => _typeMetaData.m_Methods.Count() > 0 || _typeMetaData?.Properties.Count() > 0; // _typeMetaData.Constructors.Count() > 0;

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            // Children.Clear();
            //if (_typeMetaData.Constructors != null)
            //    Children.Add(new ConstructorsView(Log, _typeMetaData.Constructors));
            //if (_typeMetaData.m_Methods != null)
            //    Children.Add(new MethodsMetadataView(Log, _typeMetaData.m_Methods));
            //if (_typeMetaData.Properties != null)
            //    Children.Add(new PropertiesMetadataView(Log, _typeMetaData.Properties));
            if (_typeMetaData.m_Methods !=null)
                foreach(var method in _typeMetaData.m_Methods)
                {
                    Children.Add(new MethodMetadataView(Log,method));
                }
            if (_typeMetaData.m_Properties != null)
                foreach (var property in _typeMetaData.m_Properties)
                {
                    Children.Add(new PropertyMetadataView(Log,property));
                }
            if (_typeMetaData.m_BaseType != null)
                Children.Add(new TypeMetadataView(Log,_typeMetaData.m_BaseType));
            if (_typeMetaData.m_DeclaringType != null)
                Children.Add(new TypeMetadataView(Log,_typeMetaData.m_DeclaringType));

            if(_typeMetaData.m_GenericArguments !=null)
            {
                foreach(var arguments in _typeMetaData.m_GenericArguments)
                {
                    Children.Add(new TypeMetadataView(Log, arguments));
                }
            }
            if (_typeMetaData.m_ImplementedInterfaces != null)
                foreach (var inter in _typeMetaData.m_ImplementedInterfaces)
                {
                    Children.Add(new TypeMetadataView(Log,inter));
                }

            if (_typeMetaData.m_NestedTypes != null)
                foreach (var nestedType in _typeMetaData.m_NestedTypes)
                {
                    Children.Add(new TypeMetadataView(Log,nestedType));
                }

            if (_typeMetaData.m_Constructors != null)
                foreach (var constructor in _typeMetaData.m_Constructors)
                {
                    Children.Add(new MethodMetadataView(Log,constructor));
                }
        }

        public override string ToString()
        {
            return "Type : " + _typeMetaData.Name;
        }
    }
}
