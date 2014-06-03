using System;
using System.IO;
using System.Xml.Serialization;

namespace CircuitSimulation.Library.Data
{
    public class CircuitDataReader
    {
        public static CircuitData Read(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(CircuitData));
            return (CircuitData) serializer.Deserialize(stream);
        }

        public static CircuitData ReadFromFile(string circuitFile)
        {
            try
            {
                using (var file = File.OpenRead(circuitFile))
                {
                    return Read(file);
                }
            }
            catch(Exception exception)
            {
                throw new SimulationException("Error opening circuit file: " + circuitFile, exception);
            }
        }
    }
}