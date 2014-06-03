using CircuitSimulation.Library.Elements;
using NUnit.Framework;

namespace CircuitSimulation.Library.Tests
{
    [TestFixture]
    public class ExorGateTests
    {
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        public void TestOutput(int input1, int input2, int expectedOutput)
        {
            TwoInputGateTester.TestElement(new XorGate(0, new ImmediateSimulation()), input1, input2, expectedOutput);
        }
    }
}