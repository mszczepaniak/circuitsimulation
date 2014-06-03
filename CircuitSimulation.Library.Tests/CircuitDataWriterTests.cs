using System;
using System.IO;
using System.Text;
using CircuitSimulation.Library.Data;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class CircuitDataWriterTests
    {
        [Test]
        public void SerializeAndDeserialize()
        {
            var circuitToSave = new CircuitData();
            var andGateData = new AndGateData();
            var input1 = new InputData();
            input1.Id = Guid.NewGuid();
            var input2 = new InputData();
            input2.Id = Guid.NewGuid();

            andGateData.Input1 = input1;
            andGateData.Input2 = input2;

            andGateData.Delay = 10;
            andGateData.Id = Guid.NewGuid();
            circuitToSave.Elements.Add(andGateData);

            CircuitData circuitToRead;

            using (var stream = new MemoryStream())
            {
                CircuitDataWriter.Write(circuitToSave, stream);
                stream.Seek(0, SeekOrigin.Begin); // przewinięcie z powrotem na początek
                circuitToRead = CircuitDataReader.Read(stream);
            }
            var andGate = (AndGateData) circuitToRead.Elements[0];
            Assert.AreEqual(andGateData.Id,andGate.Id);
            Assert.AreEqual(andGateData.Delay,andGate.Delay);

        }
    }
}