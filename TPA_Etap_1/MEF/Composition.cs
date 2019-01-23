using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace Mef
{
    public class Composition
    {
        private CompositionContainer _container;
        public static CompositionContainer container;
        private AggregateCatalog _catalog = new AggregateCatalog();
         public static CompositionContainer Container
        {
            get
            {
                if (container == null)
                {
                    var catalog = new DirectoryCatalog("..\\..\\..\\parts", "*");
                    container = new CompositionContainer(catalog);
                }

                return container;
            }
        }

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
