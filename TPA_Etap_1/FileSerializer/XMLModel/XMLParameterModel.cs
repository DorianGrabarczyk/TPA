using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileSerializer.XMLModel
{
    [DataContract(IsReference =true)]
    public class XMLParameterModel
    {
        public XMLParameterModel(BaseParameterMetadata baseParameter)
        {
            ParameterName = baseParameter.ParameterName;
            TypeMetadata = XMLTypeModel.GetOrAdd(baseParameter.TypeMetadata);
        }
        [DataMember(Name = "ParameterName")]
        public string ParameterName { get; set; }

        [DataMember(Name = "TypeMetadata")]
        public XMLTypeModel TypeMetadata { get; set; }
    }
}
