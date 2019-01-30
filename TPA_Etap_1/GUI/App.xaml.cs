using Mef;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NameValueCollection plugins = (NameValueCollection)ConfigurationManager.GetSection("foldery");
            string[] pluginsCatalogs = plugins.AllKeys;
            foreach (string pluginsCatalog in pluginsCatalogs)
            {
                if (Directory.Exists(pluginsCatalog))
                    Composition.MEF.AddCatalog(pluginsCatalog);
            }
        }
        protected override void OnExit(ExitEventArgs e)
        {
            Composition.MEF.Dispose(); 
        }
    }
}
