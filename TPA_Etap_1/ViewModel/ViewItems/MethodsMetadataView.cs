using Loging;
using System.Collections.Generic;
using System.Linq;
using TPA_Etap_1.Reflection.Model;

namespace ViewModel.ViewItems
{
    class MethodsMetadataView : ITree
    {
        private IEnumerable<MethodMetadata> _methods;

        public override string Name => this.ToString();
        public override bool Expandable => _methods?.Count() > 0;

        public MethodsMetadataView(Logger log, IEnumerable<MethodMetadata> methods) : base(log)
        {
            _methods = methods;
        }

        public override void LoadChildren()
        {
            base.LoadChildren();
            Children.Clear();
            foreach (var child in _methods)
                Children.Add(new MethodMetadataView(Log, child));
        }

        public override string ToString()
        {
            return "Methods: ";
        }
    }
}
