using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    [DataContract(IsReference = true)]
    public class BaseTypeMetadata
    {
        //[DataMember(Name = "TypeDictionary")]
        public static Dictionary<string, BaseTypeMetadata> TypeDictionary = new Dictionary<string, BaseTypeMetadata>();

        [DataMember(Name = "TypeName")]
        public string TypeName;

        [DataMember(Name = "NamespaceName")]
        public string NamespaceName;

        [DataMember(Name = "BaseType")]
        public BaseTypeMetadata BaseType;

        [DataMember(Name = "GenericArguments")]
        public IEnumerable<BaseTypeMetadata> GenericArguments;

        [DataMember(Name = "Modifiers")]
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers;

        //public IEnumerable<Attribute> Attributes;

        [DataMember(Name = "ImplementedInterfaces")]
        public IEnumerable<BaseTypeMetadata> ImplementedInterfaces;

        [DataMember(Name = "NestedTypes")]
        public IEnumerable<BaseTypeMetadata> NestedTypes;

        [DataMember(Name = "Properties")]
        public IEnumerable<BasePropertyMetadata> Properties;

        [DataMember(Name = "DeclaringType")]
        public BaseTypeMetadata DeclaringType;

        [DataMember(Name = "Methods")]
        public IEnumerable<BaseMethodMetadata> Methods;

        [DataMember(Name = "Constructors")]
        public IEnumerable<BaseMethodMetadata> Constructors;

        [DataMember(Name = "TypeKind")]
        public TypeKind TypeKind;
    }
}
