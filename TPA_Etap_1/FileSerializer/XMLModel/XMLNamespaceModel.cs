﻿using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileSerializer.XMLModel
{
    [DataContract(IsReference = true)]
    public class XMLNamespaceModel
    {
        private XMLNamespaceModel()
        {

        }
        public XMLNamespaceModel(BaseNamespaceMetadata namespaceBase)
        {
            NamespaceName = namespaceBase.NamespaceName;
            Types = namespaceBase.Types?.Select(t => XMLTypeModel.GetOrAdd(t));
        }

        [DataMember(Name = "NamespaceName")]
        public string NamespaceName { get; set; }

        [DataMember(Name = "Types")]
        public IEnumerable<XMLTypeModel> Types { get; set; }

    }
}
