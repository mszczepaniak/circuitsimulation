using System;
using System.Collections.Generic;
using CircuitSimulation.Library.Elements;

namespace CircuitSimulation.Library
{
    public class Circuit
    {
        // obwód sk³ada siê z elementów i przewodów ³¹cz¹cych:
        private readonly List<Element> elements;
        private readonly List<Wire> wires =  new List<Wire>();

        public Circuit(List<Element> elementList)
        {
            elements = elementList;
        }

        public void ConnectElements(Guid wireId, Guid sourceSocketId, Guid targetSocketId)
        {
            var sourceSocket = GetOutputFromId(sourceSocketId);
            var targetSocket = GetInputFromId(targetSocketId);

            var wire = Wire.Connect(sourceSocket, targetSocket);
            wire.Id = wireId;
            wires.Add(wire);
        }

        public void SetSwiches(List<InitialSwitchState> initialSwitchStates)
        {
            foreach (var initialSwitchState in initialSwitchStates)
            {
                var element = GetElementById(initialSwitchState.SwitchId);
                if (element == null)
                    throw new SimulationException("Cannot find element with id " + initialSwitchState.SwitchId);

                var switchElement = element as Switch;
                if (switchElement == null)
                    throw new SimulationException("Element with id " + initialSwitchState.SwitchId + " is not a switch");

                switchElement.Output.Signal = initialSwitchState.InitialSignal;
            }
        }

        public void SetGenerators(List<InitialGeneratorState> initialGeneratorStates)
        {
            foreach (var initialGeneratorState in initialGeneratorStates)
            {
                var element = GetElementById(initialGeneratorState.GeneratorId);
                if (element == null)
                    throw new SimulationException("Cannot find element with id" + initialGeneratorState.GeneratorId);
                var generatorElement = element as Generator;
                if(generatorElement == null)
                    throw new SimulationException("Element with id" + initialGeneratorState.GeneratorId + " is not a generator");

                generatorElement.Start(initialGeneratorState.InitialSignal);
            }
        }

        private Element GetElementById(Guid elementId)
        {
            foreach (var element in elements)
            {
                if (element.Id == elementId)
                    return element;
            }

            return null;
        }

        private Input GetInputFromId(Guid inputId)
        {
            foreach (var element in elements)
            {
                var found = element.GetInputById(inputId);
                if (found != null)
                    return found;
            }

            throw new SimulationException("Input not found: " + inputId);
        }

        private Output GetOutputFromId(Guid outputId)
        {
            foreach (var element in elements)
            {
                var found = element.GetOutputById(outputId);
                if (found != null)
                    return found;
            }

            throw new SimulationException("Output not found: " + outputId);
        }

        
    }
}