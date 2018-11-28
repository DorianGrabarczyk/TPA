using System.Runtime.Serialization;
namespace TPA_Etap_1.Reflection.Model
{
    [DataContract(IsReference = true)]
    public class ParameterMetadata
  {

    public ParameterMetadata(string name, TypeMetadata typeMetadata)
    {
      this.m_Name = name;
      this.m_TypeMetadata = typeMetadata;
    }

        //private vars
        [DataMember]
        public string m_Name { get; set; }
        [DataMember]
        public TypeMetadata m_TypeMetadata { get; set; }

    }
}