using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer.DTO
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
