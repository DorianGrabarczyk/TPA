using System.Runtime.Serialization;

namespace DataLayer.DTO
{
    [DataContract(IsReference = true)]
    public class BaseParameterMetadata
    {
        [DataMember(Name = "ParameterName")]
        public string ParameterName { get; set; }

        [DataMember(Name = "TypeMetadata")]
        public BaseTypeMetadata TypeMetadata { get; set; }
    }
}
