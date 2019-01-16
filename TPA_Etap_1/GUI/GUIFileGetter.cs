using System.ComponentModel.Composition;
using Microsoft.Win32;
using System.Windows;
using Interfaces;

namespace GUI
{
    [Export(typeof(IGetterFilePath))]
    public class GUIFileGetter : IGetterFilePath
    {
        public string getFilePath()
        {
            OpenFileDialog text = new OpenFileDialog();
            text.ShowDialog();
            if (text.FileName.Length == 0)
                MessageBox.Show("Error", "File not found", MessageBoxButton.OK);

            return text.FileName;
        }

        public string getTargetFilePath()
        {
            string path = null;
            SaveFileDialog text = new SaveFileDialog();
            text.ShowDialog();
            path = text.FileName;
            return path;
        }
    }
}
