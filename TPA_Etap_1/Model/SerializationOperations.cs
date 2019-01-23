using DataLayer.DTO;
using Interfaces;
using Mef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Model
{
    public class SerializationOperations
    {
        
        public static BaseAssemblyMetadata Read(string addr)
        {
            ISerializer deserializer = Composition.Container.GetExportedValue<ISerializer>(ConfigurationManager.AppSettings["serialization"]);
            return deserializer.Deserialize(addr);
        }
    }
}
