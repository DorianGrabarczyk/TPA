using Loging;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ViewModel;
using ViewModel.ViewItems;

namespace ViewModel
{
    public class ViewContext : INotifyPropertyChanged
    {
        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private

        private Logger _log;
        private string _path;

        #endregion

        #region Constructors

        public ViewContext()
        {
            _log = new Logger("../../../Log.txt");
            Browse_Bttn = new RelayCommand(Browse);
            HierarchicalAreas = new ObservableCollection<ITree>();
        }


        #endregion

        #region DC

        public ObservableCollection<ITree> HierarchicalAreas { get; set; }
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                RaisePropertyChanged(nameof(Path));
            }
        }
        public ICommand Browse_Bttn { get; }
        public ICommand Button { get; }

        public IGetterFilePath PathGetter {get;set;}

        public void TreeViewLoaded()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(_path);
            AssemblyMetadataView rootItem = new AssemblyMetadataView(_log, reflector.AssemblyModel);
            rootItem.LoadChildren();
            HierarchicalAreas.Add(rootItem);
        }
        public void Browse()
        {
            _log.Log(LogEnum.Information, "Loading file path");
            string _path = PathGetter.getFilePath();
            if (_path.Substring(_path.Length - 4) == ".dll")
            {
                Path = _path;
                RaisePropertyChanged("Path");
                TreeViewLoaded();
            }


        }

        #endregion
    }
}
