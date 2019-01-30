using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Configuration;

namespace Mef
{
    public class Composition
    {
        private static Composition mef = new Composition();

        public static Composition MEF
        {
            get { return mef; }
        }
        public CompositionContainer Container
        {
            get
            { 

                return _container;
            }
        }
        private  CompositionContainer _container;

        public void AddCatalog(string path)
        {
            var catalog = new DirectoryCatalog(path, "*");
            _container = new CompositionContainer(catalog);
        }

        public void ComposeParts(object obj)
        {
            _container.ComposeParts(obj);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
