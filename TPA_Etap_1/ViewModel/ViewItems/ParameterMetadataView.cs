using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class ParameterMetadataView : ITree
    {
        private ParameterMetadata _parameter;

        public override string Name => this.ToString();
        public override bool Expandable => _parameter.m_TypeMetadata != null;

        public ParameterMetadataView(ParameterMetadata parameter)
        {
            _parameter = parameter;
        }

        public override void LoadChildren()
        {
            Children.Clear();
            Children.Add(new TypeMetadataView(_parameter.m_TypeMetadata));
        }

        public override string ToString()
        {
            return "Parameter: " + _parameter.m_Name;
        }
    }
}
