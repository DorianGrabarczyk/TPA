using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Etap_1
{
    public interface IDisplayHandler
    {
        void DisplayMenu();

        string SelectFile();
    }
}
