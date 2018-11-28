using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Loging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;
using ViewModel.ViewItems;

namespace Tests
{
    [TestClass]
    public class ViewModelTests
    {
        AssemblyMetadataView AMV;
        ObservableCollection<ITree> Namespaces;
        ObservableCollection<ITree> NamespaceChildren;
        ObservableCollection<ITree> Types;
        ObservableCollection<ITree> Methods;
        ObservableCollection<ITree> Properties;
        Logger Log;

        [TestInitialize]
        public void Begining()
        {
            Reflector refl = new Reflector();
            refl.Reflect("../../../TestDLL.dll");

            Log = new Logger("../../../TestLog.txt");

            AMV = new AssemblyMetadataView(Log, refl.AssemblyModel);

            // Namespaces set up.
            AMV.LoadChildren();
            Namespaces = AMV.Children;

            // Types set up.
            ITree Logic = Namespaces[0];
            Logic.LoadChildren();
            NamespaceChildren = Logic.Children;

            NamespaceChildren[0].LoadChildren();
            Types = NamespaceChildren[0].Children;

            foreach (var item in Types) item.LoadChildren();

            //Methods = Types[1].Children;
           // Properties = Types[2].Children;
        }

        [TestMethod]
        public void NamespaceTest()
        {
            Assert.AreEqual(1, Namespaces.Count);
            List<string> names = Namespaces.Select(x => x.Name).ToList();
            Assert.IsTrue(names.Contains("Namespace : TestDLL"));
        }

        [TestMethod]
        public void MethodsTest()
        {
            Assert.AreEqual(11, Types.Count);

            List<string> names = Types.Select(x => x.Name).ToList();

            Assert.IsTrue(names.Contains("Method: ServiceB get_ServiceB"));
            Assert.IsTrue(names.Contains("Method: Void set_ServiceB"));
            Assert.IsTrue(names.Contains("Method: Int32 get_TestNumber"));
            Assert.IsTrue(names.Contains("Method: Void set_TestNumber"));
            Assert.IsTrue(names.Contains("Method: String ToString"));
            Assert.IsTrue(names.Contains("Method: Boolean Equals"));
            Assert.IsTrue(names.Contains("Method: Int32 GetHashCode"));
            Assert.IsTrue(names.Contains("Method: Type GetType"));
        }

        [TestMethod]
        public void ReturnMethodTypeTest()
        {
            ITree Method = Types.Where(x => x.Name == "Method: ServiceB get_ServiceB").First();
            Method.LoadChildren();

            ITree Type = Method.Children.Where(x => x.Name == "Type : ServiceB").First();

            Assert.AreEqual("Type : ServiceB", Type.Name);
        }

        [TestMethod]
        public void ParametersMethodTest()
        {
            ITree Method = Types.Where(x => x.Name == "Method: ServiceB get_ServiceB").First();

            Method.LoadChildren();
            ITree Parameter = Method.Children[0];

            Assert.AreEqual("Type : ServiceB", Parameter.Name);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            Assert.AreEqual(11, Types.Count);

            List<string> Names = Types.Select(x => x.Name).ToList();
            Assert.IsTrue(Names.Contains("Property: ServiceB"));
        }
    }
}