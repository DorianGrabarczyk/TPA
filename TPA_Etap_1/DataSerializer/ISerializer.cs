using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DataSerializer
{
    [ServiceContract(Name ="SerializerXML")]
    public interface  ISerializer<T>
    {
        [OperationContract]
        T Deserialize<T>(string path);
        [OperationContract]
        void Serialize<T>(T data, string path);

    }
}
