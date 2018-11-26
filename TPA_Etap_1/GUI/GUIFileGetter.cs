using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace GUI
{
    public class GUIFileGetter : IGetterFilePath
    {
        public string getFilePath()
        {
            OpenFileDialog text = new OpenFileDialog()
            {
                Filter = "Dynamic Library File(*.dll)| *.dll"
            };
            text.ShowDialog();
            if (text.FileName.Length == 0)
                MessageBox.Show("Error", "File not found", MessageBoxButton.OK);

            return text.FileName;
        }
    }
}
