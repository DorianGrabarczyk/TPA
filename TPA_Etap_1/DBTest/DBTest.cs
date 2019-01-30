using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataBase;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;

namespace DBTest
{
    [TestClass]
    public class DBTest
    {
        public string pathh = @"..\..\..\TPA.ApplicationArchitecture.dll";

        [TestMethod]
        public void TestMethod1()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(pathh);
            ISerializer ser = new DatabaseSerializer();
            DBModelContext db = new DBModelContext();
            ser.Serialize(reflector.AssemblyModel.MapUp(), null);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(null));


            Assert.AreEqual(4, assemblyTest.m_Namespaces.ToList().Count());
        }
        public void Classes()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(pathh);
            ISerializer ser = new DatabaseSerializer();
            DBModelContext db = new DBModelContext();
            ser.Serialize(reflector.AssemblyModel.MapUp(), null);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(null));

            List<TypeMetadata> testLibraryTypes = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();

            Assert.AreEqual(5, testLibraryTypes.Count);
        }
        [TestMethod]
        public void PropertyInClass()
        {

            Reflector reflector = new Reflector();
            reflector.Reflect(pathh);
            ISerializer ser = new DatabaseSerializer();
            DBModelContext db = new DBModelContext();
            ser.Serialize(reflector.AssemblyModel.MapUp(), null);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(null));

            List<TypeMetadata> test = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();
            Assert.AreEqual(1, test.First().m_Properties.ToList().Count);
        }
        [TestMethod]
        public void MethotsInClass()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(pathh);
            ISerializer ser = new DatabaseSerializer();
            DBModelContext db = new DBModelContext();
            ser.Serialize(reflector.AssemblyModel.MapUp(), null);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(null));

            List<TypeMetadata> test = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();
            Assert.AreEqual(6, test.First().m_Methods.ToList().Count);
        }
    }
}

