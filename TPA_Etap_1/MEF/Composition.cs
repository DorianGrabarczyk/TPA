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
        public CompositionContainer _container;
        public AggregateCatalog _catalog = new AggregateCatalog();


        public void Compose(object obj)
        {
            //DirectoryCatalog log = new DirectoryCatalog("..\\..\\..\\Loging\\bin\\Debug");
            // _catalog.Catalogs.Add(log);
            // _container = new CompositionContainer(_catalog);

            // string log = "..\\..\\..\\Loging\\bin\\Debug";
            List<DirectoryCatalog> directoryCatalogs = new List<DirectoryCatalog>();


            if (Directory.Exists("..\\..\\..\\DataSerializer\\bin\\Debug"))
                directoryCatalogs.Add(new DirectoryCatalog("..\\..\\..\\DataSerializer\\bin\\Debug"));
            if (Directory.Exists("..\\..\\..\\Loging\\bin\\Debug"))
                directoryCatalogs.Add(new DirectoryCatalog("..\\..\\..\\Loging\\bin\\Debug"));
            AggregateCatalog catalog = new AggregateCatalog(directoryCatalogs);
            CompositionContainer container = new CompositionContainer(catalog);

            container.ComposeParts(obj);

        }
    }
}
