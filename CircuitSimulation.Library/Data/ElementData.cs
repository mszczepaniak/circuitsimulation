using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CircuitSimulation.Library.Data
{
    [XmlInclude(typeof(AndGateData))]
    [XmlInclude(typeof(OrGateData))]
    [XmlInclude(typeof(XnorGateData))]
    [XmlInclude(typeof(XorGateData))]
    [XmlInclude(typeof(NandGateData))]
    [XmlInclude(typeof(NotGateData))]
    [XmlInclude(typeof(NorGateData))]
    [XmlInclude(typeof(XnorGateData))]
    [XmlInclude(typeof(XorGateData))]
    [XmlInclude(typeof(FlipFlopData))]
    [XmlInclude(typeof(BufferData))]
    [XmlInclude(typeof(DiodeData))]
    [XmlInclude(typeof(GeneratorData))]
    [XmlInclude(typeof(SwitchData))]
    [XmlInclude(typeof(IntegratedCircuitData))]
    [XmlInclude(typeof(FreeInputData))]
    [XmlInclude(typeof(FreeOutputData))]
    public abstract class ElementData
    {
        public int Delay { get; set; }
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ElementType Type { get; set; }

        public abstract List<SocketData> GetSockets();
    }

    public enum ElementType
    {
        Diode,
        Switch,
        Buffer,
        Not,
        And,
        Or,
        Xor,
        Nand,
        Nor,
        Xnor,
        SrLatch,
        Generator,
        IntegratedCircuit,
        FreeInput,
        FreeOutput
    }
}