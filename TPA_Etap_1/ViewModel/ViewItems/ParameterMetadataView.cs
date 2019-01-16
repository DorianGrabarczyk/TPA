using Interfaces;
using System.Collections.ObjectModel;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class ParameterMetadataView : ITree
    {
        private ParameterMetadata _parameter;

        public override string Name => this.ToString();

        public ParameterMetadataView(ILogger log, ParameterMetadata parameter) : base(log)
        {
            _parameter = parameter;
        }

        public override void LoadChildren(ObservableCollection<ITree> children)
        {
            if(_parameter != null)
            {
                Children.Add(new TypeMetadataView(Log, _parameter.m_TypeMetadata));
            }
           
        }

        public override string ToString()
        {
            return "Parameter: " + _parameter.m_Name;
        }
    }
}
