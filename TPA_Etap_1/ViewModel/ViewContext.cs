using DataSerializer;
using Loging;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System;
using ViewModel.ViewItems;
using TPA_Etap_1.Reflection.Model;
using DataSerializer.DTO;
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

        public Logger _log;
        private string _path;
        [ImportMany(typeof(ISerializer<Object>))]
        public List<ISerializer<Object>> serializer { get; set; }

        #endregion

        #region Constructors

        public ViewContext()
        {
            Composition Mef = new Composition();
            
            Mef.Compose(this);
           
            _log = new Logger("../../../Log2.txt");
            Browse_Bttn = new RelayCommand(Browse);
            //serializer = new XMLSerializer<Object>();
            HierarchicalAreas = new ObservableCollection<ITree>();  
            SerializeButton = new RelayCommand(async() => await Serialize());
            DeserializeButton = new RelayCommand(async () => await Deserialize());
            
        }
        public ViewContext(string path)
        {
            _log = new Logger("../../../Log2.txt");
            Browse_Bttn = new RelayCommand(Browse);
            //serializer = new XMLSerializer<Object>();
            HierarchicalAreas = new ObservableCollection<ITree>();
            SerializeButton = new RelayCommand(async () => await Serialize());
            //DeserializeButton = new RelayCommand(async () => await Deserialize(path));
            //Task.Run(async () => await Serialize(path));
            Task.Run (async () => await Deserialize(path));            

        }
        public ViewContext(string path,int temp)
        {
            _log = new Logger("../../../Log1.txt");
            
            //serializer = new XMLSerializer<Object>();
            HierarchicalAreas = new ObservableCollection<ITree>();
            SerializeButton = new RelayCommand(async () => await Serialize());
            DeserializeButton = new RelayCommand(async () => await Deserialize());
            Path = path;
            TreeViewLoaded();

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
        [ImportMany(typeof(Logger))]
        public List<Logger> log { get; set; }
        public IFileManager PathGetter { get; set; }

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
        public async Task Serialize(string pathh = null)
        {
            _log.Log(LogEnum.Information,"Serializacja");
            Reflector reflector = new Reflector();
            reflector.Reflect(_path);
            if(pathh == null)
            {
                pathh = PathGetter.getTargetFilePath();
            }
            try
            {
                await Task.Run(() => serializer.FirstOrDefault()?.Serialize(reflector.AssemblyModel.MapUp(),pathh));
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
            object assembly = null;


            assembly = new AssemblyMetadata(await Task.Run(() => serializer.FirstOrDefault()?.Deserialize<BaseAssemblyMetadata>(path)));
            if(assembly != null )
            {
                try
                {
                    HierarchicalAreas.Clear();
                    AssemblyMetadataView temp = new AssemblyMetadataView(_log, (AssemblyMetadata)assembly);
                    temp.LoadChildren();
                    HierarchicalAreas.Add(temp);
                    TreeViewLoaded();
                }
                catch
                {
                    HierarchicalAreas.Clear();
                    AssemblyMetadataView temp = new AssemblyMetadataView(_log, (AssemblyMetadata)assembly);
                    temp.LoadChildren();
                    HierarchicalAreas.Add(temp);
                    //TreeViewLoaded();
                }
            }
        }

        #endregion
    }
}
