using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using TPA_Etap_1.Reflection.Model;

namespace DataSerializer
{
    [Export(typeof(ISerializer<>))]
    public class XMLSerializer<T> : ISerializer<T>
    {
        public T Deserialize<T>(string path)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            T temp = default(T);

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas { MaxDepth = int.MaxValue });
                temp = (T)ser.ReadObject(fs);
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

                DataContractSerializerSettings DCsettings = new DataContractSerializerSettings{ PreserveObjectReferences = true };
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
                fs.Close();

            }
        }
    }
}
