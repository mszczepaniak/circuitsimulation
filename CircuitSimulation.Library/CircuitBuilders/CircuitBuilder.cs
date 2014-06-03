using System;
using System.Collections.Generic;
using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class CircuitBuilder
    {
        private readonly CircuitData circuitData;
        private readonly Simulation simulation;
        private readonly Dictionary<Type, IElementBuilder> elementBuilders = new Dictionary<Type, IElementBuilder>();

        public CircuitBuilder(CircuitData circuitData, Simulation simulation)
        {
            this.circuitData = circuitData;
            this.simulation = simulation;

            Register(new AndGateBuilder());
            Register(new BufferBuilder());
            Register(new OrGateBuilder());
            Register(new ExnorGateBuilder());
            Register(new XorGateBuilder());
            Register(new NandGateBuilder());
            Register(new NotGateBuilder());
            Register(new NorGateBuilder());
            Register(new SwitchBuilder());
            Register(new DiodeBuilder());
            Register(new FlipFlopBuilder());
            Register(new GeneratorBuilder());
            Register(new IntegratedCircuitBuilder());
            Register(new FreeInputBuilder());
            Register(new FreeOutputBuilder());
        }

        private void Register<TElement, TData>(ElementBuilder<TElement, TData> builder) 
            where TElement : Element 
            where TData : ElementData
        {
            elementBuilders.Add(typeof(TData), builder);
        }

        public Circuit BuildCircuit()
        {
            var elements = BuildElements();
            var circuit = new Circuit(elements);
            ConnectWires(circuit);
            return circuit;
        }

        public List<Element> BuildElements()
        {
            var results = new List<Element>();
            foreach (var elementData in circuitData.Elements)
            {
                var element = BuildElement(elementData);
                results.Add(element);
            }

            return results;
        }

        private Element BuildElement(ElementData elementData)
        {
            var elementType = elementData.GetType();
            if (!elementBuilders.ContainsKey(elementType))
                throw new SimulationException("Unknown element " + elementType);

            var builder = elementBuilders[elementType];
            return builder.BuildElement(elementData, simulation);
        }

        private void ConnectWires(Circuit circuit)
        {
            foreach (var wireData in circuitData.Wires)
            {
                circuit.ConnectElements(wireData.Id, wireData.Source.Id, wireData.Target.Id);
            }
        }
    }
}