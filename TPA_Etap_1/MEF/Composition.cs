using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Mef
{
    public class Composition
    {
        public CompositionContainer _container;
        public AggregateCatalog _catalog = new AggregateCatalog();


        public void Compose(object obj)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            DirectoryCatalog exe = new DirectoryCatalog("..\\..\\..\\parts", "*.exe");
            DirectoryCatalog dll = new DirectoryCatalog("..\\..\\..\\parts");
            catalog.Catalogs.Add(exe);
            catalog.Catalogs.Add(dll);
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(obj);
        }
    }
}
