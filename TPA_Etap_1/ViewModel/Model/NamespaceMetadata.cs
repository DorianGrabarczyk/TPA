
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPA_Etap_1.Reflection.Model
{
    public class NamespaceMetadata
    {

        public NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            m_NamespaceName = name;
            m_Types = from type in types orderby type.Name select new TypeMetadata(type);
        }

        private string m_NamespaceName;
        public IEnumerable<TypeMetadata> m_Types;
        public string Name { get { return m_NamespaceName; } set { Name = m_NamespaceName; } }

    }
}