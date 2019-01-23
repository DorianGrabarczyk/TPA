using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Model
{
    
    public class TypeMetadata
    {
        public BaseTypeMetadata MapUp()
        {
            BaseTypeMetadata TypeMetadataDTO = new BaseTypeMetadata();
            TypeMetadataDTO.TypeName = m_typeName;
            TypeMetadataDTO.NamespaceName = m_NamespaceName;

            if(!BaseTypeMetadata.TypeDictionary.ContainsKey(this.m_typeName))
            {
                BaseTypeMetadata.TypeDictionary.Add(this.m_typeName, TypeMetadataDTO);
            }

            if(m_BaseType != null)
            {
                if(BaseTypeMetadata.TypeDictionary.ContainsKey(m_BaseType.m_typeName))
                {
                    TypeMetadataDTO.BaseType = BaseTypeMetadata.TypeDictionary[m_BaseType.m_typeName];
                }
                else
                {
                    TypeMetadataDTO.BaseType = m_BaseType.MapUp();
                }
            }

            if(m_GenericArguments != null)
            {
                List<BaseTypeMetadata> GenericArgumentsDTO = new List<BaseTypeMetadata>();
                foreach(TypeMetadata metadata in m_GenericArguments)
                {
                    BaseTypeMetadata baseTypeMetadata;
                    if(BaseTypeMetadata.TypeDictionary.ContainsKey(metadata.m_typeName))
                    {
                        baseTypeMetadata = BaseTypeMetadata.TypeDictionary[metadata.m_typeName];
                    }
                    else
                    {
                        baseTypeMetadata = metadata.MapUp();
                    }
                    GenericArgumentsDTO.Add(baseTypeMetadata);

                }
                TypeMetadataDTO.GenericArguments = GenericArgumentsDTO;
            }

            //TypeMetadataDTO.Modifiers = new Tuple<AccessLevel, SealedEnum, AbstractEnum>(m_Modifiers.Item1, m_Modifiers.Item2, m_Modifiers.Item3);

            if(m_ImplementedInterfaces != null)
            {
                List<BaseTypeMetadata> ImplementedInterfacesDTO = new List<BaseTypeMetadata>();
                foreach(TypeMetadata metadata in m_ImplementedInterfaces)
                {
                    BaseTypeMetadata baseTypeMetadata;
                    if(BaseTypeMetadata.TypeDictionary.ContainsKey(metadata.m_typeName))
                    {
                        baseTypeMetadata = BaseTypeMetadata.TypeDictionary[metadata.m_typeName];
                    }
                    else
                    {
                        baseTypeMetadata = metadata.MapUp();
                    }
                    ImplementedInterfacesDTO.Add(baseTypeMetadata);
                }
                TypeMetadataDTO.ImplementedInterfaces = ImplementedInterfacesDTO;
            }

            if(m_NestedTypes != null)
            {
                List<BaseTypeMetadata> NestedTypeDTO = new List<BaseTypeMetadata>();
                foreach (TypeMetadata metadata in m_NestedTypes)
                {
                    BaseTypeMetadata baseTypeMetadata;
                    if(BaseTypeMetadata.TypeDictionary.ContainsKey(metadata.m_typeName))
                    {
                        baseTypeMetadata = BaseTypeMetadata.TypeDictionary[metadata.m_typeName];
                    }
                    else
                    {
                        baseTypeMetadata = metadata.MapUp();
                    }
                    NestedTypeDTO.Add(baseTypeMetadata);
                }
                TypeMetadataDTO.NestedTypes = NestedTypeDTO;
            }
            if(m_Properties != null)
            {
                List<BasePropertyMetadata> PropertiesDTO = new List<BasePropertyMetadata>();
                foreach(PropertyMetadata metadata in m_Properties)
                {
                    BasePropertyMetadata propertyMetadata = metadata.MapUp();
                    PropertiesDTO.Add(propertyMetadata);
                }
                TypeMetadataDTO.Properties = PropertiesDTO;
            }

            if(m_DeclaringType != null)
            {
                if(BaseTypeMetadata.TypeDictionary.ContainsKey(m_DeclaringType.m_typeName))
                {
                    TypeMetadataDTO.DeclaringType = BaseTypeMetadata.TypeDictionary[m_DeclaringType.m_typeName];
                }
                else
                {
                    TypeMetadataDTO.DeclaringType = m_DeclaringType.MapUp();
                }
            }

            if(m_Methods != null)
            {
                List<BaseMethodMetadata> MethodMetadataDTO = new List<BaseMethodMetadata>();
                foreach(MethodMetadata metadata in m_Methods)
                {
                    BaseMethodMetadata methodMetadata = metadata.MapUp();
                    MethodMetadataDTO.Add(methodMetadata);
                }
                TypeMetadataDTO.Methods = MethodMetadataDTO;
            }
            if(m_Constructors!= null )
            {
                List<BaseMethodMetadata> ConstructorsDTO = new List<BaseMethodMetadata>();
                foreach(MethodMetadata metadata in m_Methods)
                {
                    BaseMethodMetadata methodMetadata = metadata.MapUp();
                    ConstructorsDTO.Add(methodMetadata);
                }
                TypeMetadataDTO.Constructors = ConstructorsDTO;
            }
            if(!BaseTypeMetadata.TypeDictionary.ContainsKey(TypeMetadataDTO.TypeName))
            {
                BaseTypeMetadata.TypeDictionary.Add(TypeMetadataDTO.TypeName, TypeMetadataDTO);
            }
            TypeMetadataDTO.TypeKind = m_TypeKind;
            return TypeMetadataDTO;
        }
        public TypeMetadata(BaseTypeMetadata typeMetadata)
        {
            m_typeName = typeMetadata.TypeName;
            m_NamespaceName = typeMetadata.NamespaceName;

            if (!BaseTypeMetadata.TypeDictionary.ContainsKey(m_typeName))
            {
                BaseTypeMetadata.TypeDictionary.Add(m_typeName, typeMetadata);
            }
            if (!m_typesMetadata.ContainsKey(m_typeName))
            {
                m_typesMetadata.Add(m_typeName, this);
            }

            if (typeMetadata.BaseType != null)
            {
                if (m_typesMetadata.ContainsKey(typeMetadata.BaseType.TypeName))
                {
                    m_BaseType = m_typesMetadata[typeMetadata.BaseType.TypeName];
                }
                else
                {
                    m_BaseType = new TypeMetadata(typeMetadata.BaseType);
                }
            }

            if (typeMetadata.GenericArguments != null)
            {
                List<TypeMetadata> genericArguments = new List<TypeMetadata>();
                foreach (BaseTypeMetadata baseMetadata in typeMetadata.GenericArguments)
                {
                    TypeMetadata metadata;
                    if (m_typesMetadata.ContainsKey(baseMetadata.TypeName))
                    {
                        metadata = m_typesMetadata[baseMetadata.TypeName];
                    }
                    else
                    {
                        metadata = new TypeMetadata(baseMetadata);
                    }
                    genericArguments.Add(metadata);
                }
                m_GenericArguments = genericArguments;
            }

            m_Modifiers = typeMetadata.Modifiers;
            //TypeKind = typeMetadata.TypeKind;

            if (typeMetadata.ImplementedInterfaces != null)
            {
                List<TypeMetadata> interfaces = new List<TypeMetadata>();
                foreach (BaseTypeMetadata baseMetadata in typeMetadata.ImplementedInterfaces)
                {
                    TypeMetadata metadata;
                    if (m_typesMetadata.ContainsKey(typeMetadata.TypeName))
                    {
                        metadata = m_typesMetadata[typeMetadata.TypeName];
                    }
                    else
                    {
                        metadata = new TypeMetadata(typeMetadata);
                    }
                    interfaces.Add(metadata);
                }
                m_ImplementedInterfaces = interfaces;
            }

            if (typeMetadata.NestedTypes != null)
            {
                List<TypeMetadata> nestedTypes = new List<TypeMetadata>();
                foreach (BaseTypeMetadata baseMetadata in typeMetadata.NestedTypes)
                {
                    TypeMetadata metadata;
                    if (m_typesMetadata.ContainsKey(baseMetadata.TypeName))
                    {
                        metadata = m_typesMetadata[baseMetadata.TypeName];
                    }
                    else
                    {
                        metadata = new TypeMetadata(baseMetadata);
                    }
                    nestedTypes.Add(metadata);
                }
                m_NestedTypes = nestedTypes;
            }

            if (typeMetadata.Properties != null)
            {
                List<PropertyMetadata> properties = new List<PropertyMetadata>();
                foreach (BasePropertyMetadata baseProperty in typeMetadata.Properties)
                {
                    PropertyMetadata propertyMetadata = new PropertyMetadata(baseProperty);
                    properties.Add(propertyMetadata);
                }
                m_Properties = properties;
            }

            if (typeMetadata.DeclaringType != null)
            {
                if (m_typesMetadata.ContainsKey(typeMetadata.DeclaringType.TypeName))
                {
                    m_DeclaringType = m_typesMetadata[typeMetadata.DeclaringType.TypeName];
                }
                else
                {
                    m_DeclaringType = new TypeMetadata(typeMetadata.DeclaringType);
                }
            }

            if (typeMetadata.Methods != null)
            {
                List<MethodMetadata> methods = new List<MethodMetadata>();
                foreach (BaseMethodMetadata methodMetadata in typeMetadata.Methods)
                {
                    MethodMetadata metadata = new MethodMetadata(methodMetadata);
                    methods.Add(metadata);
                }
                m_Methods = methods;
            }

            if (typeMetadata.Constructors != null)
            {
                List<MethodMetadata> constructors = new List<MethodMetadata>();
                foreach (BaseMethodMetadata baseMetadata in typeMetadata.Constructors)
                {
                    MethodMetadata methodMetadata = new MethodMetadata(baseMetadata);
                    constructors.Add(methodMetadata);
                }
                m_Constructors = constructors;
            }

            m_TypeKind = typeMetadata.TypeKind;
        }

        #region constructors
        internal TypeMetadata(Type type)
        {
            //m_Type = type;
            m_typeName = type.Name;
            if(!m_typesMetadata.ContainsKey(this.m_typeName))
            {
                m_typesMetadata.Add(this.m_typeName, this);
            }
            m_DeclaringType = EmitDeclaringType(type.DeclaringType);
            m_Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            m_Methods = MethodMetadata.EmitMethods(type.GetMethods());
            m_NestedTypes = EmitNestedTypes(type.GetNestedTypes());
            m_ImplementedInterfaces = EmitImplements(type.GetInterfaces());
            m_GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            m_Modifiers = EmitModifiers(type);
            m_BaseType = EmitExtends(type.BaseType);
            m_Properties = PropertyMetadata.EmitProperties(type.GetProperties());
            m_TypeKind = GetTypeKind(type);
            //m_Attributes = type.GetCustomAttributes(false).Cast<Attribute>();
        }
        #endregion

        #region API

        public static TypeMetadata EmitReference(Type type)
        {
            if (!m_typesMetadata.ContainsKey(type.Name))
            {
                if (!m_typesMetadata.ContainsKey(type.Name))
                {
                    new TypeMetadata(type);
                }
            }
            return m_typesMetadata[type.Name];
        }
        public static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> arguments)
        {
            return from Type _argument in arguments select EmitReference(_argument);
        }
        #endregion

        #region private
        //vars
        
        public string m_typeName;
        
        public string m_NamespaceName;
       
        public TypeMetadata m_BaseType;
        
        public IEnumerable<TypeMetadata> m_GenericArguments;
        
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        
        private TypeKind m_TypeKind;

        public IEnumerable<Attribute> m_Attributes;
        
        public IEnumerable<TypeMetadata> m_ImplementedInterfaces;
       
        public IEnumerable<TypeMetadata> m_NestedTypes;
        
        public IEnumerable<PropertyMetadata> m_Properties;
        
        public TypeMetadata m_DeclaringType;
        
        public IEnumerable<MethodMetadata> m_Methods;
        
        public IEnumerable<MethodMetadata> m_Constructors;
        
        public static Dictionary<string, TypeMetadata> m_typesMetadata = new Dictionary<string, TypeMetadata>();
        //constructors
        private TypeMetadata(string typeName, string namespaceName)
        {
            m_typeName = typeName;
            m_NamespaceName = namespaceName;
        }
        public TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
        {
            m_GenericArguments = genericArguments;
        }
        //methods
        public TypeMetadata EmitDeclaringType(Type declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReference(declaringType);
        }
        private IEnumerable<TypeMetadata> EmitNestedTypes(IEnumerable<Type> nestedTypes)
        {
            return from _type in nestedTypes
                   where _type.GetVisible()
                   select new TypeMetadata(_type);
        }
        private IEnumerable<TypeMetadata> EmitImplements(IEnumerable<Type> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }
        private static TypeKind GetTypeKind(Type type) //#80 TPA: Reflection - Invalid return value of GetTypeKind() 
        {
            return type.IsEnum ? TypeKind.EnumType :
                   type.IsValueType ? TypeKind.StructType :
                   type.IsInterface ? TypeKind.InterfaceType :
                   TypeKind.ClassType;
        }
        static Tuple<AccessLevel, SealedEnum, AbstractEnum> EmitModifiers(Type type)
        {
            //set defaults 
            AccessLevel _access = AccessLevel.IsPrivate;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
            SealedEnum _sealed = SealedEnum.NotSealed;
            // check if not default 
            if (type.IsPublic)
                _access = AccessLevel.IsPublic;
            else if (type.IsNestedPublic)
                _access = AccessLevel.IsPublic;
            else if (type.IsNestedFamily)
                _access = AccessLevel.IsProtected;
            else if (type.IsNestedFamANDAssem)
                _access = AccessLevel.IsProtectedInternal;
            if (type.IsSealed)
                _sealed = SealedEnum.Sealed;
            if (type.IsAbstract)
                _abstract = AbstractEnum.Abstract;
            return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(_access, _sealed, _abstract);
        }
        private static TypeMetadata EmitExtends(Type baseType)
        {
            if (baseType == null || baseType == typeof(Object) || baseType == typeof(ValueType) || baseType == typeof(Enum))
                return null;
            return EmitReference(baseType);
        }
        #endregion

        
        
    }
}