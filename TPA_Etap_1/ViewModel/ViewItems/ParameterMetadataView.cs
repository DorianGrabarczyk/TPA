using Loging;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class ParameterMetadataView : ITree
    {
        private ParameterMetadata _parameter;

        public override string Name => this.ToString();
        public override bool Expandable => _parameter.m_TypeMetadata != null;

        public ParameterMetadataView(Logger log, ParameterMetadata parameter) : base(log)
        {
            _parameter = parameter;
        }

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            base.Children.Add(new TypeMetadataView(Log, _parameter.m_TypeMetadata));
        }

        public override string ToString()
        {
            return "Parameter: " + _parameter.m_Name;
        }
    }
}
