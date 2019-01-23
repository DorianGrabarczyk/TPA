using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using DataLayer.DTO;
using Interfaces;

namespace FileSerializer
{
    [Export("File", typeof(ISerializer))]
    //[ServiceContract(Name = "XMLSerializer")]
    public class XMLSerializer : ISerializer
    {
        //private readonly DataContractSerializer serializer = new DataContractSerializer(typeof(XMLAs))
        public BaseAssemblyMetadata Deserialize(string path)
        {
            List<Type> lista = new List<Type>
                {
                typeof(System.FlagsAttribute),
                typeof(System.Reflection.DefaultMemberAttribute),
                typeof(System.AttributeUsageAttribute),
                typeof(System.ObsoleteAttribute),
                typeof(System.SerializableAttribute),
                typeof(System.Runtime.Serialization.KnownTypeAttribute)
                };
            BaseAssemblyMetadata temp = default(BaseAssemblyMetadata);
            DataContractSerializer ser = new DataContractSerializer(typeof(BaseAssemblyMetadata));


            using (var xmlreader = XmlReader.Create(path))
            {
                // XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas { MaxDepth = int.MaxValue });
                temp = (BaseAssemblyMetadata)ser.ReadObject(xmlreader);
            }
            return temp;
        }



        public void Serialize(BaseAssemblyMetadata data, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //XmlWriterSettings sets = new XmlWriterSettings { Indent = true, IndentChars = "\t" };
                //sets.CloseOutput = true;
                //XmlWriter writer = XmlWriter.Create(fs, sets);
                //DataContractSerializer ser;
                //if (data is AssemblyMetadata)
                //{
                //    ser = new DataContractSerializer(typeof(AssemblyMetadata));
                //}
                //else
                //{
                //    ser = new DataContractSerializer(typeof(T));
                //}
                //ser.WriteObject(writer, data);
                //writer.Close();
                List<Type> lista = new List<Type>
                {
                typeof(System.FlagsAttribute),
                typeof(System.Reflection.DefaultMemberAttribute),
                typeof(System.AttributeUsageAttribute),
                typeof(System.ObsoleteAttribute),
                typeof(System.SerializableAttribute),
                typeof(System.Runtime.Serialization.KnownTypeAttribute)
                };
                DataContractSerializerSettings DCsettings = new DataContractSerializerSettings { PreserveObjectReferences = true, KnownTypes = lista };
                DataContractSerializer ser = new DataContractSerializer(typeof(BaseAssemblyMetadata), DCsettings);
                var XmlWriterSettings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\t"

                };

                using (var XmlWriter = System.Xml.XmlWriter.Create(fs, XmlWriterSettings))
                {
                    ser.WriteObject(XmlWriter, data);
                }


            }
        }

    }
}
