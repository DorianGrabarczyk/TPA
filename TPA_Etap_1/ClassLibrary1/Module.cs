using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mef
{
    public class ModuleList<T> : List<T>
    {
        private int _choosenModule = 0;
        public List<String> GetPluginNames()
        {
            List<String> temp = new List<string>();
            foreach (T plugin in this)
            {
                temp.Add(plugin.GetType().Name);
            }

            return temp;
        }

        public T GetCurrentModule()
        {
            return this[_choosenModule];
        }

        public void SetCurrentModule(int number)
        {
            if (this[number] != null)
            {
                _choosenModule = number;
            }
        }
    }
}
