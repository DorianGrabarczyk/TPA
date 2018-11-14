using System.Reflection;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel
{
    public class Reflector
    {
        public AssemblyMetadata AssemblyModel { get; set; }

        public void Reflect(string assemblyFile)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            AssemblyModel = new AssemblyMetadata(assembly);
        }

        public void Reflect(Assembly assembly)
        {
            AssemblyModel = new AssemblyMetadata(assembly);
        }
    }
}
