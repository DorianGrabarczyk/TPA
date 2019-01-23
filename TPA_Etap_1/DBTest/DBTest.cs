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
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DBTest";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database2.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DBModelContext db = new DBModelContext(a + path + b);
            ser.Serialize(reflector.AssemblyModel.MapUp(),a+path+b);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(a+path+b));


            Assert.AreEqual(4, assemblyTest.m_Namespaces.ToList().Count());
        }
        public void Classes()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(pathh);
            ISerializer ser = new DatabaseSerializer();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DBTest";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database2.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DBModelContext db = new DBModelContext(a + path + b);
            ser.Serialize(reflector.AssemblyModel.MapUp(), a + path + b);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(a + path + b));

            List<TypeMetadata> testLibraryTypes = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();

            Assert.AreEqual(5, testLibraryTypes.Count);
        }
        [TestMethod]
        public void PropertyInClass()
        {

            Reflector reflector = new Reflector();
            reflector.Reflect(pathh);
            ISerializer ser = new DatabaseSerializer();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DBTest";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database2.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DBModelContext db = new DBModelContext(a + path + b);
            ser.Serialize(reflector.AssemblyModel.MapUp(), a + path + b);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(a + path + b));

            List<TypeMetadata> test = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();
            Assert.AreEqual(1, test.First().m_Properties.ToList().Count);
        }
        [TestMethod]
        public void MethotsInClass()
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(pathh);
            ISerializer ser = new DatabaseSerializer();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DBTest";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database2.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DBModelContext db = new DBModelContext(a + path + b);
            ser.Serialize(reflector.AssemblyModel.MapUp(), a + path + b);
            AssemblyMetadata assemblyTest = new AssemblyMetadata(ser.Deserialize(a + path + b));

            List<TypeMetadata> test = assemblyTest.m_Namespaces.ToList().Find(t => t.m_NamespaceName == "TPA.ApplicationArchitecture.BusinessLogic").m_Types.ToList();
            Assert.AreEqual(6, test.First().m_Methods.ToList().Count);
        }
    }
}

