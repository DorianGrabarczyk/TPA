using System.Runtime.Serialization;

namespace DataLayer.DTO
{
    public class BasePropertyMetadata
    {
        [DataMember(Name = "PropertyName")]
        public string Name { get; set; }

        [DataMember(Name = "TypeMetadata")]
        public BaseTypeMetadata TypeMetadata { get; set; }
    }
}
