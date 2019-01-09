using DataSerializer.DTO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Runtime.Serialization;

namespace TPA_Etap_1.Reflection.Model
{
    
    public class PropertyMetadata
    {
        public BasePropertyMetadata MapUp()
        {
            BasePropertyMetadata PropertyMetadataDTO = new BasePropertyMetadata();
            PropertyMetadataDTO.Name = m_Name;
            if(m_TypeMetadata != null)
            {
                if (BaseTypeMetadata.TypeDictionary.ContainsKey(m_TypeMetadata.m_typeName))
                {
                    PropertyMetadataDTO.TypeMetadata = BaseTypeMetadata.TypeDictionary[m_TypeMetadata.m_typeName];
                }
                else
                {
                    PropertyMetadataDTO.TypeMetadata = m_TypeMetadata.MapUp();
                }                   
            }
            return PropertyMetadataDTO;
        }
        public PropertyMetadata(BasePropertyMetadata propertyMetadata)
        {
            m_Name = propertyMetadata.Name;
            if(propertyMetadata.TypeMetadata != null)
            {
                if(TypeMetadata.m_typesMetadata.ContainsKey(propertyMetadata.TypeMetadata.TypeName))
                {
                    m_TypeMetadata = TypeMetadata.m_typesMetadata[propertyMetadata.TypeMetadata.TypeName];
                }
                else
                {
                    m_TypeMetadata = new TypeMetadata(propertyMetadata.TypeMetadata);
                }
            }
        }

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