
using System;
using Model;
using DataLayer.DTO;
using System.Collections.ObjectModel;
using Interfaces;

namespace ViewModel.ViewItems
{
    class MethodMetadataView : ITree
    {
        private MethodMetadata _method;

        public override string Name => this.ToString();

        public MethodMetadataView(ILogger log, MethodMetadata method) : base(log)
        {
            _method = method;
        }

        public override void LoadChildren(ObservableCollection<ITree> children)
        {

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
            String str = _method.m_Modifiers.Item1.ToString() + " "; //Access level
            if (_method.m_Modifiers.Item2 == AbstractEnum.Abstract) // Abstract
                str += AbstractEnum.Abstract.ToString() + " ";
            if (_method.m_Modifiers.Item3 == StaticEnum.Static) //Static
                str += StaticEnum.Static.ToString() + " ";
            if (_method.m_Modifiers.Item4 == VirtualEnum.Virtual) // Virtual 
                str += VirtualEnum.Virtual.ToString() + " ";
            if (_method.m_ReturnType != null) // Returning type
                str += _method.m_ReturnType.m_typeName + " "; // Name of method
            str += _method.Name;
            if (_method.m_Extension) // If extension method
                str += " :Extension Method";
            return str;
        }
    }
}
