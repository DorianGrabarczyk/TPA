
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TPA_Etap_1.Reflection.Model
{
    [DataContract(IsReference = true)]
    public class NamespaceMetadata
    {

        public NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            m_NamespaceName = name;
            m_Types = from type in types orderby type.Name select new TypeMetadata(type);
        }

        [DataMember(Name = "NamespaceName")]
        public string m_NamespaceName;
        [DataMember(Name = "Types")]
        public IEnumerable<TypeMetadata> m_Types;
        
        

    }
}