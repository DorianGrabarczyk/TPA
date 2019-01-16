using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using Interfaces;
using ViewModel.ViewItems;
using TPA_Etap_1.Reflection.Model;
using Mef;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;

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

        private string _path;

        [ImportMany(typeof(ISerializer))]
        public IEnumerable<ISerializer> serializer { get; set; }

        [Import(typeof(ILogger))]
        public ILogger _log { get; set; }

        [Import(typeof(IGetterFilePath))]
        public IGetterFilePath PathGetter { get; set; }

        public Reflector _reflector;

        #endregion

        #region Constructors

        public ViewContext()
        {
            Composition Mef = new Composition();
            
            Mef.Compose(this);
            Browse_Bttn = new RelayCommand(Browse);
            HierarchicalAreas = new ObservableCollection<ITree>();  
            SerializeButton = new RelayCommand(async() => await Serialize());
            DeserializeButton = new RelayCommand(async () => await Deserialize());
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
        public ICommand SerializeButton { get; }
        public ICommand DeserializeButton { get; }

        public void TreeViewLoaded(AssemblyMetadata AssemblyMetadata)
        {
            ITree rootItem = new AssemblyMetadataView(_log, AssemblyMetadata);
            HierarchicalAreas.Add(rootItem);
            _log.Log(LogEnum.Information, "Tree view was loaded.");
        }

        public void Browse()
        {
            _log.Log(LogEnum.Information, "Loading file path");
            string _path = PathGetter.getFilePath();
            if (_path.Substring(_path.Length - 4) == ".dll")
            {
                Path = _path;
                RaisePropertyChanged("Path");
                _reflector = new Reflector();
                _reflector.Reflect(Path);
                TreeViewLoaded(_reflector.AssemblyModel);
            }
        }

        public async Task Serialize(string pathh = null)
        {
            pathh = PathGetter.getTargetFilePath();
            try
            {
                await Task.Run(() => serializer.FirstOrDefault()?.Serialize(_reflector.AssemblyModel.MapUp(),pathh));
                _log.Log(LogEnum.Information, "DLL file was serialized.");
            }
            catch(ArgumentException exception)
            {
                _log.Log(LogEnum.Error, exception.Message);
            }
        }

        public async Task Deserialize(string path = null)
        {
            if(path == null)
            {
                path = PathGetter.getFilePath();
            }
            
            AssemblyMetadata assembly = new AssemblyMetadata(await Task.Run(() => serializer.FirstOrDefault()?.Deserialize(path)));
            TreeViewLoaded(assembly);

            _log.Log(LogEnum.Information, "DLL file was deserialized.");
        }

        #endregion
    }
}
