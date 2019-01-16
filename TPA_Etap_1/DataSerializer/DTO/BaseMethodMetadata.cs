using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataLayer.DTO
{
    public class BaseMethodMetadata
    {
        [DataMember(Name = "MethodName")]
        public string MethodName { get; set; }

        [DataMember(Name = "GenericArguments")]
        public IEnumerable<BaseTypeMetadata> GenericArguments { get; set; }

        [DataMember(Name = "Modifiers")]
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers { get; set; }

        [DataMember(Name = "ReturnType")]
        public BaseTypeMetadata ReturnType { get; set; }

        [DataMember(Name = "Extension")]
        public bool Extension { get; set; }

        [DataMember(Name = "Parameters")]
        public IEnumerable<BaseParameterMetadata> Parameters { get; set; }
    }
}
