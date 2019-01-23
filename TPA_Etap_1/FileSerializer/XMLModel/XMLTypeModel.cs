using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileSerializer.XMLModel
{
    [DataContract(IsReference = true)]
    public class XMLTypeModel
    {
        //[DataMember(Name = "TypeDictionary")]
        public static Dictionary<string, XMLTypeModel> TypeDictionary = new Dictionary<string, XMLTypeModel>();

        [DataMember(Name = "TypeName")]
        public string TypeName { get; set; }

        [DataMember(Name = "NamespaceName")]
        public string NamespaceName { get; set; }

        [DataMember(Name = "BaseType")]
        public XMLTypeModel BaseType { get; set; }

        [DataMember(Name = "GenericArguments")]
        public IEnumerable<XMLTypeModel> GenericArguments { get; set; }

        [DataMember(Name = "Modifiers")]
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get; set; }

        //public IEnumerable<Attribute> Attributes;

        [DataMember(Name = "ImplementedInterfaces")]
        public IEnumerable<XMLTypeModel> ImplementedInterfaces { get; set; }

        [DataMember(Name = "NestedTypes")]
        public IEnumerable<XMLTypeModel> NestedTypes { get; set; }

        [DataMember(Name = "Properties")]
        public IEnumerable<XMLPropertyModel> Properties { get; set; }

        [DataMember(Name = "DeclaringType")]
        public XMLTypeModel DeclaringType { get; set; }

        [DataMember(Name = "Methods")]
        public IEnumerable<XMLMethodModel> Methods { get; set; }

        [DataMember(Name = "Constructors")]
        public IEnumerable<XMLMethodModel> Constructors { get; set; }

        [DataMember(Name = "TypeKind")]
        public TypeKind TypeKind { get; set; }

        private XMLTypeModel()
        {

        }
        public XMLTypeModel(BaseTypeMetadata typeBase)
        {
            if(!TypeDictionary.ContainsKey(typeBase.TypeName))
            {
                TypeDictionary.Add(typeBase.TypeName, this);
            }
            TypeName = typeBase.TypeName;
            NamespaceName = typeBase.NamespaceName;
            TypeKind = typeBase.TypeKind;

            BaseType = GetOrAdd(typeBase.BaseType);
            DeclaringType = GetOrAdd(typeBase.DeclaringType);

            Modifiers = new Tuple<AccessLevel, SealedEnum, AbstractEnum>(typeBase.Modifiers.Item1, typeBase.Modifiers.Item2, typeBase.Modifiers.Item3);

            Constructors = typeBase.Constructors?.Select(c => new XMLMethodModel(c));
            GenericArguments = typeBase.GenericArguments?.Select(GetOrAdd);
            ImplementedInterfaces = typeBase.ImplementedInterfaces?.Select(GetOrAdd);
            Methods = typeBase.Methods?.Select(m => new XMLMethodModel(m));
            NestedTypes = typeBase.NestedTypes?.Select(GetOrAdd);
            Properties = typeBase.Properties?.Select(p => new XMLPropertyModel(p));

        }

        public static XMLTypeModel GetOrAdd(BaseTypeMetadata baseType)
        {
            if (baseType != null)
            {
                if (TypeDictionary.ContainsKey(baseType.TypeName))
                {
                    return TypeDictionary[baseType.TypeName];
                }
                else
                {
                    return new XMLTypeModel(baseType);
                }
            }
            else
                return null;
        }
    }
}
