using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using System.ServiceModel;

namespace DataSerializer
{
    [Export(typeof(ISerializer<>))]
    [ServiceContract(Name = "IRepostioryXML")]
    public class XMLSerializer<T> : ISerializer<T>
    {
        public T Deserialize<T>(string path)
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
            T temp = default(T);
            DataContractSerializer ser = new DataContractSerializer(typeof(T));


            using (var xmlreader = XmlReader.Create(path))
            {
                // XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas { MaxDepth = int.MaxValue });
                temp = (T)ser.ReadObject(xmlreader);
            }
            return temp;
        }

        public void Serialize<T> (T data, string path)
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
                DataContractSerializerSettings DCsettings = new DataContractSerializerSettings{ PreserveObjectReferences = true, KnownTypes = lista };
                DataContractSerializer ser = new DataContractSerializer(typeof(T), DCsettings);
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
