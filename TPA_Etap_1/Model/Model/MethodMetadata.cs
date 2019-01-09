
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using DataSerializer.DTO;


namespace TPA_Etap_1.Reflection.Model
{

    public class MethodMetadata
    {
        public BaseMethodMetadata MapUp()
        {
            BaseMethodMetadata MethodMetadataDTO = new BaseMethodMetadata();
            MethodMetadataDTO.MethodName = m_Name;
            if(m_GenericArguments!= null)
            {
                List<BaseTypeMetadata> GenericArgumentsDTO = new List<BaseTypeMetadata>();
                foreach(TypeMetadata metadata in m_GenericArguments)
                {
                    BaseTypeMetadata baseTypeMetadata;
                    if (BaseTypeMetadata.TypeDictionary.ContainsKey(metadata.m_typeName))
                    {
                        baseTypeMetadata = BaseTypeMetadata.TypeDictionary[metadata.m_typeName];
                    }
                    else
                    {
                        baseTypeMetadata = metadata.MapUp();
                    }
                    GenericArgumentsDTO.Add(baseTypeMetadata);
                }
                MethodMetadataDTO.GenericArguments = GenericArgumentsDTO;
                
            }
            MethodMetadataDTO.Modifiers = new Tuple<AccessLevel, AbstractEnum,StaticEnum,VirtualEnum>(m_Modifiers.Item1, m_Modifiers.Item2, m_Modifiers.Item3,m_Modifiers.Item4);
            
            if(m_ReturnType != null)
            {
                if(BaseTypeMetadata.TypeDictionary.ContainsKey(m_ReturnType.m_typeName))
                {
                    MethodMetadataDTO.ReturnType = BaseTypeMetadata.TypeDictionary[m_ReturnType.m_typeName];
                }
                else
                {
                    MethodMetadataDTO.ReturnType = m_ReturnType.MapUp();
                }
            }
            MethodMetadataDTO.Extension = m_Extension;
            if(m_Parameters!= null)
            {
                List<BaseParameterMetadata> ParameterDTO = new List<BaseParameterMetadata>();
                foreach(ParameterMetadata metadata in m_Parameters)
                {
                    BaseParameterMetadata baseParameterMetadata = metadata.MapUp();
                    ParameterDTO.Add(baseParameterMetadata);
                }
                MethodMetadataDTO.Parameters = ParameterDTO;
            }
            return MethodMetadataDTO;
        }
        public MethodMetadata(BaseMethodMetadata methodMetadata)
        {
            m_Name = methodMetadata.MethodName;
            if (methodMetadata.GenericArguments != null)
            {
                List<TypeMetadata> genericArguments = new List<TypeMetadata>();
                foreach (BaseTypeMetadata baseMetadata in methodMetadata.GenericArguments)
                {
                    TypeMetadata metadata;
                    if (TypeMetadata.m_typesMetadata.ContainsKey(baseMetadata.TypeName))
                    {
                        metadata = TypeMetadata.m_typesMetadata[baseMetadata.TypeName];
                    }
                    else
                    {
                        metadata = new TypeMetadata(baseMetadata);
                    }
                    genericArguments.Add(metadata);
                }
                m_GenericArguments = genericArguments;
            }

            if (methodMetadata.ReturnType != null)
            {
                if (TypeMetadata.m_typesMetadata.ContainsKey(methodMetadata.ReturnType.TypeName))
                {
                    m_ReturnType = TypeMetadata.m_typesMetadata[methodMetadata.ReturnType.TypeName];
                }
                else
                {
                    m_ReturnType = new TypeMetadata(methodMetadata.ReturnType);
                }
            }

            m_Extension = methodMetadata.Extension;

            if (methodMetadata.Parameters != null)
            {
                List<ParameterMetadata> parameters = new List<ParameterMetadata>();
                foreach (BaseParameterMetadata baseMetadata in methodMetadata.Parameters)
                {
                    ParameterMetadata metadata = new ParameterMetadata(baseMetadata);
                    parameters.Add(metadata);
                }
                m_Parameters = parameters;
            }

            m_Modifiers = methodMetadata.Modifiers;
        }
        internal static IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
        {
            return from MethodBase _currentMethod in methods
                   where _currentMethod.GetVisible()
                   select new MethodMetadata(_currentMethod);
        }

        #region private
        //vars
        
        private string m_Name;
        
        public IEnumerable<TypeMetadata> m_GenericArguments;
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> m_Modifiers;
        
        public TypeMetadata m_ReturnType;
        
        public bool m_Extension;
        
        public IEnumerable<ParameterMetadata> m_Parameters { get; set; }
        //constructor
        private MethodMetadata(MethodBase method)
        {
            m_Name = method.Name;
            m_GenericArguments = !method.IsGenericMethodDefinition ? null : TypeMetadata.EmitGenericArguments(method.GetGenericArguments());
            m_ReturnType = EmitReturnType(method);
            m_Parameters = EmitParameters(method.GetParameters());
            m_Modifiers = EmitModifiers(method);
            m_Extension = EmitExtension(method);
        }
        //methods
        private static IEnumerable<ParameterMetadata> EmitParameters(IEnumerable<ParameterInfo> parms)
        {
            return from parm in parms
                   select new ParameterMetadata(parm.Name, TypeMetadata.EmitReference(parm.ParameterType));
        }
        private static TypeMetadata EmitReturnType(MethodBase method)
        {
            MethodInfo methodInfo = method as MethodInfo;
            if (methodInfo == null)
                return null;
            return TypeMetadata.EmitReference(methodInfo.ReturnType);
        }
        private static bool EmitExtension(MethodBase method)
        {
            return method.IsDefined(typeof(ExtensionAttribute), true);
        }
        private static Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> EmitModifiers(MethodBase method)
        {
            AccessLevel _access = AccessLevel.IsPrivate;
            if (method.IsPublic)
                _access = AccessLevel.IsPublic;
            else if (method.IsFamily)
                _access = AccessLevel.IsProtected;
            else if (method.IsFamilyAndAssembly)
                _access = AccessLevel.IsProtectedInternal;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
            if (method.IsAbstract)
                _abstract = AbstractEnum.Abstract;
            StaticEnum _static = StaticEnum.NotStatic;
            if (method.IsStatic)
                _static = StaticEnum.Static;
            VirtualEnum _virtual = VirtualEnum.NotVirtual;
            if (method.IsVirtual)
                _virtual = VirtualEnum.Virtual;
            return new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(_access, _abstract, _static, _virtual);
        }
        #endregion
        
        public string Name { get { return m_Name; } set { Name = m_Name; } }
    }
}