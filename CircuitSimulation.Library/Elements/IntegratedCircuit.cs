using System;
using System.Collections.Generic;
using System.Linq;
using CircuitSimulation.Library.Events;

namespace CircuitSimulation.Library.Elements
{
    public class IntegratedCircuit : Element
    {
        private List<Element> innerElements;
        private readonly List<Wire> innerWires = new List<Wire>();
        private readonly List<Input> externalInputs = new List<Input>();
        private readonly List<Output> externalOutputs = new List<Output>();
        public IntegratedCircuit(int delay, ISimulation simulation, List<Element> elementList)
            : base(delay, simulation)
        {
            innerElements = elementList;

        }

        public void GetElements(List<Element> elementList)
        {
            innerElements = elementList;
        }

        public void ConnectInnerElements(Guid wireId, Guid sourceSocketId, Guid targetSocketId)
        {
            var sourceSocket = GetInnerOutputById(sourceSocketId);
            var targetSocket = GetInnerInputById(targetSocketId);

            var wire = Wire.Connect(sourceSocket, targetSocket);
            wire.Id = wireId;
            innerWires.Add(wire);
        }

        public override Input GetInputById(Guid inputId)
        {
            foreach(var input in externalInputs)
            {
                if (input.Id == inputId)
                {
                    return input;
                }
            }

            return null;
        }

        public Input GetInnerInputById(Guid inputId)
        {
            foreach (var innerElement in innerElements)
            {
                var result = innerElement.GetInputById(inputId);
                if (result != null)
                    return result;
            }

            return null;
        }

        public override Output GetOutputById(Guid outputId)
        {
            foreach (var output in externalOutputs)
            {
                if (output.Id == outputId)
                {
                    return output;
                }
            }

            return null;    
        }

        public Output GetInnerOutputById(Guid outputId)
        {
            foreach (var innerElement in innerElements)
            {
                var result = innerElement.GetOutputById(outputId);
                if (result != null)
                    return result;
            }

            return null;
        }

        public void AddExternalInput(Input input)
        {
            externalInputs.Add(input);
        }

        public void AddExternalOutput(Output output)
        {
            externalOutputs.Add(output);
        }

        public void ConnectFreeInput(FreeInput freeInput)
        {
            var externalInput = externalInputs.FirstOrDefault(i => i.Name == freeInput.Name);
            if (externalInput == null)
                return;

            externalInput.SignalChanged += 
                () =>
                    {
                        freeInput.ExternalInput.Signal = externalInput.Signal;
                        Simulation.AddEvent(new IntegratedCircuitInputChanged(
                            Simulation.CurrentTime, externalInput.Id, externalInput.Name, externalInput.Signal));
                    };
        }

        public void ConnectFreeOutput(FreeOutput freeOutput)
        {
            var externalOutput = externalOutputs.FirstOrDefault(i => i.Name == freeOutput.Name);
            if (externalOutput == null)
                return;

            freeOutput.ExternalOutput.SignalChanged +=
                () =>
                    {
                        externalOutput.Signal = freeOutput.ExternalOutput.Signal;
                        Simulation.AddEvent(new IntegratedCircuitOutputChanged(
                            Simulation.CurrentTime, externalOutput.Id, externalOutput.Name, externalOutput.Signal));
                    };
        }
    }

}