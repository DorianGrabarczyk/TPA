
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace TPA_Etap_1.Reflection.Model
{
    public class PropertyMetadata
    {

        internal static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
        {
            return from prop in props
                   where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
                   select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
        }

        #region private
        public string m_Name { get; set; }
        public TypeMetadata m_TypeMetadata { get; set; }
        public PropertyMetadata(string propertyName, TypeMetadata propertyType)
        {
            m_Name = propertyName;
            m_TypeMetadata = propertyType;
        }
        #endregion
    }
}