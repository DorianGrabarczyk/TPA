using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataLayer.DTO
{
    [DataContract(IsReference = true)]
    public class BaseAssemblyMetadata
    {
        [DataMember(Name = "AssemblyName")]
        public string AssemblyName { get; set; }

        [DataMember(Name = "Namespaces")]
        public IEnumerable<BaseNamespaceMetadata> Namespaces { get; set; }
    }
}
