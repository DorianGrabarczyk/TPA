using System.Reflection;
using Model;

namespace ViewModel
{
    public class Reflector
    {
        public AssemblyMetadata AssemblyModel { get; set; }

        public void Reflect(string assemblyFile)
        {
            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
            AssemblyModel = new AssemblyMetadata(assembly);
        }

        public void Reflect(Assembly assembly)
        {
            AssemblyModel = new AssemblyMetadata(assembly);
        }
    }
}
