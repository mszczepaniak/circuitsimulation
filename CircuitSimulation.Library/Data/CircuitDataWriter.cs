using System.IO;
using System.Xml.Serialization;

namespace CircuitSimulation.Library.Data
{
    public class CircuitDataWriter
    {
         public static void Write(object obj, Stream stream)
         {
             var serializer = new XmlSerializer(typeof(CircuitData));
             serializer.Serialize(stream, obj);
         }
    }
}