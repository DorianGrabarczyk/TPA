using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA_Etap_1.Reflection.Model;
using ViewModel;
using ViewModel.ViewItems;

namespace XMLTests
{
    [TestClass]
    public class UnitTest1
    {
        private string pathDLL = @"..\..\..\TestDLL.dll";
        private string pathXML = "../../../alt";
        [TestMethod]
        public void XMLDeserializeAndSerialize()
        {
           ViewContext vc = new ViewContext(pathDLL, 5);
           ViewContext des = new ViewContext();
            
            object assembly = des.serializer.Deserialize<AssemblyMetadata>(pathXML);
            try
            {
                des.HierarchicalAreas.Clear();
                AssemblyMetadataView temp = new AssemblyMetadataView(des._log, (AssemblyMetadata)assembly);
                temp.LoadChildren();
                des.HierarchicalAreas.Add(temp);
                //TreeViewLoaded();
            }
            catch
            {
                des.HierarchicalAreas.Clear();
                AssemblyMetadataView temp = new AssemblyMetadataView(des._log, (AssemblyMetadata)assembly);
                temp.LoadChildren();
                des.HierarchicalAreas.Add(temp);
                //TreeViewLoaded();
            }

            
            Assert.AreEqual(vc.HierarchicalAreas.Count, des.HierarchicalAreas.Count);

            
            Assert.AreEqual(vc.HierarchicalAreas[0].Children.Count, des.HierarchicalAreas[0].Children.Count);
            vc.HierarchicalAreas[0].Children[0].LoadChildren();
            des.HierarchicalAreas[0].Children[0].LoadChildren();
            Assert.AreEqual(vc.HierarchicalAreas[0].Children[0].Children.Count, des.HierarchicalAreas[0].Children[0].Children.Count);
            vc.HierarchicalAreas[0].Children[0].Children[0].LoadChildren();
            des.HierarchicalAreas[0].Children[0].Children[0].LoadChildren();
            Assert.AreEqual(vc.HierarchicalAreas[0].Children[0].Children[0].Children.Count, des.HierarchicalAreas[0].Children[0].Children[0].Children.Count);


        }
    }
}
