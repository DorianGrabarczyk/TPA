using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
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
        }


        #endregion

        #region DC

        public ObservableCollection<ITree> HierarchicalAreas { get; set; }
        public string PathVariable
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
            OpenFileDialog text = new OpenFileDialog();
            text.ShowDialog();
        }

        #endregion
    }
}
