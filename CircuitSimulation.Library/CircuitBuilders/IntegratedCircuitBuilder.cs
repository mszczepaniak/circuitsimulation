using System;
using System.Collections.Generic;
using CircuitSimulation.Library.Data;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library.CircuitBuilders
{
    public class IntegratedCircuitBuilder : ElementBuilder<IntegratedCircuit,IntegratedCircuitData>
    {
        private  Simulation simulation;
        private readonly Dictionary<Type, IElementBuilder> elementBuilders = new Dictionary<Type, IElementBuilder>();
        
        public IntegratedCircuitBuilder()
        {

            // register any element except for elements that can be only
            // inputs or outputs of the whole circuit : switch, generator and diode 
            Register(new AndGateBuilder());
            Register(new OrGateBuilder());
            Register(new ExnorGateBuilder());
            Register(new XorGateBuilder());
            Register(new NandGateBuilder());
            Register(new NotGateBuilder());
            Register(new NorGateBuilder());
            Register(new FlipFlopBuilder());
            Register(new FreeInputBuilder());
            Register(new FreeOutputBuilder());

        }
        private void Register<TElement, TData>(ElementBuilder<TElement, TData> builder)
            where TElement : Element
            where TData : ElementData
        {
            elementBuilders.Add(typeof(TData), builder);
        }

        protected override IntegratedCircuit Build(IntegratedCircuitData integratedCircuitdata, Simulation simulation)
        {
            var elements = BuildElements(integratedCircuitdata.Elements, simulation);
            var integratedCircuit = new IntegratedCircuit(0, simulation, elements);
            AddExternalSockets(integratedCircuit, integratedCircuitdata);
            ConnectWires(integratedCircuit, integratedCircuitdata);
            ConnectFreeSocketsToExternalSockets(integratedCircuit, elements);
            return integratedCircuit;
        }

        private void AddExternalSockets(IntegratedCircuit integratedCircuit, IntegratedCircuitData integratedCircuitdata)
        {
            foreach (var inputData in integratedCircuitdata.ExternalInputs)
            {
                var input = new Input(inputData.Name);
                input.Id = inputData.Id;
                input.SetInitialSocketSignal(Signal.FromSignalType(inputData.Signal));
                integratedCircuit.AddExternalInput(input);
            }

            foreach (var outputData in integratedCircuitdata.ExternalOutputs)
            {
                var output = new Output(outputData.Name);
                output.Id = outputData.Id;
                output.SetInitialSocketSignal(Signal.FromSignalType(outputData.Signal));
                integratedCircuit.AddExternalOutput(output);
            }
        }

        private Element Build(ElementData elementData, Simulation simulation)
        {
            this.simulation = simulation;
            var elementType = elementData.GetType();
            if (!elementBuilders.ContainsKey(elementType))
                throw new SimulationException("Unknown element " + elementType);

            var builder = elementBuilders[elementType];
            return builder.BuildElement(elementData, simulation);
        }

        private List<Element> BuildElements(List<ElementData> elements, Simulation simulation)
        {
            var results = new List<Element>();
            foreach (var elementData in elements)
            {
                var element = Build(elementData, simulation);
                results.Add(element);
            }

            return results;
        }

        private void ConnectWires(IntegratedCircuit integratedCircuit, IntegratedCircuitData integratedCircuitData)
        {
            foreach (var wireData in integratedCircuitData.Wires)
            {
                integratedCircuit.ConnectInnerElements(wireData.Id, wireData.Source.Id, wireData.Target.Id);
            }
        }

        private void ConnectFreeSocketsToExternalSockets(IntegratedCircuit integratedCircuit, List<Element> elements)
        {
            foreach (var element in elements)
            {
                if (element is FreeInput)
                {
                    integratedCircuit.ConnectFreeInput((FreeInput) element);
                }
                else if (element is FreeOutput)
                {
                    integratedCircuit.ConnectFreeOutput((FreeOutput) element);
                }
            }
        }
    }
}