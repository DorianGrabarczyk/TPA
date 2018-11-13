using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ViewModel;
using ViewModel.ViewItems;

namespace GUI
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

        private string _path;
        private Visibility _visibility;

        #endregion

        #region Constructors

        public ViewContext()
        {
            Browse_Bttn = new RelayCommand(Browse);
            HierarchicalAreas = new ObservableCollection<ITree>();
        }


        #endregion

        #region DC

        public ObservableCollection<ITree> HierarchicalAreas { get; set; }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public Visibility ChangeControlVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
            }
        }
        public ICommand Browse_Bttn { get; }
        public ICommand Button { get; }

        public void Browse()
        {
            OpenFileDialog text = new OpenFileDialog()
            {
                Filter = "Dynamic Library File(*.dll)| *.dll"
            };
            text.ShowDialog();

            if (text.FileName.Length == 0)
            {
                MessageBox.Show("No file was selected.");
            }
            else
            {
                _path = text.FileName;
                _visibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("Path");

                if (_path.Substring(_path.Length - 4) == ".dll")
                    TreeViewLoaded();
            }
        }

        public void TreeViewLoaded()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(_path);
            AssemblyMetadataView rootItem = new AssemblyMetadataView(reflector.AssemblyModel);
            rootItem.LoadChildren();
            HierarchicalAreas.Add(rootItem);
        }

        #endregion
    }
}
