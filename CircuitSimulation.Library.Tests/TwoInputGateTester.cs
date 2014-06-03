using CircuitSimulation.Library.Elements;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    public class TwoInputGateTester
    {
        public static void TestElement(TwoInputGate gate, int input1, int input2, int expectedOutput)
        {
            gate.Input1.Signal = Signal.FromInt(input1);
            gate.Input2.Signal = Signal.FromInt(input2);
            Assert.AreEqual(Signal.FromInt(expectedOutput), gate.Output.Signal);
        }
    }
}