using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Loging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA_Etap_1.Reflection.Model;
using ViewModel;
using ViewModel.ViewItems;

namespace Tests
{
    [TestClass]
    public class Reflection
    {
        public string path = @"..\..\..\TPA.ApplicationArchitecture.dll";


        [TestMethod]
        public void ReflectionTest()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(path);
            Assert.IsFalse(reflector.AssemblyModel == null);
        }

        [TestMethod]
        public void MethodsTest()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(path);
            Assert.AreEqual(reflector.AssemblyModel.m_Namespaces.ToList().Count(), 4);
        }

        [TestMethod]
        public void NamespaceTest()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(path);
            NamespaceMetadata _namespace = reflector.AssemblyModel.m_Namespaces.ToList()[0];
            Assert.AreEqual(_namespace.m_Types.Count(), 5);
        }

        [TestMethod]
        public void ParametersMethodTest()
        {

            Reflector reflector = new Reflector();
            reflector.Reflect(path);
            List<TypeMetadata> m_types = reflector.AssemblyModel.m_Namespaces.ToList()[0].m_Types.ToList();
            Assert.AreEqual(m_types[0].m_Constructors.Count(), 1);
            Assert.AreEqual(m_types[1].m_Constructors.Count(), 1);
            Assert.AreEqual(m_types[2].m_Constructors.Count(), 1);
            Assert.AreEqual(m_types[0].m_Methods.Count(), 6);
            Assert.AreEqual(m_types[1].m_Methods.Count(), 6);
            Assert.AreEqual(m_types[2].m_Methods.Count(), 6);
            Assert.AreEqual(m_types[0].m_Properties.Count(), 1);
            Assert.AreEqual(m_types[1].m_Properties.Count(), 1);
            Assert.AreEqual(m_types[2].m_Properties.Count(), 1);
        }
    }
}