using System.Runtime.Serialization;
using DataLayer.DTO;
namespace Model
{
    
    public class ParameterMetadata
    {
        public BaseParameterMetadata MapUp()
        {
            BaseParameterMetadata ParameterMetadataDTO = new BaseParameterMetadata();
            ParameterMetadataDTO.ParameterName = m_Name;
            if(m_TypeMetadata != null)
            {
                if(BaseTypeMetadata.TypeDictionary.ContainsKey(m_TypeMetadata.m_typeName))
                {
                    ParameterMetadataDTO.TypeMetadata = BaseTypeMetadata.TypeDictionary[m_TypeMetadata.m_typeName];
                }
                else
                {
                    ParameterMetadataDTO.TypeMetadata = m_TypeMetadata.MapUp();
                }
            }
            return ParameterMetadataDTO;
        }
        public ParameterMetadata(BaseParameterMetadata parameterMetadata)
        {
            m_Name = parameterMetadata.ParameterName;
            if(parameterMetadata.TypeMetadata != null)
            {
                if(TypeMetadata.m_typesMetadata.ContainsKey(parameterMetadata.TypeMetadata.TypeName))
                {
                    m_TypeMetadata = TypeMetadata.m_typesMetadata[parameterMetadata.TypeMetadata.TypeName];
                }
                else
                {
                    m_TypeMetadata = new TypeMetadata(parameterMetadata.TypeMetadata);
                }
            }
        }
        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            this.m_Name = name;
            this.m_TypeMetadata = typeMetadata;
        }

        //private vars
        
        public string m_Name { get; set; }
        
        public TypeMetadata m_TypeMetadata { get; set; }

    }
}