using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{

    public interface ISerializer
    {

        BaseAssemblyMetadata Deserialize(string path);

        void Serialize(BaseAssemblyMetadata target, string path);

    }
}
