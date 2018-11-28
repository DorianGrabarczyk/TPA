using Loging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class MethodMetadataView : ITree
    {
        private MethodMetadata _method;

        public override string Name => this.ToString();
        public override bool Expandable => _method.m_Parameters?.Count() > 0 || _method.m_ReturnType != null;

        public MethodMetadataView(Logger log, MethodMetadata method) : base(log)
        {
            _method = method;
        }

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            if (_method.m_GenericArguments !=null)
            {
                foreach(var argument in _method.m_GenericArguments)
                {
                    Children.Add(new TypeMetadataView(Log, argument));
                }
            }
            if (_method.m_Parameters != null)
            {
                foreach (var parameter in _method.m_Parameters)
                {
                    Children.Add(new ParameterMetadataView(Log,parameter));
                }
            }
            if (_method.m_ReturnType !=null)
            {
                Children.Add(new TypeMetadataView(Log, _method.m_ReturnType));  
            }

        }

        public override string ToString()
        {
            if (_method.m_ReturnType != null)
            {
                return "Method: " + _method.m_ReturnType.Name + " " + _method.Name;
            }
            else 
                return "Method: " + _method.Name;
;
        }
    }
}
