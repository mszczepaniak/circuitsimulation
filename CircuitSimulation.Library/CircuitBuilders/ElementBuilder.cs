using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public abstract class ElementBuilder<TElement, TData> : IElementBuilder
        where TData : ElementData
        where TElement : Element
    {
        public Element BuildElement(ElementData data, Simulation simulation)
        {
            if (!(data is TData))
                throw new SimulationException("Incorrect builder for " + typeof (TElement));

            return Build((TData) data, simulation);
        }

        protected abstract TElement Build(TData data, Simulation simulation);
    }
}