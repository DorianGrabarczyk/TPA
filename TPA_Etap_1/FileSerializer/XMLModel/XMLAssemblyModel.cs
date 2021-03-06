﻿using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileSerializer.XMLModel
{
    [DataContract(IsReference = true)]
    [Export(typeof(BaseAssemblyMetadata))]
    public class XMLAssemblyModel
    {
        public XMLAssemblyModel()
        {

        }
        public XMLAssemblyModel(BaseAssemblyMetadata assemblyBase)
        {
            AssemblyName = assemblyBase.AssemblyName;
            Namespaces = assemblyBase.Namespaces?.Select(ns => new XMLNamespaceModel(ns));
        }
        public string AssemblyName { get; set; }

        public IEnumerable<XMLNamespaceModel> Namespaces { get; set; }
    }
}
