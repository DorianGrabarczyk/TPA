using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataSerializer.DTO
{
    public class BasePropertyMetadata
    {
        [DataMember(Name = "PropertyName")]
        public string Name { get; set; }

        [DataMember(Name = "TypeMetadata")]
        public BaseTypeMetadata TypeMetadata { get; set; }
    }
}
