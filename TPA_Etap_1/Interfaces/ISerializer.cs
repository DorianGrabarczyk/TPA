using DataLayer.DTO;

namespace Interfaces
{
    public interface ISerializer
    {
        BaseAssemblyMetadata Deserialize(string path);

        void Serialize(BaseAssemblyMetadata target, string path);
    }
}
