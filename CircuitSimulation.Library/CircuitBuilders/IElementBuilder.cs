using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public interface IElementBuilder
    {
        Element BuildElement(ElementData data, Simulation simulation);
    }
}