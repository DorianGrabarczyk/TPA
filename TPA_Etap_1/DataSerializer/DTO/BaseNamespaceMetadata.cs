using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataLayer.DTO
{
    [DataContract(IsReference = true)]
    public class BaseNamespaceMetadata
    {
        [DataMember(Name = "NamespaceName")]
        public string NamespaceName { get; set; }

        [DataMember(Name = "Types")]
        public IEnumerable<BaseTypeMetadata> Types { get; set; }
    }
}
