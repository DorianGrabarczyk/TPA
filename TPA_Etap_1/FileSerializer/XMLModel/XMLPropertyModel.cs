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
    public class XMLPropertyModel
    {
        public XMLPropertyModel(BasePropertyMetadata propertyBase)
        {
            Name = propertyBase.Name;
            TypeMetadata = XMLTypeModel.GetOrAdd(propertyBase.TypeMetadata);
        }
        [DataMember(Name = "PropertyName")]
        public string Name { get; set; }

        [DataMember(Name = "TypeMetadata")]
        public XMLTypeModel TypeMetadata { get; set; }
    }
}
