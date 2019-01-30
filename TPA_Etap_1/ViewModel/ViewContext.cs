using DataBase;
using DataLayer.DTO;
using Interfaces;
using Mef;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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


        private string _path;
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
            SerializeButton = new RelayCommand(Serialize);
            //SerializeButton = new RelayCommand(Serialize);
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
        public void Serialize()
        {
            string pathh = ConfigurationManager.AppSettings["connectionstring"];
            if (ConfigurationManager.AppSettings["serialization"] != "Database")
            {
                pathh = PathGetter.getTargetFilePath();
            }
            try
            {
                _reflector.AssemblyModel.Save(pathh);
            }
            catch (ArgumentException exception)
            {
                _log.Log(LogEnum.Error, exception.Message);
            }

        }

        public async Task Deserialize(string path = null)
        {
            path = ConfigurationManager.AppSettings["connectionstring"];
            if (ConfigurationManager.AppSettings["serialization"] != "Database")
            {
                if (path == null)
                {
                    path = PathGetter.getFilePath();
                }
            }
            AssemblyMetadata assembly = new AssemblyMetadata(await Task.Run(() => SerializationOperations.Read(path)));
            TreeViewLoaded(assembly);

        }

        #endregion
    }
}
