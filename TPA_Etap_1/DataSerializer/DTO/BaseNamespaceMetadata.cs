using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer.DTO
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
