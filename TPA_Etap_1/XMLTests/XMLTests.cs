﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.DTO;
using FileSerializer;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;
using ViewModel.ViewItems;

namespace XMLTests
{
    [TestClass]
    public class XMLTests
    {
        public string path = @"..\..\..\TPA.ApplicationArchitecture.dll";
        public string xmlpath = "test.xml";
        private BaseAssemblyMetadata assembly= new BaseAssemblyMetadata();
        [TestMethod]
        public void CheckNamespaces()
        {
            Reflector reflector = new Reflector();
            ISerializer serialize = new XMLSerializer();
            reflector.Reflect(path);
            serialize.Serialize(reflector.AssemblyModel.MapUp(), xmlpath);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(serialize.Deserialize(xmlpath));
            Assert.AreEqual(4, assemblyTest.m_Namespaces.ToList().Count());
        }
        [TestMethod]
        public void Classes()
        {
            Reflector reflector = new Reflector();
            ISerializer serialize = new XMLSerializer();
            reflector.Reflect(path);
            serialize.Serialize(reflector.AssemblyModel.MapUp(), xmlpath);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(serialize.Deserialize(xmlpath));

            List<TypeMetadata> testLibraryTypes = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();

            Assert.AreEqual(5, testLibraryTypes.Count);
        }
        [TestMethod]
        public void PropertyInClass()
        {

            Reflector reflector = new Reflector();
            ISerializer serialize = new XMLSerializer();
            reflector.Reflect(path);
            serialize.Serialize(reflector.AssemblyModel.MapUp(), xmlpath);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(serialize.Deserialize(xmlpath));

            List<TypeMetadata> test = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();
            Assert.AreEqual(1, test.First().m_Properties.ToList().Count);
        }
        [TestMethod]
        public void MethotsInClass()
        {
            Reflector reflector = new Reflector();
            ISerializer serialize = new XMLSerializer();
            reflector.Reflect(path);
            serialize.Serialize(reflector.AssemblyModel.MapUp(), xmlpath);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(serialize.Deserialize(xmlpath));

            List<TypeMetadata> test = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();
            Assert.AreEqual(6, test.First().m_Methods.ToList().Count);
        }
    }
}
