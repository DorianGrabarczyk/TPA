using DataSerializer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TPA_Etap_1.Reflection.Model
{
    public class NamespaceMetadata
    {
        public BaseNamespaceMetadata MapUp()
        {
            BaseNamespaceMetadata NamespaceMetadataDTO = new BaseNamespaceMetadata();
            NamespaceMetadataDTO.NamespaceName = m_NamespaceName;
            if(m_Types !=null)
            {
                List<BaseTypeMetadata> TypesMetadataDTO = new List<BaseTypeMetadata>();
                foreach(TypeMetadata metadata in m_Types)
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
                    TypesMetadataDTO.Add(baseTypeMetadata);

                }
                NamespaceMetadataDTO.Types = TypesMetadataDTO;
            }
            return NamespaceMetadataDTO;
        }
        public NamespaceMetadata(BaseNamespaceMetadata namespaceMetadata)
        {
            m_NamespaceName = namespaceMetadata.NamespaceName;
            List<TypeMetadata> types = new List<TypeMetadata>();

            foreach(BaseTypeMetadata metadata in namespaceMetadata.Types)
            {
                TypeMetadata type;
                if(TypeMetadata.m_typesMetadata.ContainsKey(metadata.TypeName))
                {
                    type = TypeMetadata.m_typesMetadata[metadata.TypeName];
                }
                else
                {
                    type = new TypeMetadata(metadata);
                }
                types.Add(type);
            }
            m_Types = types;
        }
        public NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            m_NamespaceName = name;
            m_Types = from type in types orderby type.Name select new TypeMetadata(type);
        }

        
        public string m_NamespaceName;
        
        public IEnumerable<TypeMetadata> m_Types;
        
        

    }
}