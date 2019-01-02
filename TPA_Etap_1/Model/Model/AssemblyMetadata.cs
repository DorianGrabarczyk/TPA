using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using DataSerializer.DTO;

namespace TPA_Etap_1.Reflection.Model
{
    
    public class AssemblyMetadata
    {
        public BaseAssemblyMetadata MapUp()
        {
            BaseAssemblyMetadata AssemblyMetadata = new BaseAssemblyMetadata();
            AssemblyMetadata.AssemblyName = m_Name;
            if(m_Namespaces!= null)
            {
                List<BaseNamespaceMetadata> NamespaceMetadataDTO = new List<BaseNamespaceMetadata>();
                foreach(NamespaceMetadata basenamespace in m_Namespaces)
                {
                    NamespaceMetadataDTO.Add(basenamespace.MapUp());
                }
                AssemblyMetadata.Namespaces = NamespaceMetadataDTO;
            }
            return AssemblyMetadata;
        }
        public AssemblyMetadata(BaseAssemblyMetadata assemblyMetadata)
        {
            m_Name = assemblyMetadata.AssemblyName;
            if (assemblyMetadata.Namespaces != null)
            {
                List<NamespaceMetadata> namespaces = new List<NamespaceMetadata>();
                foreach(BaseNamespaceMetadata namespac in assemblyMetadata.Namespaces)
                {
                    NamespaceMetadata namespaceMetadata = new NamespaceMetadata(namespac);
                    namespaces.Add(namespaceMetadata);
                }
                m_Namespaces = namespaces;
            }
        }

        public AssemblyMetadata(Assembly assembly)
        {
            m_Name = assembly.ManifestModule.Name;
            m_Namespaces = from Type _type in assembly.GetTypes()
                           where _type.GetVisible()
                           group _type by _type.GetNamespace() into _group
                           orderby _group.Key
                           select new NamespaceMetadata(_group.Key, _group);
                           
        }
        [DataMember]
        public string m_Name;
        [DataMember(Name = "AssemblyName")]
        public IEnumerable<NamespaceMetadata> m_Namespaces { get; set; }
        //[DataMember(Name = "Namespaces")]
        public string Name { get { return m_Name; } set { Name = m_Name; } }

    }
}