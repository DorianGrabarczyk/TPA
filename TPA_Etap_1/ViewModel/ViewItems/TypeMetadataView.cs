using Interfaces;
using System;
using TPA_Etap_1.Reflection.Model;
using DataLayer.DTO;
using System.Collections.ObjectModel;

namespace ViewModel.ViewItems
{
    public class TypeMetadataView : ITree
    {
        private TypeMetadata _typeMetaData;

        public TypeMetadataView(ILogger log, TypeMetadata typeMetadata) : base(log)
        {
            _typeMetaData = typeMetadata;
        }

        public override string Name => this.ToString();

       // public override bool Expandable => _typeMetaData.m_Methods.Count() > 0 || _typeMetaData?.Properties.Count() > 0; // _typeMetaData.Constructors.Count() > 0;

        public override void LoadChildren(ObservableCollection<ITree> children)
        {
            if (_typeMetaData.m_Properties != null)
                foreach (var property in _typeMetaData.m_Properties)
                {
                    children.Add(new PropertyMetadataView(Log, property));
                }
            if (_typeMetaData.m_Methods !=null)
                foreach(var method in _typeMetaData.m_Methods)
                {
                    children.Add(new MethodMetadataView(Log,method));
                }          
            if (_typeMetaData.m_BaseType != null)
                children.Add(new TypeMetadataView(Log,_typeMetaData.m_BaseType));
            if (_typeMetaData.m_DeclaringType != null)
                children.Add(new TypeMetadataView(Log,_typeMetaData.m_DeclaringType));

            if(_typeMetaData.m_GenericArguments !=null)
            {
                foreach(var arguments in _typeMetaData.m_GenericArguments)
                {
                    children.Add(new TypeMetadataView(Log, arguments));
                }
            }
            if (_typeMetaData.m_ImplementedInterfaces != null)
                foreach (var inter in _typeMetaData.m_ImplementedInterfaces)
                {
                    children.Add(new TypeMetadataView(Log,inter));
                }

            if (_typeMetaData.m_NestedTypes != null)
                foreach (var nestedType in _typeMetaData.m_NestedTypes)
                {
                    children.Add(new TypeMetadataView(Log,nestedType));
                }

            if (_typeMetaData.m_Constructors != null)
                foreach (var constructor in _typeMetaData.m_Constructors)
                {
                    children.Add(new MethodMetadataView(Log,constructor));
                }
        }

        public override string ToString()
        {
            String str = "";
            if(_typeMetaData.m_Modifiers != null)
            {
                str += _typeMetaData.m_Modifiers.Item1.ToString() + " ";
                if (_typeMetaData.m_Modifiers.Item2 == SealedEnum.Sealed)
                    str += SealedEnum.Sealed.ToString();
                if (_typeMetaData.m_Modifiers.Item3 == AbstractEnum.Abstract)
                    str += AbstractEnum.Abstract.ToString();
            }

            str += _typeMetaData.m_typeName + " ";

            return str;
        }
    }
}
