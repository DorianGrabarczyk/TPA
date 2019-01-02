using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer.DTO
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
