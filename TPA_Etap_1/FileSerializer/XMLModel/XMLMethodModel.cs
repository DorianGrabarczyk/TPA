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
    public class XMLMethodModel
    {
        [DataMember(Name = "MethodName")]
        public string MethodName { get; set; }

        [DataMember(Name = "GenericArguments")]
        public IEnumerable<XMLTypeModel> GenericArguments { get; set; }

        [DataMember(Name = "Modifiers")]
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers { get; set; }

        [DataMember(Name = "ReturnType")]
        public XMLTypeModel ReturnType { get; set; }

        [DataMember(Name = "Extension")]
        public bool Extension { get; set; }

        [DataMember(Name = "Parameters")]
        public IEnumerable<XMLParameterModel> Parameters { get; set; }

        private XMLMethodModel()
        {

        }
        public XMLMethodModel(BaseMethodMetadata methodBase)
        {
            MethodName = methodBase.MethodName;
            Extension = methodBase.Extension;
            ReturnType = XMLTypeModel.GetOrAdd(methodBase.ReturnType);
            Modifiers = new Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>(methodBase.Modifiers.Item1, methodBase.Modifiers.Item2, methodBase.Modifiers.Item3, methodBase.Modifiers.Item4);
            GenericArguments = methodBase.GenericArguments?.Select(g => XMLTypeModel.GetOrAdd(g));
            Parameters = methodBase.Parameters?.Select(p => new XMLParameterModel(p));

         }
    }
}
