using DataLayer.DTO;
using Interfaces;
using Mef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel.Composition;

namespace Model
{
    public class SerializationOperations
    {
        
        [Import(typeof(ISerializer))]
        ISerializer serializer { get; set; }


        public static void Save(BaseAssemblyMetadata baseAssembly, string addr)
        {
            ISerializer serializer = Composition.MEF.Container.GetExportedValue<ISerializer>(ConfigurationManager.AppSettings["serialization"]);
            ILogger logger = Composition.MEF.Container.GetExportedValue<ILogger>(ConfigurationManager.AppSettings["logging"]);
            serializer.Serialize(baseAssembly, addr);
        }
        public static  BaseAssemblyMetadata Read(string addr)
        {
            ISerializer serializer = Composition.MEF.Container.GetExportedValue<ISerializer>(ConfigurationManager.AppSettings["serialization"]);
            ILogger logger = Composition.MEF.Container.GetExportedValue<ILogger>(ConfigurationManager.AppSettings["logging"]);
            return serializer.Deserialize(addr);
        }
    }
}
